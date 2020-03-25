using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using URLShortenerWebsite.Models;

namespace URLShortenerWebsite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IURLData urlData;

        public ShortURL ShortURL { get; set; }

        public IndexModel(IURLData urlData)
        {
            this.urlData = urlData;
        }

        public IActionResult OnGet(string token)
        {
            if(token != null)
            {
                string longURL = urlData.GetShortURLByToken(token).URL;
                if(longURL != null)
                    return Redirect(longURL);
            }

            return Page();
        }

        public IActionResult OnPost(string inputURL)
        {
            if(inputURL == null)
            {
                ViewData["NullError"] = "URL input cannot be blank.";
                return Page();
            }
            else if(!inputURL.StartsWith("http"))
            {
                inputURL = "http://" + inputURL;
            }

            string token = GenerateToken.Generate();

            while (urlData.GetShortURLByToken(token) != null)
            {
                token = token = GenerateToken.Generate();
            }

            ShortURL = new ShortURL() { URL = inputURL, Token = token };
            urlData.AddShortURL(ShortURL);

            return Page();
        }

    }
}
