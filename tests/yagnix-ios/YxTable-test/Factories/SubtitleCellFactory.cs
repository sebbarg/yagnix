using UIKit;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class SubtitleCellFactory : AbstractCellFactory
  {
    public override UITableViewCell Create()
    {
      return new SubtitleCell<ItemWithTitleAndSubtitle>(ReuseId);
    }
  }
}

