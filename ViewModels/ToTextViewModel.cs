using Amazon.Translate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextTranslator.ViewModels
{
    public class ToTextViewModel
    { 
        public string ResultText { get; set; }
        public string OriginalText { get; set; }
        public string TargetLangauge { get; set; }
        public TranslateTextResponse TranslateResponse { get; set; }
    }
}
