using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace pendel.AutomatedBroswer
{
    public static class AutomatedFireFoxSettings
    {
        /*
           Статический класс с функцией конфигурации
         */
        public static FirefoxOptions OptionsSetup()
        {

            var settings = new FirefoxProfile();
            var binary = @"Mozilla Firefox\firefox.exe";// указываем путь к исполняемому файлу браузера
            settings.SetPreference("browser.download.folderList", 2);
            settings.SetPreference("browser.download.manager.shoWhenStarting", false);
            settings.SetPreference("browser.download.dir", Environment.CurrentDirectory+ @"\PO");
            settings.SetPreference("browser.helperApps.neverAsk.saveToDisk", "text/csv");
            return new FirefoxOptions() { Profile = settings, BrowserExecutableLocation = binary };// применяем настройки для профиля браузера , и запуск из пути к исполняемому файлу
        }
    }
}
