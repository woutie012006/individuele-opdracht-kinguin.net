namespace UnitTestProject3
{
    using System;
    using kinguin_Clone;
    using kinguin_Clone.classes;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UTRegister
    {
        /// <summary>
        /// This will test the method to register a user, this will need to run during current session
        /// since it needs the Session to store variables
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            Administration admini = new Administration();
            admini.Register("name", "adres", "011011", "aaaa@hotmail.nl", "Password123", "Woop Woop");
            Assert.AreEqual("name".ToUpper(), admini.CurrentUser.Name.ToUpper());
        }
    }
}
