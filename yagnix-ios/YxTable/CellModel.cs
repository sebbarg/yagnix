using System;
using UIKit;
using Foundation;

namespace Yagnix.YxTable
{
  public abstract class CellModel
  {
    public abstract UITableViewCell GetCell(UITableView tableView, int sectionIndex, int rowIndex);
    public abstract void RowSelected();
    public abstract NSIndexPath Path();
  }

  public sealed class CellModel<ModelType> : CellModel
  {
    private int _sectionIndex = -1;
    private int _rowIndex = -1;

    private AbstractCellFactory _factory;
    private AbstractCell<ModelType> _cell;
    public ModelType Model { get; private set; }

    //

    public CellModel(AbstractCellFactory cellFactory, ModelType model)
    {
      _factory = cellFactory;
      Model = model;
    }

    //

    public override UITableViewCell GetCell(UITableView tableView, int sectionIndex, int rowIndex)
    {
      _sectionIndex = sectionIndex;
      _rowIndex = rowIndex;

      _cell = (AbstractCell<ModelType>)tableView.DequeueReusableCell(_factory.ReuseId);
      if ( _cell == null )
      {
        _cell = (AbstractCell<ModelType>)_factory.Create();  
      }
      _cell.Model = Model;
      return _cell;
    }

    //

    public override void RowSelected()
    {
      _cell.SelectCell();
    }

    //

    public override NSIndexPath Path()
    {
      if ( _sectionIndex >= 0 && _rowIndex >= 0 )
      {
        return NSIndexPath.FromItemSection(_rowIndex, _sectionIndex);
      }
      return null;
    }
  }
}

