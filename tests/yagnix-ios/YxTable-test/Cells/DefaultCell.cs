using UIKit;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class DefaultCell<ModelType> : AbstractCell<ModelType> where ModelType : ItemWithTitle
  {

    public DefaultCell(string reuseId) : base(reuseId, UITableViewCellStyle.Default)
    {
    }

    protected override void Invalidate(ModelType model)
    {
      TextLabel.Text = model.Title;
    }

  }
}

