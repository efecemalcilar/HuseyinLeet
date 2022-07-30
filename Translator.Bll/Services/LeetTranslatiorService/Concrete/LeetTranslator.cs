using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.Bll.Services.LeetTranslatiorService.Abstract;
using Translator.Dal.ApiCalls.FunTranslations.Translate.Abstract;
using Translator.Dto.Request;
using Translator.Dto.Response;

namespace Translator.Bll.Services.LeetTranslatiorService.Concrete
{
    public class LeetTranslator : ILeetTranslator
    {
        private const string _point = "leetspeak";
        private ITranslateApiCalls _call;

        public LeetTranslator(ITranslateApiCalls call)
        {
            _call = call;
        }
        public BaseResponseWithDataDto<TranslateToLeetResponseDto> TranslateToLeet(LeetRequestDto request)
        {
            try
            {
                dynamic req = new { text = request.Text };

                var apiResult = _call.Translate(_point, req);

                if (apiResult.Result.error != null)
                {
                    return new BaseResponseWithDataDto<TranslateToLeetResponseDto>()
                    {
                        StatusCode = apiResult.Result.error.code,
                        Message = apiResult.Result.error.message
                    };
                }

                TranslateToLeetResponseDto data = new TranslateToLeetResponseDto { Text = apiResult.Result.contents.text, Translated = apiResult.Result.contents.translated, Translation = apiResult.Result.contents.translation };
                
                return new BaseResponseWithDataDto<TranslateToLeetResponseDto>()
                {
                    StatusCode = 200,
                    //Data = data,
                    Message = "Success"
                };

            }
            catch (Exception ex)
            {
                throw new Exception($"Error while api call for leet translate\n Reason: {ex.Message}");
            }
        }
    }
}
