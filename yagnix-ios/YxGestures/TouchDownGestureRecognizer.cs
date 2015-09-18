using System;
using UIKit;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace Yagnix.YxGestures
{
  public class TouchDownGestureRecognizer : UIGestureRecognizer
  {
    private readonly Action<TouchDownGestureRecognizer> _action;

    public TouchDownGestureRecognizer(Action action) : base(action)
    {
    }

    //

    public TouchDownGestureRecognizer(Action<TouchDownGestureRecognizer> action)
    {
      _action = action;

      AddTarget(() => {
        if (State == UIGestureRecognizerState.Recognized)
        {
          if (_action != null)
          {
            _action(this);
          }
        }
      });
    }

    //

    public override void TouchesBegan(NSSet touches, UIEvent evt)
    {
      base.TouchesBegan(touches, evt);
      if ( State == UIGestureRecognizerState.Possible )
        State = UIGestureRecognizerState.Recognized;
    }

    //

    public override void TouchesCancelled(NSSet touches, UIEvent evt)
    {
      base.TouchesCancelled(touches, evt);
      State = UIGestureRecognizerState.Failed;
    }

    //

    public override void TouchesMoved(NSSet touches, UIEvent evt)
    {
      base.TouchesMoved(touches, evt);
      State = UIGestureRecognizerState.Failed;
    }

    //

    public override void TouchesEnded(NSSet touches, UIEvent evt)
    {
      base.TouchesEnded(touches, evt);
      State = UIGestureRecognizerState.Failed;
    }

    //
  }
}

