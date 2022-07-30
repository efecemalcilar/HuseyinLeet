using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Translator.Bll.Services.LeetTranslatiorService.Abstract;
using Translator.Bll.Services.LeetTranslatiorService.Concrete;
using Translator.Bll.Services.TranslationLogService.Abstract;
using Translator.Bll.Services.TranslationLogService.Concrete;
using Translator.Dal.Extensions;

namespace Translator.Bll.Extensions
{
    public static class BllExtensions
    {
        public static void IncludeBllServices(this IServiceCollection services)
        {
            services.IncludeDalServices();
            services.AddScoped<ILeetTranslator, LeetTranslator>();
            services.AddScoped<ITranslationLogServices, TranslationLogServices>();
        }
    }
}
