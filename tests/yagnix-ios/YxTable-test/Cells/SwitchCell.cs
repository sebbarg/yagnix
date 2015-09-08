using System;
using UIKit;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class SwitchCell<ModelType> : AbstractCell<ModelType> where ModelType : ItemWithTitle
  {
    public UISwitch Switch { get; }
    public Action<SwitchCell<ModelType>> Toggled { get; }

    public SwitchCell(string reuseId, bool initialState, Action<SwitchCell<ModelType>> toggled) : base(reuseId, UITableViewCellStyle.Default)
    {
      SelectionStyle = UITableViewCellSelectionStyle.None;

      Switch = new UISwitch();
      Switch.SetState(initialState, false);

      AccessoryView = Switch;

      Toggled = toggled;

      Switch.ValueChanged += (sender, e) => {  
        if ( Toggled != null )
        {
          Toggled(this);
        }
      };
    }

    protected override void Invalidate(ModelType model)
    {
      TextLabel.Text = model.Title;
    }
  }
}

