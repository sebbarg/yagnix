using System;
using UIKit;
using CoreGraphics;
using Foundation;
using CoreText;
using Yagnix;

namespace YxTableTest
{
  public class YxTableController : UIViewController
  {
    private UITableView _view;

    public YxTableController()
    {
      Console.WriteLine($"Version {UIDevice.CurrentDevice.SystemVersion}");

    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();

      View.BackgroundColor = UIColor.Green;

      Title = "YxTableTest";

      _view = new UITableView(new CGRect(), UITableViewStyle.Grouped);
      View.Add(_view);

      _view.FitToParent(0);

      _view.Source = new SettingsSource();
    }
  }
}

