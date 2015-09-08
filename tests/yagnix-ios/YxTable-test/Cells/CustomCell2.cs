using UIKit;
using CoreGraphics;
using CoreText;
using Foundation;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class CustomCell2<ModelType> : AbstractCell<ModelType> where ModelType : ItemWithTitle
  {
    private readonly CustomCellView2 _customCellView;

    public CustomCell2(string reuseId) : base(reuseId, UITableViewCellStyle.Default)
    {
      _customCellView = new CustomCellView2();
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

  public class CustomCellView2 : UIView 
  {
    private ItemWithTitle _model;

    public CustomCellView2()
    {
    }

    public void Update(ItemWithTitle model)
    {
      _model = model;
      SetNeedsDisplay();
    }

    public override void Draw(CGRect rect)
    {
      using (CGContext g = UIGraphics.GetCurrentContext ())
      {
        g.ScaleCTM (1, -1);
        g.TranslateCTM (0, -Bounds.Height);

        UIColor.White.SetColor();
        g.FillRect(Bounds);

        UIColor.Green.SetColor();
        g.StrokeRect(Bounds);

        // http://tirania.org/monomac/archive/2013/Sep-25.html

        var attributedString = new NSAttributedString(_model.Title,
          new CTStringAttributes{
            ForegroundColorFromContext =  true,
            Font = new CTFont(UIFont.PreferredHeadline.Name, UIFont.PreferredHeadline.PointSize)
          });

        using (var textLine = new CTLine(attributedString))
        {
          textLine.Draw(g);
        }
      }
    }
  }
}

