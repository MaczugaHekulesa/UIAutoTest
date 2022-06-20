using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Mac;
using OpenQA.Selenium.Appium.Service;

namespace PSDemoTest
{
    [TestClass]
    public class UnitTest1

    {
        [TestMethod]

        public void FindElementClass()
        {
            var driver = StartApplication();
            var newDocument = driver.FindElement(MobileBy.IosNSPredicate("**/ XCUIElementTypeImage[`label == 'New Document`]"));
            Thread.Sleep(9999);
            Assert.IsTrue(newDocument.Text == "New Document");
            driver.CloseApp();
        }

        public MacDriver<MacElement> StartApplication()
        {
            Console.WriteLine("cipka");
            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(MobileCapabilityType.App, "TextEdit");
            //capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "10.14.6");
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Mac");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Mac");
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "Mac2");
            //capabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, "10000000");
            //capabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, 99999999);
            //capabilities.AddAdditionalCapability(MobileCapabilityType.AppiumVersion, "2.0.0-beta.30");

            var driver = new MacDriver<MacElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            return driver;


            //var appiumLocalServer = new AppiumServiceBuilder().UsingAnyFreePort().Build();

            //appiumLocalServer.Start();

            //var driver = new MacDriver<MacElement>(appiumLocalServer, capabilities);
            // Thread.Sleep(3000);



        }

    }
}