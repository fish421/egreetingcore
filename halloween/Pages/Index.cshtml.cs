﻿using halloween.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace halloween.Pages
{
    public class IndexModel : PageModel
    {
        // DEFAULT MODE
        public void OnGet()
        {
            isPreviewPage = false;
        }

        // PREVIEW MODE (AFTER SUBMITTING)
        public async Task<IActionResult> OnPost()
        {
            if (await isValid())
            {
                if (ModelState.IsValid)
                {

                    try
                    {
                    // DB-RELATED: CUSTOMIZE VALUES TO BE ADDED TO THE DATABASE
                    bridgeGreetings.createDate = DateTime.Now.ToString();
                    bridgeGreetings.createIP = this.HttpContext.Connection.RemoteIpAddress.ToString();
                    bridgeGreetings.SenderEmail = bridgeGreetings.SenderEmail.ToLower();
                    bridgeGreetings.RecipientEmail = bridgeGreetings.RecipientEmail.ToLower();
                    bridgeGreetings.Agree = "Y";
                    bridgeGreetings.Agree = "Incomplete";
                    bridgeGreetings.Mesg = bridgeGreetings.SenderName.Replace("bad word", "");

                    // DB-RELATED: ADD NEW RECORD TO THE DATABASE
                    _myDB.Greetings.Add(bridgeGreetings);
                    _myDB.SaveChanges();

                    return RedirectToPage("Preview", new { id = bridgeGreetings.ID });
                    }
                    catch { }
                }
            }
            else
            {
                ModelState.AddModelError("bridgeGreetings.reCaptcha", "Please try again");
            }

            return Page();
        }

        // BRIDGE TO GREETINGS MODEL
        [BindProperty]
        public Greetings bridgeGreetings { get; set; }

        // HEY, CONNECT MY DATABASE TO THIS MODEL
        private DBBuilder _myDB;
        public IndexModel(DBBuilder myDB)
        {
            _myDB = myDB;
        }



        // TEST IF USER IS LOOKING AT PREVIEW OR FORM
        public bool isPreviewPage { get; set; }

        // RE-CAPTCHA VALIDATION
        private async Task<bool> isValid()
        {
            var response = this.HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(response))
                return false;

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>();
                    values.Add("secret", "6Lc1SjYUAAAAANg-1oygiEdcyB0YsKA6VS3lXfFT");
                    values.Add("response", response);
                    values.Add("remoteip", this.HttpContext.Connection.RemoteIpAddress.ToString());

                    var query = new FormUrlEncodedContent(values);


                    var post = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", query);

                    var json = await post.Result.Content.ReadAsStringAsync();

                    if (json == null)
                        return false;

                    var results = JsonConvert.DeserializeObject<dynamic>(json);

                    return results.success;
                }

            }
            catch { }


            return false;
        }



    }
}