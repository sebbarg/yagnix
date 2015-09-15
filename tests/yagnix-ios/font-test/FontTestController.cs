using System;
using UIKit;
using CoreGraphics;
using Foundation;
using CoreText;
using Yagnix;
using Yagnix.YxTable;

namespace fonttest
{
  public class FontTestController : UIViewController
  {
    private UITableView _view;

    public FontTestController()
    {
      Console.WriteLine($"Version {UIDevice.CurrentDevice.SystemVersion}");
    }

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();

      Title = "Font test";

      _view = new UITableView(new CGRect(), UITableViewStyle.Grouped);
      View.Add(_view);

      _view.FitToParent();

      var cellFactory = new FontCellFactory();

      var source = new FontTableSource();
      _view.Source = source;

      Section section;
      UIFont font;
      FontModel fontModel;

      // --------------------------------------------------

      section = new Section();
      source.Sections.Add(section);

      section.Header = "Defaults";

      font = UIFont.PreferredBody;
      fontModel = new FontModel {
        Text = $"{font.PointSize} PreferredBody",
        Font = font
      };
      section.Cells.Add(new CellModel<FontModel>(cellFactory, fontModel));

      font = UIFont.PreferredCaption1;
      fontModel = new FontModel {
        Text = $"{font.PointSize} PreferredCaption1",
        Font = font
      };
      section.Cells.Add(new CellModel<FontModel>(cellFactory, fontModel));

      font = UIFont.PreferredCaption2;
      fontModel = new FontModel {
        Text = $"{font.PointSize} PreferredCaption2",
        Font = font
      };
      section.Cells.Add(new CellModel<FontModel>(cellFactory, fontModel));

      font = UIFont.PreferredFootnote;
      fontModel = new FontModel {
        Text = $"{font.PointSize} PreferredFootnote",
        Font = font
      };
      section.Cells.Add(new CellModel<FontModel>(cellFactory, fontModel));

      font = UIFont.PreferredHeadline;
      fontModel = new FontModel {
        Text = $"{font.PointSize} PreferredHeadline",
        Font = font
      };
      section.Cells.Add(new CellModel<FontModel>(cellFactory, fontModel));

      font = UIFont.PreferredSubheadline;
      fontModel = new FontModel {
        Text = $"{font.PointSize} PreferredSubheadline",
        Font = font
      };
      section.Cells.Add(new CellModel<FontModel>(cellFactory, fontModel));

      // --------------------------------------------------

      section = new Section();
      source.Sections.Add(section);

      font = UIFont.SystemFontOfSize(UIFont.LabelFontSize);
      section.Header = font.Name;

      fontModel = new FontModel {
        Text = $"{font.PointSize} the quick brown fox jumps over the lazy dog",
        Font = font
      };
      section.Cells.Add(new CellModel<FontModel>(cellFactory, fontModel));

      for ( int size = 3; size <= 60; size += 3 )
      {
        font = UIFont.SystemFontOfSize(size);
        fontModel = new FontModel {
          Text = $"{font.PointSize} the quick brown fox jumps over the lazy dog",
          Font = font
        };
        section.Cells.Add(new CellModel<FontModel>(cellFactory, fontModel));
      }
    }
  }


}

