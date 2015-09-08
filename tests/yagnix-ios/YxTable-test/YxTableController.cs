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

      _view.FitToParent(0);

      var source = new TableSource<IModel>();

      Section<IModel> section;

      section = new Section<IModel>();
      section.Header = "Default cell";
      //section1.Footer = "Footer 1";
      section.Cells.Add(new CellModel<IModel>(Singleton<DefaultCellFactory>._, new ItemWithTitle { Title = "foo" }));
      section.Cells.Add(new CellModel<IModel>(Singleton<DefaultCellFactory>._, new ItemWithTitle { Title = "bar" }));
      source.Sections.Add(section);

      section = new Section<IModel>();
      section.Header = "Subtitle";
      //section2.Footer = "Footer 2";
      section.Cells.Add(new CellModel<IModel>(Singleton<SubtitleCellFactory>._, new ItemWithTitleAndSubtitle { Title = "abc", SubTitle = "123" }));
      section.Cells.Add(new CellModel<IModel>(Singleton<SubtitleCellFactory>._, new ItemWithTitleAndSubtitle { Title = "def", SubTitle = "456" }));
      source.Sections.Add(section);

      section = new Section<IModel>();
      section.Header = "Custom 1";
      //section2.Footer = "Footer 2";
      section.Cells.Add(new CellModel<IModel>(Singleton<CustomCellFactory1>._, new ItemWithTitle { Title = "abc" }));
      section.Cells.Add(new CellModel<IModel>(Singleton<CustomCellFactory1>._, new ItemWithTitle { Title = "def" }));
      source.Sections.Add(section);

      section = new Section<IModel>();
      section.Header = "Custom 2";
      //section2.Footer = "Footer 2";
      section.Cells.Add(new CellModel<IModel>(Singleton<CustomCellFactory2>._, new ItemWithTitle { Title = "abc" }));
      section.Cells.Add(new CellModel<IModel>(Singleton<CustomCellFactory2>._, new ItemWithTitle { Title = "def" }));
      source.Sections.Add(section);

      _view.Source = source;
    }
  }
}

