using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator.Dto.Response
{
    public class BaseResponseDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
