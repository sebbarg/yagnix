using UIKit;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class SubtitleCell<ModelType> : AbstractCell<ModelType> where ModelType : ItemWithTitleAndSubtitle
  {
    public SubtitleCell(string reuseId) : base(reuseId, UITableViewCellStyle.Subtitle)
    {
      Accessory = UITableViewCellAccessory.Checkmark;
    }

    protected override void Invalidate(ModelType model)
    {
      TextLabel.Text = model.Title;
      DetailTextLabel.Text = model.SubTitle;
    }
  }
}

