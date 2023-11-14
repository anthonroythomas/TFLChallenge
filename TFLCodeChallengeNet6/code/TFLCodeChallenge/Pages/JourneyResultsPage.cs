using OpenQA.Selenium;
using System.Text;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TFLCodeChallengeSpecs.Pages
{

    public class JourneyResultsPage
    {

        Helper helper;

        private IWebDriver Driver;

        public JourneyResultsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        //Header
        IWebElement journeyResultsHeader => Driver.FindElement(By.XPath("//*[@class='jp-results-headline']"));

        IWebElement journeyResultsErrorText => Driver.FindElement(By.XPath("//*[@class='field-validation-error']"));

        IWebElement journeySummary => Driver.FindElement(By.XPath("//*[@id='journey-summary-data']"));

        IWebElement btnEditJourney => Driver.FindElement(By.XPath("//*[@class='edit-journey']"));

        IWebElement selectTime => Driver.FindElement(By.XPath("//*[@id='Time']"));

        IWebElement btnUpdateJourney => Driver.FindElement(By.XPath("//*[@id='plan-journey-button']"));


        public string GetTitle()
        {
            Console.WriteLine(journeyResultsHeader.Text);
            return journeyResultsHeader.Text;
        }

        public string GetErrorText()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(journeyResultsErrorText));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error text box failed to load '{e}'");
                throw;
            }


            Console.WriteLine(journeyResultsErrorText.Text);
            return journeyResultsErrorText.Text;
        }

        public bool VerifyJourneySummary()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(40));
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(journeySummary));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Journey summary box failed to load '{e}'");
                throw;
            }
            bool summary = journeySummary.Displayed;

            return summary;
        }

        public void EditJourney()
        {
            btnEditJourney.Click();

            Thread.Sleep(4000);

            var selectElement = selectTime;
            var select = new SelectElement(selectElement);

            select.SelectByValue("2330");

            btnUpdateJourney.Click();

        }






    }
}

