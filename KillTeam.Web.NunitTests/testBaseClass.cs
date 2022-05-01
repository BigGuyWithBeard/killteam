using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace KillTeam.Web.NunitTests
{
 public abstract class TestBaseClass
    {

        // good intro for selenium: https://www.toolsqa.com/selenium-c-sharp/
        // https://www.lambdatest.com/blog/setting-up-selenium-in-visual-studio/

        protected string baseUrl = "https://killteam.azurewebsites.net"; // this will only be good AFTER deployment.
        protected IWebDriver driver;
        private bool testCrudMethods;

        protected TestBaseClass(string controllerBaseUrl, bool testCrudMethods = false)
        {
            baseUrl = $"{baseUrl}{controllerBaseUrl}";
            this.testCrudMethods = testCrudMethods;
        }
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }


        private void PageTests()
        {
            // chrome 404 message:
            if (driver.PageSource.Contains("No web page was found for the web address:"))
            {
                Assert.Fail("HTTP 404 Error");
            }

        }
        #region CRUD Operations

        



        [Test]
        public void GetDetails()
        {

            if (testCrudMethods)
            {

          driver.Url = $"{baseUrl}/Details"; 
                
                PageTests();


                string title = driver.Title;

               Assert.AreEqual("Find My Stuff", title, $"Title is not ok: {driver.Url}");
            Assert.Inconclusive();
            }
      
        }

        [Test]
        public void GetCreate()
        {

            if (testCrudMethods)
            {
            driver.Url = $"{baseUrl}/Create";

            PageTests();

            string title = driver.Title;

            Assert.AreEqual("Find My Stuff", title, $"Title is not ok: {driver.Url}");
            Assert.Inconclusive();
            }


        }



        [Test]
        public void GetEditId()
        {

            if (testCrudMethods)
            {
            //    driver.Url = $"{baseUrl}";
            
            PageTests();

            //    string title = driver.Title;

            //    Assert.AreEqual("Find My Stuff", title, $"Title is not ok: {driver.Url}");
            Assert.Inconclusive();
            }


        }

        [Test]
        public void GetDeleteId()
        {

            if (testCrudMethods)
            {
            //    driver.Url = $"{baseUrl}";
            
            PageTests();

            //    string title = driver.Title;

            //    Assert.AreEqual("Find My Stuff", title, $"Title is not ok: {driver.Url}");
            Assert.Inconclusive();
            }



        }






        [Test]
        public void PostCreate()
        {

            if (testCrudMethods)
            {
            //    driver.Url = $"{baseUrl}";
            
            PageTests();

            //    string title = driver.Title;

            //    Assert.AreEqual("Find My Stuff", title, $"Title is not ok: {driver.Url}");
            Assert.Inconclusive();
            }


        }



        [Test]
        public void PostEdit()
        {
            if (testCrudMethods)
            {
       //    driver.Url = $"{baseUrl}";
       
       PageTests();

            //    string title = driver.Title;

            //    Assert.AreEqual("Find My Stuff", title, $"Title is not ok: {driver.Url}");
            Assert.Inconclusive();
            }
     
        }



        [Test]
        public void PostDelete()
        {
            if (testCrudMethods)
            {
           //    driver.Url = $"{baseUrl}";
           
           PageTests();

            //    string title = driver.Title;

            //    Assert.AreEqual("Find My Stuff", title, $"Title is not ok: {driver.Url}");
            Assert.Inconclusive();
            }

 
        }



        #endregion
        //[Test]
        //public void GetHomePage()
        //{
        //    driver.Url = baseUrl;
        //    string title = driver.Title;
        //    string url = driver.Url;
        //    string pageSource = driver.PageSource;


        //    //IWebElement webElement = driver.FindElement(By.XPath(".//*[@id='tabs-1']/div/p/a"));
        //    //webElement = driver.FindElement(By.LinkText("ToolsQA"));
        //    //webElement.Clear(); // clears content on text elements
        //    //webElement.SendKeys("hello");

        //    //// if element exists, Displayed will return true and throw a NoSuchElementFound exception
        //    //bool isVisible = webElement.Displayed;
        //    //bool isEnabled = webElement.Enabled;
        //    //bool isSelected = webElement.Selected;// for checkboxes, select options and radio buttons


        //    //webElement.Click();
        //    //webElement.Submit(); // use for submitting a form. works better than click on the submit button apparently.
        //    //string visibleInnerText = webElement.Text; // visible as in, not hidden by css
        //    //string tagName = webElement.TagName;
        //    //string cssBackgroundColor = webElement.GetCssValue("background-color");
        //    //string attributeId = webElement.GetAttribute("id");
        //    //System.Drawing.Size size = webElement.Size;
        //    //System.Drawing.Point location = webElement.Location;


        //}

    }
}
