﻿using Flex;
using Foundation;
using Lottie.Forms.iOS.Renderers;
using UIKit;

namespace ChemQuiz.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Xamarin.Forms.Forms.Init();
            XF.Material.iOS.Material.Init();
            FlexButton.Init();
            AnimationViewRenderer.Init();
            LoadApplication(new App());
            Plugin.InputKit.Platforms.iOS.Config.Init();
            return base.FinishedLaunching(app, options);
        }
    }
}
