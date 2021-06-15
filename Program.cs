using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace TextTranslator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //
            // Create array of supported cultures
            string[] cultures = { "en-CA", "en-US", "fr-FR", "ru-RU" };
            Random rnd = new Random();
            int cultureNdx = rnd.Next(0, cultures.Length);
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;
            ResourceManager rm = new ResourceManager("Greetings", typeof(Program).Assembly);
            try
            {
                CultureInfo newCulture = new CultureInfo(cultures[cultureNdx]);
                Thread.CurrentThread.CurrentCulture = newCulture;
                Thread.CurrentThread.CurrentUICulture = newCulture;
                string greeting = String.Format("The current culture is {0}.\n{1}",
                                                Thread.CurrentThread.CurrentUICulture.Name,
                                                rm.GetString("HelloString"));
                Console.WriteLine(greeting);
            }
            catch (CultureNotFoundException e)
            {
                Console.WriteLine("Unable to instantiate culture {0}", e.InvalidCultureName);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }
        }

        public static void  test1 ()
        {
            // Creates and initializes the CultureInfo which uses the international sort.
            CultureInfo myCIintl = new CultureInfo("es-ES", false);

            // Creates and initializes the CultureInfo which uses the traditional sort.
            CultureInfo myCItrad = new CultureInfo(0x040A, false);

            // Displays the properties of each culture.
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "PROPERTY", "INTERNATIONAL", "TRADITIONAL");
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "CompareInfo", myCIintl.CompareInfo, myCItrad.CompareInfo);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "DisplayName", myCIintl.DisplayName, myCItrad.DisplayName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "EnglishName", myCIintl.EnglishName, myCItrad.EnglishName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "IsNeutralCulture", myCIintl.IsNeutralCulture, myCItrad.IsNeutralCulture);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "IsReadOnly", myCIintl.IsReadOnly, myCItrad.IsReadOnly);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "LCID", myCIintl.LCID, myCItrad.LCID);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Name", myCIintl.Name, myCItrad.Name);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "NativeName", myCIintl.NativeName, myCItrad.NativeName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "Parent", myCIintl.Parent, myCItrad.Parent);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "TextInfo", myCIintl.TextInfo, myCItrad.TextInfo);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "ThreeLetterISOLanguageName", myCIintl.ThreeLetterISOLanguageName, myCItrad.ThreeLetterISOLanguageName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "ThreeLetterWindowsLanguageName", myCIintl.ThreeLetterWindowsLanguageName, myCItrad.ThreeLetterWindowsLanguageName);
            Console.WriteLine("{0,-31}{1,-47}{2,-25}", "TwoLetterISOLanguageName", myCIintl.TwoLetterISOLanguageName, myCItrad.TwoLetterISOLanguageName);
            Console.WriteLine();

            // Compare two strings using myCIintl.
            Console.WriteLine("Comparing \"llegar\" and \"lugar\"");
            Console.WriteLine("   With myCIintl.CompareInfo.Compare: {0}", myCIintl.CompareInfo.Compare("llegar", "lugar"));
            Console.WriteLine("   With myCItrad.CompareInfo.Compare: {0}", myCItrad.CompareInfo.Compare("llegar", "lugar"));
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
