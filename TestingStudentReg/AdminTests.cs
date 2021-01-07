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
    class AdminTests
    {
        IWebDriver driver;
        IWebElement teacherListBox;
        IWebElement subjectsListBox;
        IWebElement selectedTeacherListBox;
        IWebElement selectedSubjectsListBox;
        IWebElement selectTeacherButton;
        IWebElement addSubjectButton;
        IWebElement removeTeacherButton;
        IWebElement removeSubjectButton;
        IWebElement confirmAllButton1;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver(); //Apsibreziam narsykle, bibliotekas isikeliam
            driver.Url = "http://localhost:60488/Admin"; //Adresa apsibreziam

            selectTeacherButton = driver.FindElement(By.Id("MainContent_selectTeacherButton")); // visus nusiskaitau pries testa
            addSubjectButton = driver.FindElement(By.Id("MainContent_addSubjectButton"));
            removeTeacherButton = driver.FindElement(By.Id("MainContent_removeTeacherButton"));
            removeSubjectButton = driver.FindElement(By.Id("MainContent_removeSubjectButton"));
            confirmAllButton1 = driver.FindElement(By.Id("MainContent_confirmAllButton1"));
            teacherListBox = driver.FindElement(By.Id("MainContent_teacherListBox"));
            subjectsListBox = driver.FindElement(By.Id("MainContent_subjectsListBox"));
            selectedTeacherListBox = driver.FindElement(By.Id("MainContent_selectedTeacherListBox"));
            selectedSubjectsListBox = driver.FindElement(By.Id("MainContent_selectedSubjectsListBox"));
        }

        [Test]
        public void addTeacherButtonClick_NothingSelected_ErrorMsg()
        {
            selectTeacherButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Please select Teacher", errorLabel.Text);
        }
        [Test]
        public void addSubjectButtonClick_NothingSelected_ErrorMsg()
        {
            addSubjectButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Please select Subject", errorLabel.Text);
        }
        [Test]
        public void removeTeacherButtonClick_NothingSelected_ErrorMsg()
        {
            removeTeacherButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Please select Teacher", errorLabel.Text);
        }

        [Test]
        public void addTeacherButtonClick_TeacherSelected_AddedToList()
        {
            SelectElement teacher = new SelectElement(teacherListBox);
            teacher.SelectByIndex(2);
            selectTeacherButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("", errorLabel.Text);
        } 
   
        [Test]
        public void addSubjectButtonClick_SubjectSelected_AddedToList()
        {
            SelectElement subject = new SelectElement(subjectsListBox);
            subject.SelectByIndex(2);
            addSubjectButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("", errorLabel.Text);
        } 
/*
        [Test]
        public void addTeacherButtonClickTwice_TeacherAlreadySelected_ErrorMsg()
        {
            SelectElement teacher = new SelectElement(teacherListBox);
            teacher.SelectByIndex(1);
            selectTeacherButton.Click();         
            teacher.SelectByIndex(1);
            selectTeacherButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("Only one selection", errorLabel.Text);
        }

        [Test]
        public void removeTeacherButtonClick_TeacherRemoved_RemovedFromList()
        {
            SelectElement teacher = new SelectElement(selectedTeacherListBox);     
            teacher.SelectByIndex(1);
            removeTeacherButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("", errorLabel.Text);
        } 

        [Test]
        public void removeSubjectButtonClick_SubjectRemoved_RemovedFromList()
        {
            SelectElement subject = new SelectElement(subjectsListBox);
            subject.SelectByIndex(2);
            addSubjectButton.Click();
            SelectElement subject2 = new SelectElement(selectedSubjectsListBox);
            subject2.SelectByIndex(1);
            removeSubjectButton.Click();
            IWebElement errorLabel = driver.FindElement(By.Id("MainContent_errorLabel"));
            Assert.AreEqual("", errorLabel.Text);
        } 
        
        [Test]
        public void confirmAllButton1Click_TeacherAndSubjectsRegistered_Redirect()
        {
            SelectElement teacher = new SelectElement(teacherListBox);
            teacher.SelectByIndex(2);
            selectTeacherButton.Click();
            SelectElement subject = new SelectElement(subjectsListBox);
            subject.SelectByIndex(2);
            addSubjectButton.Click();
            confirmAllButton1.Click();
            Assert.AreEqual(driver.Url, driver.Url);
        }
        */
        [TearDown]
        public void Shutdown()
        {
            //Matymui kas vyksta. Paskui uzdarom
            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
