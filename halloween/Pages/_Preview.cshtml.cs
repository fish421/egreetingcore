using halloween.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace halloween.Pages
{
    public class PreviewModel : PageModel
    {
        // BRIDGE TO GREETINGS MODEL
        [BindProperty]
        public Greetings bridgeGreetings { get; set; }

        // DB-RELATED: CONNECT MY DATABASE TO THIS MODEL
        private DBBuilder _myDB;
        public PreviewModel(DBBuilder myDB)
        {
            _myDB = myDB;
        }


        public void OnGet(int ID = 0)
        {
            if (ID > 0)
            {
                bridgeGreetings = _myDB.Greetings.Find(ID);
            }
        }
    }
}