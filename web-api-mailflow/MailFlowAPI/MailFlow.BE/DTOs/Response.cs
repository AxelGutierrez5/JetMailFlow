using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BE.DTOs
{
    public class Response 
    {
        public string Message { get; set; } = null!;
        public bool Success { get; set; }

        public string Token { get; set; }


    }

    public class Response<T> : Response where T : class
    {
        public T Value { get; set; } = null!;

    }
}
