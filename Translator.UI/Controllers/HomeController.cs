using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Translator.Bll.Services.LeetTranslatiorService.Abstract;
using Translator.Bll.Services.TranslationLogService.Abstract;
using Translator.Dto.Request;
using Translator.UI.Models;

namespace Translator.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITranslationLogServices _translationLogServices;
        private readonly ILeetTranslator _leetTranslator;

        public HomeController(ITranslationLogServices translationLogServices, ILeetTranslator leetTranslator)
        {
            _translationLogServices = translationLogServices;
            _leetTranslator = leetTranslator;
        }

        [HttpGet]
        public IActionResult Index()
        {
            LeetTranslateResponseViewModel response = new LeetTranslateResponseViewModel();
            return View(response);
        }

        [HttpPost]
        public IActionResult Index(LeetTranslateRequestViewModel model)
        {
            LeetTranslateResponseViewModel response = new LeetTranslateResponseViewModel();
            if (ModelState.IsValid)
            {
                var translation = _leetTranslator.TranslateToLeet(new LeetRequestDto { Text = model.Text });

                if (translation.StatusCode == 200)
                {
                    _translationLogServices.AddTranslationData(new AddTranslationDataRequestDto { Text = translation.Data.Text, Translation = translation.Data.Translated, TranslationType = translation.Data.Translation });
                    response.Translation = translation.Data.Translated;
                    return View(response);
                }
                else
                {
                    response.Message = translation.Message;
                    return View(response);
                }
            }
            return View(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}