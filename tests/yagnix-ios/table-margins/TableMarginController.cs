using System;
using UIKit;
using CoreGraphics;
using Foundation;
using CoreText;
using Yagnix;
using Yagnix.YxTable;

namespace tablemargins
{
  public class TableMarginController : UIViewController
  {
    private UITableView _top;
    private UITableView _bottom;

    public TableMarginController()
    {
      Console.WriteLine($"Version {UIDevice.CurrentDevice.SystemVersion}");

    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();

      View.BackgroundColor = UIColor.Green;

      Title = "Margin Test";

      _top = new UITableView(new CGRect(), UITableViewStyle.Plain);
      View.Add(_top);

      _bottom = new UITableView(new CGRect(), UITableViewStyle.Grouped);
      View.Add(_bottom);

      // _top.SeparatorStyle = _bottom.SeparatorStyle = UITableViewCellSeparatorStyle.None;

      _top.ZeroMargins();
      _bottom.ZeroMargins();


      if ( IosVersion.Major >= 9 )
      {
        _top.CellLayoutMarginsFollowReadableWidth = _bottom.CellLayoutMarginsFollowReadableWidth = false;
      }
     
      _top
        .Anchor(NSLayoutAttribute.Top, View, NSLayoutAttribute.Top)
        .Anchor(NSLayoutAttribute.Left, View, NSLayoutAttribute.Left)
        .Anchor(NSLayoutAttribute.Right, View, NSLayoutAttribute.Right)
        .Anchor(NSLayoutAttribute.Bottom, View, NSLayoutAttribute.CenterY);
      
      _bottom
        .Anchor(NSLayoutAttribute.Top, _top, NSLayoutAttribute.Bottom)
        .Anchor(NSLayoutAttribute.Left, View, NSLayoutAttribute.Left)
        .Anchor(NSLayoutAttribute.Right, View, NSLayoutAttribute.Right)
        .Anchor(NSLayoutAttribute.Bottom, View, NSLayoutAttribute.Bottom);

      var source = new TableSource();

      Section section;

      // -----------------------

      section = new Section();
      section.Header = "Default cell";
      section.Footer = "---";

      var titleCellFactory = new TitleCellFactory();

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          titleCellFactory, 
          new ItemWithTitle { Title = "foo" }
        ));

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          titleCellFactory, 
          new ItemWithTitle { Title = "bar" }
        ));

      source.Sections.Add(section);

      // -----------------------

      _top.Source = source;
      _bottom.Source = source;
    }

  }


}

