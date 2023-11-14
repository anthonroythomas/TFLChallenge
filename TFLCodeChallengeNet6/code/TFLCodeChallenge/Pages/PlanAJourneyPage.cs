using OpenQA.Selenium;
using System.Text;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Newtonsoft.Json;
using System.IO;
using System.Drawing.Drawing2D;
using AngleSharp.Css.Values;

namespace TFLCodeChallengeSpecs.Pages
{

    public class PlanAJourneyPage 
    {

        Helper helper;

        private IWebDriver Driver;

        public PlanAJourneyPage(IWebDriver driver)
        {
            Driver = driver;
            //word = new Word(driver);
        }

        //Source and Destination
        IWebElement sourceTextBox => Driver.FindElement(By.XPath("//*[@id='InputFrom']"));
        IWebElement destinationTextBox => Driver.FindElement(By.XPath("//*[@id='InputTo']"));

        IWebElement btnPlanJourney => Driver.FindElement(By.XPath("//*[@id='plan-journey-button']"));

        IWebElement sourceTextError => Driver.FindElement(By.XPath("//*[@id='InputFrom-error']"));

        IWebElement destinationTextError => Driver.FindElement(By.XPath("//*[@id='InputTo-error']"));

        IWebElement btnChangeTime => Driver.FindElement(By.XPath("//*[@class='change-departure-time']"));

        IWebElement btnArriving => Driver.FindElement(By.XPath("//*[@id='arriving']"));

        IWebElement timeSelect => Driver.FindElement(By.XPath("//*[@id='Time']"));

        IWebElement arrivingText => Driver.FindElement(By.XPath("//*[@for='arriving']"));


        //Cookies
        IWebElement cookieAccept => Driver.FindElement(By.XPath("//*[@id='CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll']"));

        //Header
        IWebElement TitleHeader => Driver.FindElement(By.XPath("//*[@class='headline-container']"));

        //Recents
        IWebElement recentsTab => Driver.FindElement(By.XPath("//*[@id='jp-recent-tab-jp']"));

        IWebElement recentContent => Driver.FindElement(By.XPath("//*[@id='jp-recent-content-jp-']"));

        IWebElement recentJourney0 => Driver.FindElement(By.XPath("//*[@data-journey-type='recent'][1]"));


        public bool GetSourceError()
        {
          bool result =  sourceTextError.Displayed;

            return result;
        }

        public bool GetDestError()
        {
            bool result = destinationTextError.Displayed;

            return result;
        }

        public void EnterSourceDestination(string source, string destination)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(sourceTextBox));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Source Text Box failed to load '{e}'");
                throw;
            }

            //sourceTextBox.Click();
            sourceTextBox.SendKeys(source);

            //Forced wait to slow down test for review purposes
            Thread.Sleep(1000);

            //destinationTextBox.Click();
            destinationTextBox.SendKeys(destination);

            //Forced wait to slow down test for review purposes
            Thread.Sleep(1000);

            //Hack to overcome click interception with submit box
            TitleHeader.Click();

        }

        public void AcceptCookies()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(cookieAccept));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Source Text Box failed to load '{e}'");
                throw;
            }

            cookieAccept.Click();

            //Forced wait to slow down test for review purposes
            Thread.Sleep(1000);
        }

        public void SubmitJourney()
        {
            btnPlanJourney.Click();
        }

        public void ChangeTime(string time)
        {

            btnChangeTime.Click();

            Assert.IsTrue(arrivingText.Text.Equals("Arriving"));
            btnArriving.Click();

            //Forced wait to slow down test for review purposes
            Thread.Sleep(1000);

            var selectElement = timeSelect;
            var select = new SelectElement(selectElement);

            select.SelectByValue(time);

            //Forced wait to slow down test for review purposes
            Thread.Sleep(1000);

        }

        public void SelectRecentJourney()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            Assert.IsTrue(recentsTab.Displayed);
            recentsTab.Click();

            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(recentContent));

                    if (recentContent.Text.Contains("no recent journeys"))
                    {
                        Console.WriteLine("No recent journeys, ending test");
                    }
                    else 
                    {
                    recentJourney0.Click();
                    }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Source Text Box failed to load '{e}'");
                throw;
            }       

        }




    }
}

