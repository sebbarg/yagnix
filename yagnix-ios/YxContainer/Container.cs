using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;
using Foundation;

namespace Yagnix.YxContainer
{
  public class Container : UIView
  {
    private enum State { Collapsed, Expanded };
    private State _state;

    private UIView _content;

    public Header Header  { get; private set; }

    public NSLayoutConstraint CollapsedConstraint { get; set; }
    public NSLayoutConstraint ExpandedConstraint { get; set; }

    public event EventHandler<EventArgs> Collapsed;
    public event EventHandler<EventArgs> Expanded;

    //

    public Container()
    {
      ClipsToBounds = true;
      _state = State.Collapsed;

      Layer.BackgroundColor = UIColor.White.CGColor;
      Layer.BorderColor = UIColor.LightGray.CGColor;
      Layer.BorderWidth = 1;

      Header = this.Add<Header>();
      _content = this.Add<UIView>();
      _content.ClipsToBounds = true;

      Header.BackgroundColor = UIColor.White;
      Header.Layer.BorderColor = UIColor.LightGray.CGColor;
      Header.Layer.BorderWidth = 1;

      Header 
        .Anchor(NSLayoutAttribute.Top, this, NSLayoutAttribute.Top)
        .Anchor(NSLayoutAttribute.Left, this, NSLayoutAttribute.Left)
        .Anchor(NSLayoutAttribute.Right, this, NSLayoutAttribute.Right);

      _content 
        .Anchor(NSLayoutAttribute.Top, Header, NSLayoutAttribute.Bottom)
        .Anchor(NSLayoutAttribute.Left, this, NSLayoutAttribute.Left)
        .Anchor(NSLayoutAttribute.Right, this, NSLayoutAttribute.Right)
        .Anchor(NSLayoutAttribute.Bottom, this, NSLayoutAttribute.Bottom);
    }

    //

    public UIView Content 
    { 
      set {
        _content.Add(value);
        value.FitToParent();
      }
    }

    //

    public override void LayoutSubviews()
    {
      base.LayoutSubviews();

      if ( CollapsedConstraint == null )
      {
        CollapsedConstraint = 
          NSLayoutConstraint.Create(
          _content, 
          NSLayoutAttribute.Height,                
          NSLayoutRelation.Equal,
          null, 
          NSLayoutAttribute.NoAttribute,               
          1, 
          0);
      }

      if ( _state == State.Collapsed )
      {
        Superview.AddConstraint(CollapsedConstraint);
      }
    }

    //

    public void Collapse(bool animated)
    {
      if ( _state != State.Collapsed )
      {
        _state = State.Collapsed;
        Header.Collapse();

        if ( ExpandedConstraint != null )
        {
          Superview.RemoveConstraint(ExpandedConstraint);
        }
        if ( CollapsedConstraint != null )
        {
          Superview.AddConstraint(CollapsedConstraint);
        }

        if ( animated )
        {
          UIView.Animate (
            0.2, // duration
            () => { Superview.LayoutIfNeeded(); }
          );
        }

        var onCollapsed = Collapsed;
        if ( onCollapsed != null )
        {
          onCollapsed(this, new EventArgs());
        }
      }
    }

    //

    public void Expand(bool animated)
    {
      if ( _state != State.Expanded )
      {
        _state = State.Expanded;
        Header.Expand();

        if ( CollapsedConstraint != null )
        {
          Superview.RemoveConstraint(CollapsedConstraint);
        }
        if ( ExpandedConstraint != null )
        {
          Superview.AddConstraint(ExpandedConstraint);
        }

        if ( animated )
        {
          UIView.Animate (
            0.2, // duration
            () => { Superview.LayoutIfNeeded(); }
          );
        }

        var onExpanded = Expanded;
        if ( onExpanded != null )
        {
          onExpanded(this, new EventArgs());
        }
      }
    }

    //

    public override void TouchesEnded(NSSet touches, UIEvent evt)
    {
      base.TouchesBegan(touches, evt);
      var touch = touches.AnyObject as UITouch;
      if ( touch != null )
      {
        if ( _state == State.Expanded )
          Collapse(true);
        else
          Expand(true);
      }
    }

  }
}

