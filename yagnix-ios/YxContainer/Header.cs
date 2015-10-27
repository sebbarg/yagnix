using System;
using UIKit;
using CoreGraphics;
using Foundation;

namespace Yagnix.YxContainer
{
  public class Header : UIView
  {
    private readonly UILabel     _label;
    private readonly UIImageView _imageView;
    private readonly UIImage _imageCollapsed;
    private readonly UIImage _imageExpanded;

    public Header()
    {
      ClipsToBounds = true;
  
      _label = this.Add<UILabel>();

      _imageCollapsed = UIImage.FromBundle("collapsed-left");
      _imageExpanded = UIImage.FromBundle("expanded-down");

      _imageView = new UIImageView(_imageCollapsed);
      Add(_imageView);

      const int margin = 10;

      _imageView
        .Anchor(NSLayoutAttribute.Top, this, NSLayoutAttribute.Top, margin)
        .Anchor(NSLayoutAttribute.Right, this, NSLayoutAttribute.Right, -margin)
        .Anchor(NSLayoutAttribute.Bottom, this, NSLayoutAttribute.Bottom, -margin)
        .Layout(NSLayoutAttribute.Height, _imageView.Image.Size.Height)
        .Layout(NSLayoutAttribute.Width, _imageView.Image.Size.Width);

      _label
        .Anchor(NSLayoutAttribute.Left, this, NSLayoutAttribute.Left, margin)
        .Anchor(NSLayoutAttribute.CenterY, this, NSLayoutAttribute.CenterY)
        .Anchor(NSLayoutAttribute.Right, _imageView, NSLayoutAttribute.Left, -margin);
    }

    //

    public string Text 
    {
      get { return _label.Text; }
      set { _label.Text = value; }
    }

    //

    public void Collapse()
    {
      _imageView.Image = _imageCollapsed;
    }

    //

    public void Expand()
    {
      _imageView.Image = _imageExpanded;
    }

  }

}

