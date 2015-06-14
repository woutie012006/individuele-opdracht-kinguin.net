using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kinguin_Clone;
using kinguin_Clone.classes;
namespace UnitTestProject2
{
    using System.ComponentModel;

    [TestClass]
    public class UTLogin
    {
        /// <summary>
        /// This will test the method to login a user, this will need to run during current session
        /// since it needs the Session to store variables
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            Administration admini = new Administration();
            admini.Login("a@k.nl","Password123");

            Assert.AreEqual("a@k.nl", admini.CurrentUser.Email);

            
        }
    }
}
