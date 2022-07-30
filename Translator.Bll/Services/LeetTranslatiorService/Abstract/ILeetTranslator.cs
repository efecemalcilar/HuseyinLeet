using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.Dto.Request;
using Translator.Dto.Response;

namespace Translator.Bll.Services.LeetTranslatiorService.Abstract
{
    public interface ILeetTranslator
    {
        BaseResponseWithDataDto<TranslateToLeetResponseDto> TranslateToLeet(LeetRequestDto request);

    }
}
