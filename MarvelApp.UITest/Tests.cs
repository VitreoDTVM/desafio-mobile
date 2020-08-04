using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MarvelApp.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;
        AppQuery CollectionView;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
            
        }

        [Test]
        [Category("Campo de buscas")]
        public void WelcomeTextIsDisplayed()
        {
            // app.WaitForNoElement("heroescollectionview","", TimeSpan.FromSeconds(20));

            app.EnterText("SearchView", "Bomb");
            app.PressEnter();
            app.Screenshot("Procurar Bomb");
             Task.Delay(250);



        }
        //[Test]
        //[Category("Scroll Collection View")]

        public void IndexCollectionView(int Position)
        {
            app.ScrollDownTo(Position.ToString(), "", ScrollStrategy.Gesture, 0.67, 500, true, TimeSpan.FromSeconds(10000));            
            //app.ScrollTo(heroescollectionview);
        }
        [Test]

        public async Task NextView()
        {
            app.Tap("ImagePath");
            await Task.Delay(3000);
            app.Screenshot("Próxima View");

            app.Back();
        }
        [Test]
        public void BackView()
        {
            app.Back();
            app.Screenshot("View Anterior");
        }
        [Test]
        [Category("Nova funcionalidade")]
        public void ScreenLandscape()
        {
            app.SetOrientationLandscape();
            app.Screenshot("Tela na Horizontal");
        }
        [Test]
        [Category("Nova funcionalidade")]
        public void ScreenPortrait()
        {
            app.SetOrientationPortrait();
            app.Screenshot("Tela na Vertical");
        }
    }
}
