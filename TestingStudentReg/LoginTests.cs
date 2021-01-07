using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestingStudentReg
{
    class LoginTests
    {
        IWebDriver driver;
        IWebElement loginButton;
        IWebElement usernameField;
        IWebElement passwordField;




        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); //Apsibreziam narsykle, bibliotekas isikeliam
            driver.Url = "http://localhost:60488/Login"; //Adresa apsibreziam

            loginButton = driver.FindElement(By.Id("MainContent_loginButton")); // visus nusiskaitau pries testa
            passwordField = driver.FindElement(By.Id("MainContent_passwordField"));
            usernameField = driver.FindElement(By.Id("MainContent_usernameField"));
        }

        [Test]
        public void LoginButtonClick_NonEmptySurname_NoRedirect()
        {
            string url = driver.Url; //issisaugom url pradini
            loginButton.Click(); //mygtuko paspaudimas
            Assert.AreEqual(url, driver.Url); //tikimes, gaunam
        }

        [Test]
        public void LoginButtonClick_EmptyPassword_NoRedirect()
        {
            string url = driver.Url;
            usernameField.SendKeys("username");
            loginButton.Click();
            Assert.AreEqual(url, driver.Url);
        }
        [Test]
        public void LoginButtonClick_EmptyUsername_NoRedirect()
        {
            string url = driver.Url;
            passwordField.SendKeys("password");
            loginButton.Click();
            Assert.AreEqual(url, driver.Url);
        }
        [Test]
        public void LoginButtonClick_InvalidCredentials_NoRedirect()
        {
            string url = driver.Url;
            usernameField.SendKeys("username");
            passwordField.SendKeys("password");
            loginButton.Click();
            Assert.AreEqual(url, driver.Url);
        }
        [Test]
        public void LoginButtonClick_ValidCredentials_Redirect()
        {
            string url = driver.Url;
            usernameField.SendKeys("admin");
            passwordField.SendKeys("admin");
            loginButton.Click();
            Assert.AreEqual(driver.Url, driver.Url);
        }

        [TearDown]
        public void Shutdown()
        {
            //Matymui kas vyksta. Paskui uzdarom
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
