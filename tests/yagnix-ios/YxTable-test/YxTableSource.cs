using System;
using System.Collections.Generic;
using UIKit;
using CoreGraphics;
using Foundation;
using CoreText;
using Yagnix;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class SettingsSource : UITableViewSource
  {
    private readonly List<Section<IModel>> _sections;
    //

    public SettingsSource()
    {
      var customCellFactory1 = new CustomCellFactory1();
      var customCellFactory2 = new CustomCellFactory2();

      _sections = new List<Section<IModel>>();
      Section<IModel> section;

      section = new Section<IModel>();
      section.Header = "Default cell";
      //section1.Footer = "Footer 1";
      section.Items.Add(new CellModel<IModel>(Singleton<DefaultCellFactory>._, new ItemWithTitle { Title = "foo" }));
      section.Items.Add(new CellModel<IModel>(Singleton<DefaultCellFactory>._, new ItemWithTitle { Title = "bar" }));
      _sections.Add(section);

      section = new Section<IModel>();
      section.Header = "Subtitle";
      //section2.Footer = "Footer 2";
      section.Items.Add(new CellModel<IModel>(Singleton<SubtitleCellFactory>._, new ItemWithTitleAndSubtitle { Title = "abc", SubTitle = "123" }));
      section.Items.Add(new CellModel<IModel>(Singleton<SubtitleCellFactory>._, new ItemWithTitleAndSubtitle { Title = "def", SubTitle = "456" }));
      _sections.Add(section);

      section = new Section<IModel>();
      section.Header = "Custom 1";
      //section2.Footer = "Footer 2";
      section.Items.Add(new CellModel<IModel>(customCellFactory1, new ItemWithTitle { Title = "abc" }));
      section.Items.Add(new CellModel<IModel>(customCellFactory2, new ItemWithTitle { Title = "def" }));
      _sections.Add(section);

      section = new Section<IModel>();
      section.Header = "Custom 2";
      //section2.Footer = "Footer 2";
      section.Items.Add(new CellModel<IModel>(customCellFactory2, new ItemWithTitle { Title = "abc" }));
      section.Items.Add(new CellModel<IModel>(customCellFactory1, new ItemWithTitle { Title = "def" }));
      _sections.Add(section);

    }

    //

    public override nint NumberOfSections(UITableView tableView)
    {
      return _sections.Count;
    }

    //

    public override nint RowsInSection(UITableView tableview, nint section)
    {
      return _sections[(int)section].Items.Count;
    }

    //

    public override string TitleForHeader(UITableView tableView, nint section)
    {
      return _sections[(int)section].Header;
    }

    public override string TitleForFooter(UITableView tableView, nint section)
    {
      return _sections[(int)section].Footer;
    }

    //

    public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
    {
      var sectionItem = _sections[indexPath.Section].Items[indexPath.Row];
      return sectionItem.GetCell(tableView);
    }

    //

    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
      //var client = _indexedClients[_indexKeys[indexPath.Section]][indexPath.Row];
      //tableView.DeselectRow(indexPath, true); // iOS convention is to remove the highlight
    }

    //



  }
}

