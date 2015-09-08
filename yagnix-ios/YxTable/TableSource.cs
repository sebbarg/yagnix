using System;
using System.Collections.Generic;
using UIKit;
using Foundation;

namespace Yagnix.YxTable
{
  public class TableSource<ModelType> : UITableViewSource 
  {
    public List<Section<ModelType>> Sections { get; } = new List<Section<ModelType>>(); 

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
      return cellModel.GetCell(tableView);
    }

    //

    public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
    {
      var cellModel = Sections[indexPath.Section].Cells[indexPath.Row];
      cellModel.Cell.SelectCell();  
      tableView.DeselectRow(indexPath, true); // iOS convention is to remove the highlight
    }
  }
}

