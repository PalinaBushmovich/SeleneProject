using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleneTestWebProject.Driver
{
    [TestClass]
    public class BaseTest
    {
       public static Browser Browser = Browser.Instance;

        [TestInitialize()]
        public static void SendEmailTestsInitialize(TestContext context)
        {
            Browser = Browser.Instance;
            Browser.WindowMaximize();
            Browser.NavigateTo(Configurations.StartUrl);
        }
      
        [TestCleanup]
        public void CleanUp()
        {
            Browser.Quit();
        }
    }
}
