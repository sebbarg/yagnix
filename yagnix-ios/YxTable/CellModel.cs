using System;
using UIKit;

namespace Yagnix.YxTable
{
  public abstract class CellModel
  {
    public abstract UITableViewCell GetCell(UITableView tableView);
    public abstract void RowSelected();
  }

  public class CellModel<ModelType> : CellModel
  {
    public AbstractCellFactory Factory { get; }
    public AbstractCell<ModelType> Cell { get; private set; }
    public ModelType Model { get; }
    public Action<AbstractCell<ModelType>> CellSelected { get; private set; }

    public CellModel(AbstractCellFactory cellFactory, ModelType model) : this(cellFactory, model, null)
    {
    }

    public CellModel(AbstractCellFactory cellFactory, ModelType model, Action<AbstractCell<ModelType>> cellSelected)
    {
      Factory = cellFactory;
      Model = model;
      CellSelected = cellSelected;
    }

    public override UITableViewCell GetCell(UITableView tableView)
    {
      Cell = (AbstractCell<ModelType>)tableView.DequeueReusableCell(Factory.ReuseId);
      if ( Cell == null )
      {
        Cell = (AbstractCell<ModelType>)Factory.Create();  
      }
      Cell.CellSelected = CellSelected;
      Cell.Model = Model;
      return Cell;
    }

    public override void RowSelected()
    {
      Cell.SelectCell();
    }


  }
}

