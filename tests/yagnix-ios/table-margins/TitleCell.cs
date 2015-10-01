using System;
using UIKit;
using Foundation;
using System.Drawing;
using Yagnix;
using Yagnix.YxTable;

namespace tablemargins
{
  public class ItemWithTitle
  {
    public string Title { get; set; }
  }

  public class TitleCellFactory : AbstractCellFactory
  {
    public Action<TitleCell<ItemWithTitle>> CellSelected { get; set; }

    public override UITableViewCell Create()  
    {   
      return new TitleCell<ItemWithTitle>(
        ReuseId, 
        CellSelected
      );
    }
  }

  //

  public class TitleCell<ModelType> : AbstractCell<ModelType> where ModelType : ItemWithTitle
  {
    private readonly Action<TitleCell<ModelType>> _cellSelected;

    public TitleCell(
      string reuseId,
      Action<TitleCell<ModelType>> cellSelected) : base(reuseId, UITableViewCellStyle.Default)
    {
      _cellSelected = cellSelected;
      Accessory = UITableViewCellAccessory.DisclosureIndicator;
      ZeroMargins();
    }

    //

    protected override void Invalidate(ModelType model)
    {
      TextLabel.Text = model.Title;
    }

    //

    public override void SelectCell()
    {
      if ( _cellSelected != null )
      {
        _cellSelected(this);
      }
    }

  }

  //
}
               


                                                                    