﻿using UIKit;
using CoreGraphics;
using Yagnix;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class CustomCell1<ModelType> : AbstractCell<ModelType> where ModelType : ItemWithTitle
  {
    private readonly CustomCellView1 _customCellView;

    public CustomCell1(string reuseId) : base(reuseId, UITableViewCellStyle.Default)
    {
      _customCellView = new CustomCellView1();
      ContentView.Add(_customCellView);
    }

    protected override void Invalidate(ModelType model)
    {
      _customCellView.Update(model);
    }

    public override void LayoutSubviews()
    {
      base.LayoutSubviews();
      _customCellView.Frame = ContentView.Bounds;
      _customCellView.SetNeedsDisplay();
    }
  }

  public class CustomCellView1 : UIView 
  {
    UITextField _usernameField;

    public CustomCellView1()
    {
      _usernameField = new UITextField
      {
        Placeholder = "Enter your username",
        BorderStyle = UITextBorderStyle.RoundedRect,
        Frame = new CGRect(0, 0, Bounds.Width, 31.0f)
      };

      Add(_usernameField);

      _usernameField
        .Anchor(NSLayoutAttribute.Top, this, NSLayoutAttribute.Top, 10)
        .Anchor(NSLayoutAttribute.Left, this, NSLayoutAttribute.Left, 10)
        .Anchor(NSLayoutAttribute.Bottom, this, NSLayoutAttribute.Bottom, -10)
        .Anchor(NSLayoutAttribute.Right, this, NSLayoutAttribute.Right, -10);
    }

    public void Update(ItemWithTitle model)
    {
      _usernameField.Text = model.Title;
      SetNeedsDisplay();
    }
  }
}

