using System;
using UIKit;

namespace Yagnix.YxTable
{
  public abstract class AbstractCellFactory
  {
    public abstract UITableViewCell Create();
    public virtual string ReuseId 
    { 
      get {
        return this.GetType().FullName;
      }
    }
  }
}

