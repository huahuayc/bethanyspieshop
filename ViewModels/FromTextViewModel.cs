using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TextTranslator.ViewModels
{
    public class FromTextViewModel
    {
        public string InputText { get; set; }
        public string TargetLanguage { get; set; } = "fr";
        public string SourceLanguage { get; set; } = "en";
        

    }
}
