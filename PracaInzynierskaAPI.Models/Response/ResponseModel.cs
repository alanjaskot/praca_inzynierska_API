using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierskaAPI.Models.Response
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
#nullable enable
        public T? Object { get; set; }
#nullable disable
    }
}
