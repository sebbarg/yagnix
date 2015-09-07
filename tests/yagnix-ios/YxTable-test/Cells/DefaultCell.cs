using UIKit;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class DefaultCell : AbstractCell<IModel>
  {
    ItemWithTitle _model;

    public DefaultCell(string reuseId) : base(reuseId, UITableViewCellStyle.Default)
    {
    }

    public override void Update(IModel model)
    {
      _model = (ItemWithTitle)model;
      TextLabel.Text = _model.Title;
    }
  }
}

