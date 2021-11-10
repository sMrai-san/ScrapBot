using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace AMDScrapBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the Chrome Driver
            using (var driver = new ChromeDriver())
            {
                //********************************
                //SEARCH STRING HERE
                //********************************
                string searchProduct = "6600";
                bool productFound = false;

                // Go to the AMD directbuy page
                driver.Manage().Window.Minimize();
                driver.Navigate().GoToUrl("https://www.amd.com/en/direct-buy/fi");

                //Wait until page is loaded (3s should be enough)
                Thread.Sleep(3000);

                //Get text from products available
                var result = driver.FindElements(By.ClassName("direct-buy"));

                //Loop the page!
                foreach (var i in result)
                {
                    //If there is specific product leave console open else shutdown console:
                    if (i.Text.Contains(searchProduct))
                    {
                        Console.Clear();
                        Console.WriteLine("***************************************************************************");
                        Console.WriteLine("ISFOUND\nManual ordering required ---> https://www.amd.com/en/direct-buy/fi");
                        Console.WriteLine("***************************************************************************\n");
                        Console.WriteLine("*******************************");
                        Console.WriteLine(DateTime.Now.ToString());
                        Console.WriteLine(i.Text.ToString());
                        Console.WriteLine("*******************************");
                        productFound = true;

                        //CLICK OPTIONAL (not working in current page, maybe useful in some other site...):
                        //Thread.Sleep(3000);

                        //var btnCookies = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
                        //javaScriptExecutor.ExecuteScript("arguments[0].click();", btnCookies);

                        //Thread.Sleep(3000);

                        //var btnOrder = i.FindElement(By.ClassName("btn-shopping-cart"));
                        ////javaScriptExecutor.ExecuteScript("arguments[0].click();", btnOrder);
                        //btnOrder.Click();

                        //Thread.Sleep(3000);

                        //var btnCap = driver.FindElement(By.ClassName("recaptcha-checkbox-border"));
                        //javaScriptExecutor.ExecuteScript("arguments[0].click();", btnCap);
                        //var btnRobot = driver.FindElement(By.Id("confirm-add-to-cart-btn"));
                        //javaScriptExecutor.ExecuteScript("arguments[0].click();", btnRobot);
                        

                        //i.FindElement(By.ClassName("btn-shopping-cart")).Click();

                        Console.ReadLine();
                    }
                    else
                    {
                        //product not found
                    }
                }
                //not found
                if (!productFound)
                {
                    Console.WriteLine("The product " + searchProduct + " was not found!");
                    Console.WriteLine("Searched site: https://www.amd.com/en/direct-buy/fi");
                }
            }
        }




    }
}
