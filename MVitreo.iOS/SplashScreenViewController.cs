using System;
using Airbnb.Lottie;
using CoreGraphics;
using MonoTouch.Dialog;
using UIKit;

namespace MVitreo.iOS
{
    public partial class SplashScreenViewController : UIViewController
    {
        public SplashScreenViewController() : base() { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var viewAnimation = LOTAnimationView.AnimationNamed("ironman");
            var boundSize = UIScreen.MainScreen.Bounds.Size;
            viewAnimation.Frame = new CGRect(x: 0, y: 0, width: boundSize.Width, height: boundSize.Height);
            viewAnimation.ContentMode = UIViewContentMode.ScaleAspectFit;

            View.AddSubview(viewAnimation);
            viewAnimation.PlayWithCompletion((finished) =>
            {
                UIApplication.SharedApplication.Delegate.FinishedLaunching(UIApplication.SharedApplication,
                                                                           new Foundation.NSDictionary());
            });
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}
