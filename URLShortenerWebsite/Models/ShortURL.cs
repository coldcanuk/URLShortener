using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace URLShortenerWebsite.Models
{
    public class ShortURL
    {
        public Guid ID { get; set; }
        public string URL { get; set; }
        public string Token { get; set; }
    }
}
