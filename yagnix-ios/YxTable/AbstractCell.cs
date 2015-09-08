using System;
using UIKit;

namespace Yagnix.YxTable
{
  public abstract class AbstractCell<ModelType> : UITableViewCell
  {
    protected AbstractCell(string reuseId, UITableViewCellStyle style) : base(style, reuseId)
    {
    }

    public abstract void Update(ModelType model);

    public virtual void SelectCell()
    {
      var handler = CellSelected;
      if ( handler != null )
      {
        handler(this, EventArgs.Empty);
      }
    }

    public event EventHandler CellSelected;
  }
}

