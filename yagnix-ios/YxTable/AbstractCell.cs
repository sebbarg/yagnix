using System;
using UIKit;

namespace Yagnix.YxTable
{
  public abstract class AbstractCell<ModelType> : UITableViewCell
  {
    protected AbstractCell(string reuseId, UITableViewCellStyle style) : base(style, reuseId)
    {
    }

    //

    private ModelType _model;
    public ModelType Model
    { 
      get {
        return _model; 
      }
      set {
        _model = value;
        Invalidate(_model);
      }
    }

    //

    public virtual void SelectCell()
    {
    }

    //

    public void ZeroMargins()
    {
      LayoutMargins = UIEdgeInsets.Zero;
      SeparatorInset = UIEdgeInsets.Zero;
    }

    //

    protected abstract void Invalidate(ModelType model);

    //

  }
}

