using System;
using UIKit;

namespace Yagnix.YxTable
{
  public class CellModel<ModelType>
  {
    public AbstractCellFactory Factory { get; }
    public AbstractCell<ModelType> Cell { get; private set; }
    public ModelType Model { get; }

    public CellModel(AbstractCellFactory cellFactory, ModelType model)
    {
      Factory = cellFactory;
      Model = model;
    }

    public UITableViewCell GetCell(UITableView tableView)
    {
      Cell = (AbstractCell<ModelType>)tableView.DequeueReusableCell(Factory.ReuseId);
      if ( Cell == null )
      {
        Cell = (AbstractCell<ModelType>)Factory.Create();  
      }
      Cell.Update(Model);
      return Cell;
    }
  }
}

