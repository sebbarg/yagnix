using System;
using UIKit;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class SwitchCellFactory : AbstractCellFactory
  {
    public bool InitialState { get; set; } = false;
    public Action<SwitchCell<ItemWithTitle>> Toggled { get; set; }

    public override UITableViewCell Create()  
    {   
      return new SwitchCell<ItemWithTitle>(ReuseId, InitialState, Toggled);
    }
  }
}

