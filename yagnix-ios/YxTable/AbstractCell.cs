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
  }
}

