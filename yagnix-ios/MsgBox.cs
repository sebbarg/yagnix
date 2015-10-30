using System;
using System.Threading.Tasks;
using UIKit;

namespace Yagnix
{
  public static class MsgBox
  {
    // Displays a UIAlertView and returns the index of the button pressed.
    // int button = await ShowAlert ("Foo", "Bar", "Ok", "Cancel", "Maybe");
    public static Task<int> Show(string title, string message, params string[] buttons)
    {
      var tcs = new TaskCompletionSource<int>();
      var alert = new UIAlertView { Title = title, Message = message };
      foreach ( var button in buttons )
      {
        alert.AddButton(button);
      }
      alert.Clicked += (s, e) => tcs.TrySetResult((int)e.ButtonIndex);
      alert.Show();
      return tcs.Task;
    }
  }


}