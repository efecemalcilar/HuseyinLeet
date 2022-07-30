using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator.Dal.ApiCalls.FunTranslations.Translate.Abstract
{
    public interface ITranslateApiCalls
    {
        Task<dynamic> Translate(string endpoint, dynamic body);
    }
}
