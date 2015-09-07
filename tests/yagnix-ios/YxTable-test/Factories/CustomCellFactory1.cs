using UIKit;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class CustomCellFactory1 : AbstractCellFactory
  {
    public override UITableViewCell Create()
    {
      return new CustomCell1(ReuseId);
    }
  }
}

