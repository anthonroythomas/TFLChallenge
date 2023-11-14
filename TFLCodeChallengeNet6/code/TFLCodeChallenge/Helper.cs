using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management;
using System.Xml.Linq;
using TFLCodeChallengeSpecs.Config;
using TFLCodeChallengeSpecs.Pages;
//using Microsoft.SharePoint.Client;

namespace TFLCodeChallengeSpecs
{
    public static class JsonHelper
    {
        public static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];
        }
        private static JObject GetTestDataJsonObject()
        {
            string path = Path.Combine(GetProjectRootDirectory(), "Data\\Store", "properties.json");
            JObject jObject = JObject.Parse(File.ReadAllText(path));
            return jObject;
        }
        public static int GetTestDataInt(string label)
        {
            label = "title";

            var jObject = GetTestDataJsonObject();
            return int.Parse(jObject[label].ToString());
        }
        public static List<string> GetTestDataArray(string label)
        {
            label = "title";

            var jObject = GetTestDataJsonObject();
            return jObject[label].ToObject<List<string>>(); ;
        }
    }

    public class Helper
    {
        private DriverHelper _driverHelper;

        public Helper(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }

        public static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];
        }

        public static void EnterText(IWebElement webElement, string value) => webElement.SendKeys(value);

        public static void Click(IWebElement webElement) => webElement.Click();

        public static void SelectByValue(IWebElement webElement, string value)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByValue(value);
        }

        public static void SelectByText(IWebElement webElement, string text)
        {
            SelectElement selectElement = new SelectElement(webElement);
            selectElement.SelectByText(text);
        }
        public static char RandomChar(int min, int max)
        {
            //random lowercase letter:
            Random rnd2 = new Random();
            int ascii_index2 = rnd2.Next(min, max); //ASCII character codes 97-123
            char myRandomLowerCase = Convert.ToChar(ascii_index2); //produces any char a-

            return myRandomLowerCase;
        }

        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char c;
            for (int i = 0; i < size; i++)
            {
                c = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(c);
            }

            return builder.ToString();
        }

        public static string B64EncodeDecode(string yourString)
        {
            var urlBytes = Encoding.UTF8.GetBytes(yourString);
            var base64String = Convert.ToBase64String(urlBytes);

            return base64String;
        }

        /// <summary>
        /// Used to switch index to the current
        /// Param takes the current driver instance
        /// </summary>
        /// <param name="Driver"></param>
        //
        public static void SwitchWindowTab(IWebDriver Driver)
        {
            string originalWindow = Driver.CurrentWindowHandle;
            foreach (string window in Driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    Driver.SwitchTo().Window(window);
                    break;
                }
            }
        }

        public static void RunPowerShell(string psname)
        {

            Console.WriteLine("Starting RunPowershell ");
            var currentDir = JsonHelper.GetProjectRootDirectory();

            Console.WriteLine("RunPowershell: Got the current dir ");

            var ps1File = @currentDir + "scripts\\" + psname;

            Console.WriteLine("RunPowershell from :" + ps1File);


            var startInfo = new ProcessStartInfo()
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy ByPass -File \"{ps1File}\"",
                UseShellExecute = false
            };
            Process.Start(startInfo);
        }

    }
}
