using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;

namespace PSDemoTest
{
    [TestClass]
    public class iOSTest
    {
        static TestContext ctx;

        [ClassInitialize]
        static public void Initialize(TestContext context)
        {
            ctx = context;
        }

        [TestMethod]
        public void ChangeToNextCategory()
        {
            IOSDriver<IOSElement> driver = StartApp();

            //tap on "Przystawki"

            var el1 = driver.FindElementByIosClassChain("**/XCUIElementTypeWindow/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther/XCUIElementTypeOther[2]/XCUIElementTypeOther[2]/XCUIElementTypeOther[2]/XCUIElementTypeOther[2]/XCUIElementTypeButton[1]");
            el1.Click();
            var el2 = driver.FindElementByIosClassChain(@"**/XCUIElementTypeTextField[elementId == ""4A000000-0000-0000-716B-000000000000""]");
            el2.Click();
            el2.Clear();
            el2.SendKeys("dupa");

            var el3 = driver.FindElementByAccessibilityId("Brak wyników wyszukiwania");

            var txt = el3.Text;
            Assert.IsTrue(txt == "Brak wyników wyszukiwania");
            

            driver.CloseApp();

        }
   
        private static IOSDriver<IOSElement> StartApp()
        {
            System.Environment.SetEnvironmentVariable("DEVELOPER_DIR", @"/Applications/Xcode.app");

            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability(IOSMobileCapabilityType.BundleId, "pl.cobytu");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "iOS");
            capabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "iPhone (Adam)");
            capabilities.AddAdditionalCapability(MobileCapabilityType.AutomationName, "XCUITest");
            capabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "15.4");
            capabilities.AddAdditionalCapability(MobileCapabilityType.Udid, "68eecee289eb2aca4ecb31146650daeff7acab60");
            capabilities.AddAdditionalCapability("appium:xcodeOrgId", "9E7D3Y488N");
            capabilities.AddAdditionalCapability("appium:xcodeSigningId", "iPhone Developer");
            capabilities.AddAdditionalCapability("appium:updateWDABundleId", "pl.cobytu.cb");
            capabilities.AddAdditionalCapability(MobileCapabilityType.NoReset, "false");
            capabilities.AddAdditionalCapability(MobileCapabilityType.NewCommandTimeout, "1000");
            var driver = new IOSDriver<IOSElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            return driver;
        }

    }
}
