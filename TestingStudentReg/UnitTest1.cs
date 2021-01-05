using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TestingStudentReg
{
    public class Tests
    {
            [Test]
        public void Test1()
        {
            IWebDriver driver = new ChromeDriver(); //Apsibreziam narsykle, bibliotekas isikeliam
            driver.Url = "http://localhost:60488/Register"; //Adresa apsibreziam

            IWebElement element = driver.FindElement(By.Id("MainContent_nameField")); //Nuskaitom lauka
            element.SendKeys("Akvile"); //Siunciu jam teksta

            string url = driver.Url; //issisaugom url pradini

            IWebElement button = driver.FindElement(By.Id("MainContent_registerButton")); //mygtuka nurodom
            button.Click(); //mygtuko paspaudimas

            // ar po click ivyko redirektinimas (ar pasikeite narsykles url)
            Assert.AreEqual(url, driver.Url); //tikimes, gaunam

            //Matymui, kas vyksta. Paskui uzdarom
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}