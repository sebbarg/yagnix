using System;
using UIKit;
using Yagnix;
using Yagnix.YxGestures;

namespace YxGesturestest
{
  public class YxGesturesController : UIViewController
  {
    public YxGesturesController()
    {
      Console.WriteLine($"Version {UIDevice.CurrentDevice.SystemVersion}");
    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();

      var view = View.Add<UIView>();
      view.FitToGuides(this, 100);
      view.BackgroundColor = UIColor.Blue;
      view.UserInteractionEnabled = true;


//      var onTouch = new Action( () => {
//        Console.WriteLine("Touch!");
//      });
    
      var onTouch = new Action<TouchDownGestureRecognizer>( (gesture) => {
        var pt = gesture.LocationInView(gesture.View);
        Console.WriteLine($"X: {pt.X}");
      });

      var downGesture = new TouchDownGestureRecognizer(onTouch);

      view.AddGestureRecognizer(downGesture);
    }
  }
}

