using System;
using UIKit;

namespace Yagnix.YxTable
{
  public abstract class CellModel
  {
    public abstract UITableViewCell GetCell(UITableView tableView);
    public abstract void RowSelected();
  }

  public sealed class CellModel<ModelType> : CellModel
  {
    private AbstractCellFactory _factory;
    private AbstractCell<ModelType> _cell;
    private ModelType _model;
    private Action<AbstractCell<ModelType>> _cellSelected;

    public CellModel(AbstractCellFactory cellFactory, ModelType model) : this(cellFactory, model, null)
    {
    }

    //

    public CellModel(AbstractCellFactory cellFactory, ModelType model, Action<AbstractCell<ModelType>> cellSelected)
    {
      _factory = cellFactory;
      _model = model;
      _cellSelected = cellSelected;
    }

    //

    public override UITableViewCell GetCell(UITableView tableView)
    {
      _cell = (AbstractCell<ModelType>)tableView.DequeueReusableCell(_factory.ReuseId);
      if ( _cell == null )
      {
        _cell = (AbstractCell<ModelType>)_factory.Create();  
      }
      _cell.CellSelected = _cellSelected;
      _cell.Model = _model;
      return _cell;
    }

    //

    public override void RowSelected()
    {
      _cell.SelectCell();
    }
  }
}

