using System;
using System.Threading.Tasks;
using UIKit;

namespace Yagnix
{
  public static class Alert
  {
    // Displays a UIAlertController and returns the index of the button pressed.
    // int button = await ShowAlert ("Foo", "Bar", "Ok", "Cancel", "Maybe");
    public static Task<int> Show(string message, params string[] buttons)
    {
      return Show(null, message, buttons);
    }

    //

    public static Task<int> Show(string message, string button)
    {
      return Show(null, message, new [] { button });
    }

    //

    public static Task<int> Show(string title, string message, params string[] buttons)
    {
      var tcs = new TaskCompletionSource<int>();
      var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
      var window = new UIWindow(UIScreen.MainScreen.Bounds);

      window.RootViewController = new AlertViewController();
      window.BackgroundColor = UIColor.Clear;
      window.WindowLevel = UIWindowLevel.Alert + 1;

      for ( int idx = 0; idx < buttons.Length; idx++ )
      {
        var index = idx;
        alert.AddAction(UIAlertAction.Create(
          buttons[idx], 
          UIAlertActionStyle.Default, 
          action => { 
            tcs.TrySetResult(index);
            window.Hidden = true;
            window.Dispose();
          } 
        ));
      }

      window.MakeKeyAndVisible();
      window.RootViewController.PresentViewController(alert, true, null);

      return tcs.Task;
    }
  }

  //

  internal class AlertViewController : UIViewController 
  {
    public override UIStatusBarStyle PreferredStatusBarStyle()
    {
      return UIApplication.SharedApplication.StatusBarStyle;
    }

    public override bool PrefersStatusBarHidden()
    {
      return UIApplication.SharedApplication.StatusBarHidden;
    }
  }
}

