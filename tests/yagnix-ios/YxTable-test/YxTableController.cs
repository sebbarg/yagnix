using System;
using UIKit;
using CoreGraphics;
using Foundation;
using CoreText;
using Yagnix;
using Yagnix.YxTable;

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

      //_view.SeparatorInset = UIEdgeInsets.Zero;
      //_view.LayoutMargins = UIEdgeInsets.Zero;
      //_view.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;

      _view.FitToParent();

      var source = new TableSource();

      Section section;

      // -----------------------

      section = new Section();
      section.Header = "Default cell";
      section.Footer = "---";

      var defaultCellFactory = new DefaultCellFactory();

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          defaultCellFactory, 
          new ItemWithTitle { Title = "foo" }
        ));

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          defaultCellFactory, 
          new ItemWithTitle { Title = "bar" }
        ));

      source.Sections.Add(section);

      // -----------------------

      section = new Section();
      section.Header = "Subtitle";

      section.Cells.Add(
        new CellModel<ItemWithTitleAndSubtitle>(
          Singleton<SubtitleCellFactory>._, 
          new ItemWithTitleAndSubtitle { Title = "abc", SubTitle = "123" }
        ));

      section.Cells.Add(
        new CellModel<ItemWithTitleAndSubtitle>(
          Singleton<SubtitleCellFactory>._, 
          new ItemWithTitleAndSubtitle { Title = "def", SubTitle = "456" }
        ));

      source.Sections.Add(section);

      // -----------------------

      section = new Section();
      section.Header = "Switch cell";

      var switchCellFactory1 = new SwitchCellFactory { InitialState = true };
      var switchCellFactory2 = new SwitchCellFactory { 
        InitialState = false,
        CellSelected = (cell) => MsgBox.Show(cell.Model.Title, "Cell selected", new [] {"OK"}),
        Toggled = (cell) => MsgBox.Show(cell.Model.Title, "Switch toggled", new [] {"OK"})
      };

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          switchCellFactory1, 
          new ItemWithTitle { Title = "foo" }
        ));

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          switchCellFactory2, 
          new ItemWithTitle { Title = "bar" }
        ));

      source.Sections.Add(section);

      // -----------------------

      section = new Section();
      section.Header = "Custom 1";

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          Singleton<CustomCellFactory1>._, 
          new ItemWithTitle { Title = "abc" }
        ));

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          Singleton<CustomCellFactory1>._, 
          new ItemWithTitle { Title = "def" }
        ));

      source.Sections.Add(section);

      // -----------------------

      section = new Section();
      section.Header = "Custom 2";
      //section2.Footer = "Footer 2";

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          Singleton<CustomCellFactory2>._, 
          new ItemWithTitle { Title = "abc" }
        ));

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          Singleton<CustomCellFactory2>._, 
          new ItemWithTitle { Title = "def" }
        ));

      source.Sections.Add(section);

      // -----------------------

      _view.Source = source;
    }

    public override void ViewWillAppear(bool animated)
    {
      base.ViewWillAppear(animated);
      //NavigationController.ToolbarHidden = true;
    }

    public override void ViewDidLayoutSubviews()
    {
      base.ViewDidLayoutSubviews();
      //View.LayoutMargins = new UIEdgeInsets(80, 80, 80, 80);
    }


  }


}

