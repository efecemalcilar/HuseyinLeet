using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator.Dto.Request
{
    public class AddTranslationDataRequestDto
    {
        public string Text { get; set; } = "";
        public string Translation { get; set; } = "";
        public string TranslationType { get; set; } = "";
    }
}
