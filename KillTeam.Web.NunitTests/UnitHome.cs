using NUnit.Framework;

namespace KillTeam.Web.NunitTests
{
    public class UnitHome: TestBaseClass

    {

        public UnitHome() : base("", false) {}


        [Test]
        public void GetIndex()
        {
            driver.Url = $"{baseUrl}";
            string title = driver.Title;

            Assert.AreEqual("Kill Team", title, "Title is not ok");
        }

        [Test]
        public void GetPrivacy()
        {
            driver.Url = $"{baseUrl}/home/privacy";
            string title = driver.Title;

            Assert.AreEqual("Privacy Policy | Kill Team", title, "Title is not ok");

        }

    }
}