using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Core.Expections
{
    public class BusinessExeption : Exception
    {
        public BusinessExeption()
        {

        }

        public BusinessExeption( string message):base(message)
        {

        }
    }
}
