using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Translate;
using Amazon.Translate.Model;
using Microsoft.AspNetCore.Mvc;
using TextTranslator.ViewModels;

namespace TextTranslator.Controllers
{
    public class TranslatorController : Controller
    {
        string accessKey = "AKIAXXPVKLO7YVBU4ZH4";
        string secretKey = "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";
       

        [HttpPost]
        public async Task<ActionResult> TranslateText(FromTextViewModel inputModel)
        {
            /* if (inputModel.InputText != null)
             {
                 var client = new AmazonTranslateClient(accessKey, secretKey, RegionEndpoint.USEast1);
                 var request = new TranslateTextRequest()
                 {
                     SourceLanguageCode = inputModel.SourceLanguage,
                     TargetLanguageCode = inputModel.TargetLanguage,
                     Text = inputModel.InputText,
                 };
                 var model = new ToTextViewModel()
                 {
                     OriginalText = inputModel.InputText,
                     TargetLangauge = inputModel.TargetLanguage,
                     TranslateResponse = await client.TranslateTextAsync(request)
                 };
                 return View(model);
             }
             else
             {
                 return View("Error");
             }
            */
            try
            {
                var client = new AmazonTranslateClient(accessKey, secretKey, RegionEndpoint.USEast1);
                var request = new TranslateTextRequest()
                {
                    SourceLanguageCode = inputModel.SourceLanguage,
                    TargetLanguageCode = inputModel.TargetLanguage,
                    Text = inputModel.InputText,
                };
                var model = new ToTextViewModel()
                {
                    OriginalText = inputModel.InputText,
                    TargetLangauge = inputModel.TargetLanguage,
                    TranslateResponse = await client.TranslateTextAsync(request)
                };
                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
           
        }
    }
}
