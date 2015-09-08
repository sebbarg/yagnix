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


      var source = new TableSource();

      Section section;

      var onCellSelect = 
        new Action<AbstractCell<ItemWithTitle>>((cell) => MsgBox.Show("Hopla", cell.Model.Title, new[] { "OK" }));

      // -----------------------

      section = new Section();
      section.Header = "Default cell";
      section.Footer = "---";

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          Singleton<DefaultCellFactory>._, 
          new ItemWithTitle { Title = "foo" },
          (cell) => MsgBox.Show("Hopla", cell.Model.Title, new [] {"OK"})
        ));

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          Singleton<DefaultCellFactory>._, 
          new ItemWithTitle { Title = "bar" },
          onCellSelect
        ));

      source.Sections.Add(section);

      // -----------------------

      section = new Section();
      section.Header = "Subtitle";

      section.Cells.Add(
        new CellModel<ItemWithTitleAndSubtitle>(
          Singleton<SubtitleCellFactory>._, 
          new ItemWithTitleAndSubtitle { Title = "abc", SubTitle = "123" },
          (cell) => MsgBox.Show(cell.Model.Title, cell.Model.SubTitle, new [] {"OK"})
        ));

      section.Cells.Add(
        new CellModel<ItemWithTitleAndSubtitle>(
          Singleton<SubtitleCellFactory>._, 
          new ItemWithTitleAndSubtitle { Title = "def", SubTitle = "456" },
          (cell) => MsgBox.Show(cell.Model.Title, cell.Model.SubTitle, new [] {"OK"})
        ));

      source.Sections.Add(section);

      // -----------------------

      section = new Section();
      section.Header = "Custom 1";

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          Singleton<CustomCellFactory1>._, 
          new ItemWithTitle { Title = "abc" },
          (cell) => MsgBox.Show("Hopla", cell.Model.Title, new [] {"OK"})
        ));

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          Singleton<CustomCellFactory1>._, 
          new ItemWithTitle { Title = "def" },
          (cell) => MsgBox.Show("Hopla", cell.Model.Title, new [] {"OK"})
        ));

      source.Sections.Add(section);

      // -----------------------

      section = new Section();
      section.Header = "Custom 2";
      //section2.Footer = "Footer 2";

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          Singleton<CustomCellFactory2>._, 
          new ItemWithTitle { Title = "abc" },
          (cell) => MsgBox.Show("Hopla", cell.Model.Title, new [] {"OK"})
        ));

      section.Cells.Add(
        new CellModel<ItemWithTitle>(
          Singleton<CustomCellFactory2>._, 
          new ItemWithTitle { Title = "def" },
          (cell) => MsgBox.Show("Hopla", cell.Model.Title, new [] {"OK"})
        ));

      source.Sections.Add(section);

      // -----------------------

      _view.Source = source;
    }
  }
}

