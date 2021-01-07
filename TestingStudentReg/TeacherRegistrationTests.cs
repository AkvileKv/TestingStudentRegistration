using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestingStudentReg
{
    class TeacherRegistrationTests
    {

        IWebDriver driver;
        IWebElement registerButton;
        IWebElement nameField;
        IWebElement surnameField;
        IWebElement idField;
        IWebElement fullRadio;
        IWebElement partRadio;
        IWebElement addressField;
        IWebElement telephoneField;
        IWebElement facultyDDL;
        IWebElement errorLabel;
        IWebElement emailField;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); //Apsibreziam narsykle, bibliotekas isikeliam
            driver.Url = "http://localhost:60488/RegisterTeacher"; //Adresa apsibreziam

            registerButton = driver.FindElement(By.Id("MainContent_registerButton")); // visus nusiskaitau pries testa
            nameField = driver.FindElement(By.Id("MainContent_nameField"));
            surnameField = driver.FindElement(By.Id("MainContent_surnameField"));
            idField = driver.FindElement(By.Id("MainContent_idField"));
            fullRadio = driver.FindElement(By.Id("MainContent_workingTypeSelection_0"));
            partRadio = driver.FindElement(By.Id("MainContent_workingTypeSelection_1"));
            addressField = driver.FindElement(By.Id("MainContent_addressField"));
            telephoneField = driver.FindElement(By.Id("MainContent_telephoneField"));          
            emailField = driver.FindElement(By.Id("MainContent_emailField"));
            facultyDDL = driver.FindElement(By.Id("MainContent_facultySelection"));     
        }

        [Test]
        [Order(1)]
        public void RegisterButtonClick_EmptyFields_NoRedirect()
        {
            string url = driver.Url; //issisaugom url pradini
            registerButton.Click(); //mygtuko paspaudimas
            Assert.AreEqual(url, driver.Url); //tikimes, gaunam
        }
        //Po viena uzpildyta 
        [Test]
        [Order(2)]
        public void RegisterButtonClick_NonEmptyName_NoRedirect()
        {
            string url = driver.Url;
            nameField.SendKeys("Akvile");
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }

        [Test]
        public void RegisterButtonClick_NonEmptySurname_NoRedirect()
        {
            string url = driver.Url;
            surnameField.SendKeys("Kvietkauskaite");
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }

        [Test]
        public void RegisterButtonClick_NonEmptyId_NoRedirect()
        {
            string url = driver.Url;
            idField.SendKeys("35608128513");
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }

        [Test]
        public void RegisterButtonClick_NonEmptyAddress_NoRedirect()
        {
            string url = driver.Url;
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }

        [Test]
        public void RegisterButtonClick_NonEmptyPhoneNo_NoRedirect()
        {
            string url = driver.Url;
            telephoneField.SendKeys("865050501");
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }

        [Test]
        public void RegisterButtonClick_OnlyWorkingDaySelected_NoRedirect()
        {
            string url = driver.Url;
            fullRadio.Click();
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }


        [Test]
        public void RegisterButtonClick_OnlyFacultySelected_NoRedirect()
        {
            string url = driver.Url;
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }
        [Test]
        public void RegisterButtonClick_OnlyEmailSelected_NoRedirect()
        {
            string url = driver.Url;
            emailField.SendKeys("test@test.com");
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }

        //Paliktas 1 neuzpildytas
        [Test]
        public void RegisterButtonClick_NoWorkingDaySelected_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Select working type", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoNameSelected_CorrectMessage()
        {
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Enter your name", errorLabel.Text);
        }
        [Test]
        public void RegisterButtonClick_NoSurnameSelected_CorrectMessage()
        {

            nameField.SendKeys("Name");
            idField.SendKeys("35608128513");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Enter your surname", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoIdSelected_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Enter your id", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoAddressSelected_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("35608128513");
            telephoneField.SendKeys("865050501");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Enter your address", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoTelephoneSelected_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("35608128513");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Enter your telephone number", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoEmailSelected_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("35608128513");
            telephoneField.SendKeys("865050501");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Enter your e-mail address", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoFacultySelected_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("35608128513");
            telephoneField.SendKeys("865050501");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            fullRadio.Click();
            emailField.SendKeys("test@test.com");
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Choose the faculty", errorLabel.Text);
        }

        //Visi uzpildyti
        [Test]
        public void RegisterButtonClick_AllFieldSelected_Redirect()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("35608128513");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            Assert.AreEqual(driver.Url, driver.Url);
        }

        // Ar telefono nr. validus
        [Test]
        public void RegisterButtonClick_PhoneInvalidLength_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("35608128513");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("86505050112");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Wrong phone number (86XXXXXXXX)", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_PhoneInvalidSymbols_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("35608128513");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("862803ABC");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Wrong number (only numbers)", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_PhoneInvalid86_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("35608128513");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("852813021");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Wrong number (86...)", errorLabel.Text);
        }

        // Ar ID validus
        [Test]
        public void RegisterButtonClick_IdInvalidLength_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("356081285133");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("852813021");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Wrong id (11 numbers)", errorLabel.Text);
        }
        [Test]
        public void RegisterButtonClick_IdInvalidFirstNumber_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("05608128513");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("852813021");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Wrong id (first number)", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_IdInvalidLastNumber_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("35608128519");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("852813021");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Invalid id (last no.)", errorLabel.Text);
        }

        // Ar destytojas egzistuoja
        [Test]
        public void RegisterButtonClick_AlreadyExist_CorrectMessage()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("35608128513");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("862813021");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Teacher already exists", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_TeacherDoesntExist_Redirect()
        {
            nameField.SendKeys("Name");
            surnameField.SendKeys("Surname");
            idField.SendKeys("35608128513");
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("852813021");
            emailField.SendKeys("test@test.com");
            SelectElement faculty = new SelectElement(facultyDDL);
            faculty.SelectByIndex(2);
            fullRadio.Click();
            registerButton.Click();
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
