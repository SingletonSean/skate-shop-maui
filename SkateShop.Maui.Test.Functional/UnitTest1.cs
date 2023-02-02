using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace SkateShop.Maui.Test.Functional
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            AppiumOptions options = new AppiumOptions();

            options.AddAdditionalCapability("app", @"C:\Storage\VS Repos\YouTube\SkateShop\SkateShop.Maui\bin\Debug\net6.0-windows10.0.19041.0\win10-x64\publish\SkateShop.Maui.exe");

            var driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options, TimeSpan.FromSeconds(5));
            
            driver.FindElementByAccessibilityId("cbAgreeToTerms").Click();
            driver.FindElementByAccessibilityId("btnCheckout").Click();

            driver.Close();
        }
    }
}