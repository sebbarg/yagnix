using UIKit;
using Yagnix.YxTable;

namespace YxTableTest
{
  public class DefaultCellFactory : AbstractCellFactory
  {
    public override UITableViewCell Create()  
    {
      return new DefaultCell(ReuseId);
    }
  }
}

