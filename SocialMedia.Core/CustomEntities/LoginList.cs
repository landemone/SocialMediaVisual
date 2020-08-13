using System.Collections.Generic;
using System.Linq;

namespace SocialMedia.Core.CustomEntities
{
    public class LoginList<T> : List<T>
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public LoginList(List<T> items)
        {

            AddRange(items);
        }

        public static LoginList<T> Create(IEnumerable<T> source)
        {
           
            var items = source.ToList();
            return new LoginList<T>(items);
        }

    }
}
