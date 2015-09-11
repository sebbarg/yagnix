using UIKit;
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
      _customCellView.FitToMargin();

      //ContentView.BackgroundColor = UIColor.Blue;
    }

    protected override void Invalidate(ModelType model)
    {
      _customCellView.Update(model);
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
        .Anchor(NSLayoutAttribute.Top, this, NSLayoutAttribute.Top, 0)
        .Anchor(NSLayoutAttribute.Left, this, NSLayoutAttribute.Left, 0)
        .Anchor(NSLayoutAttribute.Bottom, this, NSLayoutAttribute.Bottom, 0)
        .Anchor(NSLayoutAttribute.Right, this, NSLayoutAttribute.Right, 0);
    }

    public void Update(ItemWithTitle model)
    {
      _usernameField.Text = model.Title;
      SetNeedsDisplay();
    }
  }
}

