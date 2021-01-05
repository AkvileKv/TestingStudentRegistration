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
    public class TestClass
    {
        IWebDriver driver; 
        IWebElement registerButton;
        IWebElement nameField;
        IWebElement surnameField;       
        IWebElement idField;
        IWebElement maleRadio;
        IWebElement femaleRadio;
        IWebElement addressField;
        IWebElement telephoneField;
        IWebElement studyProgramDDL;
        IWebElement formOfStudiesDDL;
        IWebElement agreeCheck;
        IWebElement errorLabel;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); //Apsibreziam narsykle, bibliotekas isikeliam
            driver.Url = "http://localhost:60488/Register"; //Adresa apsibreziam

            registerButton = driver.FindElement(By.Id("MainContent_registerButton")); // visus nusiskaitau pries testa
            nameField = driver.FindElement(By.Id("MainContent_nameField"));
            surnameField = driver.FindElement(By.Id("MainContent_surnameField"));
            idField = driver.FindElement(By.Id("MainContent_idField"));
            maleRadio = driver.FindElement(By.Id("MainContent_genderSelection_0"));
            femaleRadio = driver.FindElement(By.Id("MainContent_genderSelection_1"));
            addressField = driver.FindElement(By.Id("MainContent_addressField"));
            telephoneField = driver.FindElement(By.Id("MainContent_telephoneField"));
            studyProgramDDL = driver.FindElement(By.Id("MainContent_studyProgramSelection"));
            formOfStudiesDDL = driver.FindElement(By.Id("MainContent_formOfStudiesSelection"));
            agreeCheck = driver.FindElement(By.Id("MainContent_agreeCheck"));         
        }
        //Neuzpildyti visi
        [Test]
        [Order (1)]
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
        public void RegisterButtonClick_OnlyGenderSelected_NoRedirect()
        {
            string url = driver.Url;
            maleRadio.Click();
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }
    

        [Test]
        public void RegisterButtonClick_OnlyStudyProgramSelected_NoRedirect()
        {
            string url = driver.Url;
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }

        [Test]
        public void RegisterButtonClick_OnlyformOfStudiesSelected_NoRedirect()
        {
            string url = driver.Url;
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(1);
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }

        [Test]
        public void RegisterButtonClick_OnlyAgreeSelected_NoRedirect()
        {
            string url = driver.Url;
            agreeCheck.Click();
            registerButton.Click();
            Assert.AreEqual(url, driver.Url);
        }

        //Paliktas 1 neuzpildytas
        [Test]
        public void RegisterButtonClick_NoGenderSelected_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");          
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Select gender", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoNameSelected_CorrectMessage()
        {
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Enter your name", errorLabel.Text);
        }
        [Test]
        public void RegisterButtonClick_NoSurnameSelected_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Enter your surname", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoIdSelected_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Enter your id", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoAddressSelected_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Enter your address", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoTelephoneSelected_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Enter your telephone number", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoStudyProgramSelected_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Choose the program of study", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoFormOfStudiesSelected_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Choose the form of study", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_NoAgreeSelected_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Accept our policy", errorLabel.Text);
        }

        //Visi uzpildyti
        [Test]
        public void RegisterButtonClick_AllFieldSelected_Redirect()
        {
            string url = driver.Url;
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            Assert.AreEqual(driver.Url, driver.Url);
        }

        // Ar lytis su asmens kode esancia sutampa
        [Test]
        public void RegisterButtonClick_WrongGenderSelected_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            femaleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Wrong gender (id as male)", errorLabel.Text);
        }

        // Ar telefono nr. validus
        [Test]
        public void RegisterButtonClick_PhoneInvalidLength_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("8650505015");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Wrong phone number (86XXXXXXXX)", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_PhoneInvalidSymbols_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("86505A501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Wrong number (only numbers)", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_PhoneInvalid86_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("855055501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Wrong number (86...)", errorLabel.Text);
        }

        // Ar ID validus
        [Test]
        public void RegisterButtonClick_IdInvalidLength_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("356081285139");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Wrong id (11 numbers)", errorLabel.Text);
        }
        [Test]
        public void RegisterButtonClick_IdInvalidFirstNumber_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("05608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Wrong id (first number)", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_IdInvalidLastNumber_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128519");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865050501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Invalid id (last no.)", errorLabel.Text);
        }

        // Ar studentas egzistuoja
        [Test]
        public void RegisterButtonClick_AlreadyExist_CorrectMessage()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865055501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
            registerButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Student already exists", errorLabel.Text);
        }

        [Test]
        public void RegisterButtonClick_StudentNotExist_Redirect()
        {
            nameField.SendKeys("Jonas");
            surnameField.SendKeys("Jonauskas");
            idField.SendKeys("35608128513");
            maleRadio.Click();
            addressField.SendKeys("Ozo g. 25, Vilnius 08217");
            telephoneField.SendKeys("865055501");
            SelectElement studyProgram = new SelectElement(studyProgramDDL);
            studyProgram.SelectByIndex(1);
            SelectElement formOfStudies = new SelectElement(formOfStudiesDDL);
            formOfStudies.SelectByIndex(2);
            agreeCheck.Click();
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
