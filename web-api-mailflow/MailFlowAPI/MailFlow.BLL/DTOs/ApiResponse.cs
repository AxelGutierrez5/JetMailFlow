using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.BLL.DTOs
{
    public class ApiResponse 
    {
        public string Message { get; set; } = null!;
        public bool Success { get; set; }
        public object? Value { get; set; }
        public string? Token { get; set; }


    }

    
}
