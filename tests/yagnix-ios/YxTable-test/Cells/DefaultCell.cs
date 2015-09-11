using UIKit;
using Yagnix;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class DefaultCell<ModelType> : AbstractCell<ModelType> where ModelType : ItemWithTitle
  {

    public DefaultCell(string reuseId) : base(reuseId, UITableViewCellStyle.Default)
    {
      //this.LayoutMargins = UIEdgeInsets.Zero;
      //this.SeparatorInset = UIEdgeInsets.Zero;
    }

    protected override void Invalidate(ModelType model)
    {
      TextLabel.Text = model.Title;
    }

  }
}

