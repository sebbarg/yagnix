using UIKit;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class CustomCellFactory2 : AbstractCellFactory
  {
    public override UITableViewCell Create()
    {
      return new CustomCell2(ReuseId);
    }
  }
}

