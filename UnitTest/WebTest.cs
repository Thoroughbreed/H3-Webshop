using System;
using Xunit;
using DataLayer;
using DataLayer.Models;
using ServiceLayer;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace UnitTest
{
    public class WebTest
    //### Test one:
    //Does it navigate to the correct URL(smoke test)
    //### Test two:
    //Try to add an item to the shopping basket
    //### Test three:
    //Try to navigate to checkout
    //### Test four:
    //Try to add a second item to basket via search
    //### Test five:
    //Try to complete an order with the two items
    //### Test six:
    //Grab the returned order ID and try and locate the previous order
    {
        const string site = "https://localhost:44385";
        const string path = @"C:\Program Files\Mozilla Firefox";

        [Fact]
        public void WebTest_1_NavigatingToURL_SmokeTest()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path);

            using (IWebDriver driver = new FirefoxDriver(service, options))
            {
                driver.Navigate().GoToUrl(site);
                Thread.Sleep(5000);

                Assert.Equal("Vegan Living - Webshop", driver.Title);
                Assert.Equal("https://localhost:44385/", driver.Url);
            }
        }
        [Fact]
        public void WebTest_2_AddItemToBasket()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path);

            using (IWebDriver driver = new FirefoxDriver(service, options))
            {
                driver.Navigate().GoToUrl(site);
                Thread.Sleep(1000);

                IWebElement element = driver.FindElement(By.LinkText("Alle produkter"));
                element.Click();
                Thread.Sleep(500);

                element = driver.FindElement(By.LinkText("Tilføj til kurv"));
                element.Click();
                Thread.Sleep(500);

                element = driver.FindElement(By.TagName("H5"));

                Assert.Equal("1", element.Text);
            }

        }
        [Fact]
        public void WebTest_3_GotoCheckout()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path);

            using (IWebDriver driver = new FirefoxDriver(service, options))
            {
                driver.Navigate().GoToUrl(site);
                Thread.Sleep(1000);

                driver.FindElement(By.LinkText("Alle produkter")).Click();
                Thread.Sleep(500);

                driver.FindElement(By.LinkText("Tilføj til kurv")).Click();
                Thread.Sleep(500);

                driver.FindElement(By.LinkText("Gå til indkøbskurv")).Click();
                Thread.Sleep(150);
                driver.FindElement(By.ClassName("btn-success")).Click();
                IWebElement element = driver.FindElement(By.TagName("H5"));

                Assert.Equal("1", element.Text);
                Assert.Equal("https://localhost:44385/Checkout", driver.Url);
            }
        }
        [Fact]
        public void WebTest_4_AddItemToBasketViaSearch()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path);

            using (IWebDriver driver = new FirefoxDriver(service, options))
            {
                driver.Navigate().GoToUrl(site);
                Thread.Sleep(1000);

                driver.FindElement(By.LinkText("Alle produkter")).Click();
                Thread.Sleep(500);

                driver.FindElement(By.LinkText("Tilføj til kurv")).Click();
                Thread.Sleep(500);

                driver.FindElement(By.LinkText("Fortsæt med at handle")).Click();
                Thread.Sleep(2550);
                driver.FindElement(By.Id("Search")).SendKeys("barista");
                driver.FindElement(By.ClassName("input-group-append")).Click();
                driver.FindElement(By.LinkText("Tilføj til kurv")).Click();

                IWebElement element = driver.FindElement(By.TagName("H5"));
                Assert.Equal("2", element.Text);
            }
        }

        [Fact]
        public void WebTest_5_CompleteOrder()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path);

            using (IWebDriver driver = new FirefoxDriver(service, options))
            {
                driver.Navigate().GoToUrl(site);
                Thread.Sleep(1000);

                driver.FindElement(By.LinkText("Alle produkter")).Click();
                Thread.Sleep(500);

                driver.FindElement(By.LinkText("Tilføj til kurv")).Click();
                Thread.Sleep(500);

                driver.FindElement(By.LinkText("Fortsæt med at handle")).Click();
                Thread.Sleep(2550);
                driver.FindElement(By.Id("Search")).SendKeys("barista");
                driver.FindElement(By.ClassName("input-group-append")).Click();
                driver.FindElement(By.LinkText("Tilføj til kurv")).Click();

                IWebElement element = driver.FindElement(By.TagName("H5"));
                Assert.Equal("2", element.Text);

                driver.FindElement(By.LinkText("Gå til indkøbskurv")).Click();
                driver.FindElement(By.LinkText("Gå til kassen")).Click();
                Assert.Equal("https://localhost:44385/Checkout", driver.Url);

                driver.FindElement(By.Id("Customer_FName")).SendKeys("Selenium");
                driver.FindElement(By.Id("Customer_LName")).SendKeys("Tester");
                driver.FindElement(By.Id("Customer_RoadName")).SendKeys("TestRoad");
                driver.FindElement(By.Id("Customer_RoadNumber")).SendKeys("42");
                driver.FindElement(By.Id("Customer_PostNumber")).SendKeys("6270");
                driver.FindElement(By.Id("Customer_PhoneMain")).SendKeys("12345678");
                driver.FindElement(By.Id("Customer_PhoneMobile")).SendKeys("87654321");
                driver.FindElement(By.Id("Customer_EMail")).SendKeys("sel@eni.um");
                driver.FindElement(By.ClassName("btn-success")).Click();

                Assert.Contains("https://localhost:44385/Success", driver.Url);
            }
        }

        [Fact]
        public void WebTest_6_LocateOrder()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AcceptInsecureCertificates = true;
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(path);

            using (IWebDriver driver = new FirefoxDriver(service, options))
            {
                driver.Navigate().GoToUrl(site);
                Thread.Sleep(1000);

                driver.FindElement(By.LinkText("Alle produkter")).Click();
                Thread.Sleep(500);

                driver.FindElement(By.LinkText("Tilføj til kurv")).Click();
                Thread.Sleep(150);
                driver.FindElement(By.LinkText("Gå til indkøbskurv")).Click();
                driver.FindElement(By.ClassName("fa-plus")).Click();
                driver.FindElement(By.ClassName("fa-plus")).Click();
                driver.FindElement(By.LinkText("Gå til kassen")).Click();
                Thread.Sleep(150);
                IWebElement amount = driver.FindElement(By.TagName("H5"));
                Assert.Equal("https://localhost:44385/Checkout", driver.Url);
                Assert.Equal("3", amount.Text);

                driver.FindElement(By.Id("Customer_FName")).SendKeys("Selenium");
                driver.FindElement(By.Id("Customer_LName")).SendKeys("Tester");
                driver.FindElement(By.Id("Customer_RoadName")).SendKeys("TestRoad");
                driver.FindElement(By.Id("Customer_RoadNumber")).SendKeys("42");
                driver.FindElement(By.Id("Customer_PostNumber")).SendKeys("6270");
                driver.FindElement(By.Id("Customer_PhoneMain")).SendKeys("12345678");
                driver.FindElement(By.Id("Customer_PhoneMobile")).SendKeys("87654321");
                driver.FindElement(By.Id("Customer_EMail")).SendKeys("sel@eni.um");
                driver.FindElement(By.ClassName("btn-success")).Click();

                Assert.Contains("https://localhost:44385/Success", driver.Url);
                Thread.Sleep(500);
                string orderText = driver.FindElement(By.TagName("p")).Text;
                string guid = orderText.Substring(59);

                driver.Navigate().GoToUrl("https://localhost:44385/Admin/OrderDetail?guid=" + guid);

                IWebElement element = driver.FindElement(By.ClassName("text-center"));

                Assert.Contains("OMRÅDE", element.Text);
                Thread.Sleep(1000);
            }
        }
    }
}