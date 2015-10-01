using UIKit;

namespace Yagnix.YxTable
{
  public static class UITableViewExtensions
  {
    public static void ZeroMargins(this UITableView table)
    {
      table.SeparatorInset = UIEdgeInsets.Zero;
      table.LayoutMargins =  UIEdgeInsets.Zero;

      if ( IosVersion.Major >= 9 )
      {
        table.CellLayoutMarginsFollowReadableWidth = false;
      }
    }
  }
}

