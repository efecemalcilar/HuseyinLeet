using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Translator.Dal.ApiCalls.FunTranslations.Translate.Abstract;
using Translator.Dal.ApiCalls.FunTranslations.Translate.Concrete;
using Translator.Dal.Repositories.Abstract;
using Translator.Dal.Repositories.Concrete;

namespace Translator.Dal.Extensions
{
    public static class DalExtensions
    {
        public static void IncludeDalServices(this IServiceCollection services)
        {
            services.AddScoped<ITranslationLogRepository, TranslationLogRepository>();
            services.AddScoped<ITranslateApiCalls, TranslateApiCalls>();
        }
    }
}
