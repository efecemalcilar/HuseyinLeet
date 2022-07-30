using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translator.Dto.Request;
using Translator.Dto.Response;

namespace Translator.Bll.Services.TranslationLogService.Abstract
{
    public interface ITranslationLogServices
    {
        BaseResponseDto AddTranslationData(AddTranslationDataRequestDto request);
        BaseResponseWithDataDto<List<TranslationLogDto>> GetTranslationLogs(TranslationLogFilterRequestDto filter);
    }
}
