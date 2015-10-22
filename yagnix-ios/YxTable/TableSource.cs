using System;
using System.Collections.Generic;
using UIKit;
using Foundation;

namespace Yagnix.YxTable
{
  public class TableSource : UITableViewSource 
  {
    public List<Section> Sections { get; }

    //

    public TableSource()
    {
      Sections = new List<Section>(); 
    }

    //

    public TableSource(Section section)
    {
      Sections = new List<Section>();
      Sections.Add(section);
    }

    //

    public override nint NumberOfSections(UITableView tableView)
    {
      return Sections.Count;
    }

    //

    public override nint RowsInSection(UITableView tableview, nint section)
    {
      return Sections[(int)section].Cells.Count;
    }

    //

    public override string TitleForHeader(UITableView tableView, nint section)
    {
      return Sections[(int)section].Header;
    }

    public override string TitleForFooter(UITableView tableView, nint section)
    {
      return Sections[(int)section].Footer;
    }

    //  

    public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
    {
      var cellModel = Sections[indexPath.Section].Cells[indexPath.Row];
      return cellModel.GetCell(tableView, indexPath.Section, indexPath.Row);
    }

    //

    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
      var cellModel = Sections[indexPath.Section].Cells[indexPath.Row];
      cellModel.RowSelected();  
      tableView.DeselectRow(indexPath, true); // iOS convention is to remove the highlight
    }

    //

  }
}

