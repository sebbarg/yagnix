using UIKit;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class SubtitleCell : AbstractCell<IModel>
  {
    ItemWithTitleAndSubtitle _model;

    public SubtitleCell(string reuseId) : base(reuseId, UITableViewCellStyle.Subtitle)
    {
      Accessory = UITableViewCellAccessory.Checkmark;
    }

    public override void Update(IModel model)
    {
      _model = (ItemWithTitleAndSubtitle)model;
      TextLabel.Text = _model.Title;
      DetailTextLabel.Text = _model.SubTitle;
    }
  }
}

