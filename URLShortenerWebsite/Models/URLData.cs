using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortenerWebsite.Models
{
    public class URLData : IURLData
    {
        private readonly URLShortenerDbContext urlShortenerDbContext;

        public URLData(URLShortenerDbContext urlShortenerDbContext)
        {
            this.urlShortenerDbContext = urlShortenerDbContext;
        }
        public void AddShortURL(ShortURL shortURL)
        {
            urlShortenerDbContext.ShortUrls.Add(shortURL);
            urlShortenerDbContext.SaveChanges();
        }

        public ShortURL GetShortURLByToken(string token)
        {
            return urlShortenerDbContext.ShortUrls.FirstOrDefault(u => u.Token == token);
        }
    }
}
