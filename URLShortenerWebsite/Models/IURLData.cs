using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortenerWebsite.Models
{
    public interface IURLData
    {
        ShortURL GetShortURLByToken(string token);
        void AddShortURL(ShortURL shortURL);
    }
}
