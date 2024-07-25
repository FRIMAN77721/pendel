using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;

namespace pendel.AutomatedBroswer
{
    class AutomatedFireFox
    {

        /*
        *  Данный класс отвечает за создание объекта браузера и его настройку
        */

        public FirefoxDriver CurrentBrowser { get; }
        public AutomatedFireFox()
        {
            /*
             * код инициализации браузера, применяет к нему настройки, указанные в AutomatedFireFoxSettings
             */

            this.CurrentBrowser = new FirefoxDriver(AutomatedFireFoxSettings.OptionsSetup());
        }
    }
}
