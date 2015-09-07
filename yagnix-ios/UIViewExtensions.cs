using System;
using UIKit;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace Yagnix
{
  public static class UIViewExtensions
  {
    // Get the controller of the view
    public static T ParentController<T>(this UIView uiview) where T: UIViewController
    {
      UIResponder parentResponder = uiview;

      while ( parentResponder != null )
        if ( typeof(UIViewController).IsAssignableFrom(parentResponder.GetType() ))
          return parentResponder as T;
        else
          parentResponder = parentResponder.NextResponder;

      return null;
    }

    //

    public static UIViewController ParentController(this UIView uiview)
    {
      return ParentController<UIViewController>(uiview);
    }

    //

    public static T Add<T>(this UIView view) where T: UIView, new()
    {
      var child = new T();
      view.Add(child);
      return child;
    }

    //

    //    public static CGRect SizeToSubviews(this UIView view)
    //    {
    //      var w = view.Frame.Width;
    //      var h = view.Frame.Height;
    //
    //      foreach ( var v in view.Subviews )
    //      {
    //        w = (nfloat)Math.Max(w, v.Frame.Width);
    //        h = (nfloat)Math.Max(h, v.Frame.Height);
    //      }
    //
    //      return new CGRect(view.Frame.X, view.Frame.Y, w, h); 
    //    }

    //

    public static CGRect CalcHeight(this UILabel label, CGRect bounds)
    {
      CGSize size = bounds.Size;
      size.Height = 10000;
      bounds.Size = size;
      return label.TextRectForBounds(bounds, label.Lines);
    }

    //

    public static nfloat CalcHeight(this UILabel label, nfloat width)
    {
      var bounds = new CGRect(0, 0, width, 10000);
      return label.TextRectForBounds(bounds, label.Lines).Height;
    }

    //

    public static UIView Layout(
      this UIView thisControl, 
      INativeObject otherControl, 
      NSLayoutAttribute thisAttribute, 
      NSLayoutAttribute otherAttribute, 
      nfloat constant)
    {
      thisControl.TranslatesAutoresizingMaskIntoConstraints = false;

      // SB:NOTE if this throws "IB auto generated at build time for view with fixed frame",
      // uncheck "autolayout" on the storyboarad in xcode

      System.Diagnostics.Debug.Assert(thisControl.Superview != null);

      thisControl.Superview.AddConstraint(
        NSLayoutConstraint.Create(
          thisControl, 
          thisAttribute,                
          NSLayoutRelation.Equal,
          otherControl, 
          otherAttribute,               
          1, 
          constant));

      return thisControl;
    }

    //

    public static UIView Layout(
      this UIView thisControl, 
      INativeObject otherControl, 
      NSLayoutAttribute thisAttribute, 
      NSLayoutAttribute otherAttribute)
    {
      return Layout(thisControl, otherControl, thisAttribute, otherAttribute, 0);
    }

    //

    public static UIView Layout(
      this UIView thisControl, 
      NSLayoutAttribute layout, 
      nfloat size)
    {
      return Layout(thisControl, null, layout, NSLayoutAttribute.NoAttribute, size);
    }

    //

    public static UIView Anchor(
      this UIView thisControl, 
      NSLayoutAttribute side, 
      INativeObject otherControl, 
      NSLayoutAttribute otherSide, 
      nfloat offset)
    {
      return Layout(thisControl, otherControl, side, otherSide, offset);
    }

    //

    public static UIView Anchor(
      this UIView thisControl, 
      NSLayoutAttribute side, 
      INativeObject otherControl, 
      NSLayoutAttribute otherSide)
    {
      return Anchor(thisControl, side, otherControl, otherSide, 0);
    }

    //

    public static UIView FitToParent(this UIView thisControl, nfloat offset)
    {
      return thisControl
        .Anchor(NSLayoutAttribute.Top, thisControl.Superview, NSLayoutAttribute.Top, +offset)
        .Anchor(NSLayoutAttribute.Left, thisControl.Superview, NSLayoutAttribute.Left, +offset)
        .Anchor(NSLayoutAttribute.Right, thisControl.Superview, NSLayoutAttribute.Right, -offset)
        .Anchor(NSLayoutAttribute.Bottom, thisControl.Superview, NSLayoutAttribute.Bottom, -offset);
    }

    //

    public static UIView FitToGuides(this UIView thisControl, UIViewController controller, nfloat offset)
    {
      return thisControl
        .Anchor(NSLayoutAttribute.Top, controller.TopLayoutGuide, NSLayoutAttribute.Bottom, +offset)
        .Anchor(NSLayoutAttribute.Left, thisControl.Superview, NSLayoutAttribute.Left, +offset)
        .Anchor(NSLayoutAttribute.Right, thisControl.Superview, NSLayoutAttribute.Right, -offset)
        .Anchor(NSLayoutAttribute.Bottom, controller.BottomLayoutGuide, NSLayoutAttribute.Top, -offset);
    }

    //

    public static UIView FitToParent(this UIView thisControl)
    {
      return FitToParent(thisControl, 0);
    }

    //

    public static NSLayoutConstraint ConstrainHeight(this UIView view, nfloat height)
    {
      var result = 
        NSLayoutConstraint.Create(
          view, 
          NSLayoutAttribute.Height,                
          NSLayoutRelation.Equal,
          null, 
          NSLayoutAttribute.NoAttribute,               
          1, 
          height);

      view.Superview.AddConstraint(result);
      return result;
    }

    //

    public static void SetWidth(this UIView view, nfloat width)
    {
      var frame = view.Frame;
      var size = frame.Size;
      size.Width = width;
      frame.Size = size;
      view.Frame = frame;
    }

    //

    public static void SetHeight(this UIView view, nfloat height)
    {
      var frame = view.Frame;
      var size = frame.Size;
      size.Height = height;
      frame.Size = size;
      view.Frame = frame;
    }

    //

    public static void SetSize(this UIView view, nfloat width, nfloat height)
    {
      var frame = view.Frame;
      var size = frame.Size;
      size.Width = width;
      size.Height = height;
      frame.Size = size;
      view.Frame = frame;
    }

    //

    public static UIFont MakeBold(this UIFont font)
    {
      // http://tirania.org/monomac/archive/2013/Sep-25.html

      var desc = font.FontDescriptor;

      // create a new descriptor based on the baseline, with
      // the requested Bold trait
      var bold = desc.CreateWithTraits(UIFontDescriptorSymbolicTraits.Bold);

      // Create font from the bold descriptor
      return UIFont.FromDescriptor(bold, font.PointSize);
    }

    //

    public static CGSize GetTextSize(string text, UIFont font)
    {
      var nsString = new NSString(text);
      UIStringAttributes attribs = new UIStringAttributes { Font = font };
      return nsString.GetSizeUsingAttributes(attribs);
    }

    //

    #region border

    [Flags]
    public enum BorderKind { Left = 1, Top = 2, Right = 4, Bottom = 8 };
    private static readonly UIColor BorderDefaultColor = UIColor.FromRGB(200, 200, 200);
    private static readonly nfloat BorderDefaultSize = 0.5f;
    public static void Border(this UIView view, BorderKind kind, UIColor color, nfloat size)
    {
      if ( kind.HasFlag(BorderKind.Left) )
      {
        var border = new UIView();
        border.BackgroundColor = color;
        view.AddSubview(border);

        border
          .Anchor(NSLayoutAttribute.Top, view, NSLayoutAttribute.Top)
          .Anchor(NSLayoutAttribute.Left, view, NSLayoutAttribute.Left)
          .Anchor(NSLayoutAttribute.Bottom, view, NSLayoutAttribute.Bottom)
          .Layout(NSLayoutAttribute.Width, size);
      }
      if ( kind.HasFlag(BorderKind.Top) )
      {
        var border = new UIView();
        border.BackgroundColor = color;
        view.AddSubview(border);

        border
          .Anchor(NSLayoutAttribute.Top, view, NSLayoutAttribute.Top)
          .Anchor(NSLayoutAttribute.Left, view, NSLayoutAttribute.Left)
          .Anchor(NSLayoutAttribute.Right, view, NSLayoutAttribute.Right)
          .Layout(NSLayoutAttribute.Height, size);
      }
      if ( kind.HasFlag(BorderKind.Right) )
      {
        var border = new UIView();
        border.BackgroundColor = color;
        view.AddSubview(border);

        border
          .Anchor(NSLayoutAttribute.Top, view, NSLayoutAttribute.Top)
          .Anchor(NSLayoutAttribute.Right, view, NSLayoutAttribute.Right)
          .Anchor(NSLayoutAttribute.Bottom, view, NSLayoutAttribute.Bottom)
          .Layout(NSLayoutAttribute.Width, size);
      }
      if ( kind.HasFlag(BorderKind.Bottom) )
      {
        var border = new UIView();
        border.BackgroundColor = color;
        view.AddSubview(border);

        border
          .Anchor(NSLayoutAttribute.Left, view, NSLayoutAttribute.Left)
          .Anchor(NSLayoutAttribute.Right, view, NSLayoutAttribute.Right)
          .Anchor(NSLayoutAttribute.Bottom, view, NSLayoutAttribute.Bottom)
          .Layout(NSLayoutAttribute.Height, size);
      }
    }

    //

    public static void BorderLeft(this UIView view)
    {
      view.Border(UIViewExtensions.BorderKind.Left, BorderDefaultColor, BorderDefaultSize);
    }

    //

    public static void BorderTop(this UIView view)
    {
      view.Border(UIViewExtensions.BorderKind.Top, BorderDefaultColor, BorderDefaultSize);
    }

    //

    public static void BorderRight(this UIView view)
    {
      view.Border(UIViewExtensions.BorderKind.Right, BorderDefaultColor, BorderDefaultSize);
    }

    //

    public static void BorderBottom(this UIView view)
    {
      view.Border(UIViewExtensions.BorderKind.Bottom, BorderDefaultColor, BorderDefaultSize);
    }

    #endregion

  }
}

