using System;
using UIKit;
using Yagnix;
using Yagnix.YxTable;

namespace fonttest
{
  public class FontModel
  {
    public string Text { get; set; }
    public UIFont Font { get; set; }
  }

  public class FontCellFactory : AbstractCellFactory
  {
    public override UITableViewCell Create()  
    {
      return new FontCell<FontModel>(ReuseId);
    }
  }

  //

  public class FontCell<ModelType> : AbstractCell<ModelType> where ModelType : FontModel
  {
    private readonly UILabel _label;

    public FontCell(string reuseId) : base(reuseId, UITableViewCellStyle.Default)
    {
      _label = ContentView.Add<UILabel>();
      _label.FitToMargin();
    }

    protected override void Invalidate(ModelType model)
    {
      _label.Text = model.Text;
      _label.Font = model.Font;     
    }
  }

  //

  public class FontTableSource : TableSource
  {
    public FontTableSource() : base()
    {
    }

    public FontTableSource(Section section) : base(section)
    {
    }

    public override nfloat GetHeightForRow(UITableView tableView, Foundation.NSIndexPath indexPath)
    {
      var cellModel = Sections[indexPath.Section].Cells[indexPath.Row];
      var cell = cellModel.GetCell(tableView);

      return cell.SystemLayoutSizeFittingSize(UIView.UILayoutFittingCompressedSize).Height;
    }
  }


}

