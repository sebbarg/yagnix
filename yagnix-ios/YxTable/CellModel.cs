using System;
using UIKit;

namespace Yagnix.YxTable
{
  public class CellModel<ModelType>
  {
    public AbstractCellFactory Factory { get; }
    public ModelType Model { get; }

    public CellModel(AbstractCellFactory cellFactory, ModelType model)
    {
      Factory = cellFactory;
      Model = model;
    }

    public UITableViewCell GetCell(UITableView tableView)
    {
      AbstractCell<ModelType> cell = (AbstractCell<ModelType>)tableView.DequeueReusableCell(Factory.ReuseId);
      if ( cell == null )
      {
        cell = (AbstractCell<ModelType>)Factory.Create();  
      }
      cell.Update(Model);
      return cell;
    }
  }
}

