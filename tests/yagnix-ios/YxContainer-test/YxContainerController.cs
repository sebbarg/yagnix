using System;
using UIKit;
using CoreGraphics;
using Foundation;
using CoreText;
using WebKit;
using Yagnix;
using Yagnix.YxContainer;

namespace YxContainertest
{
  public class YxContainerController : UIViewController
  {
    private readonly UIScrollView _scrollView;

    public YxContainerController() 
    {
      _scrollView = new UIScrollView();
    }

    //

    public override void ViewDidLoad()
    {
      base.ViewDidLoad();
      Title = "Test";

      View.Add(_scrollView);
      _scrollView.BackgroundColor = UIColor.FromRGB(235,235,235); 
      _scrollView.FitToGuides(this, 0);

      for ( var idx = 0; idx < 10; idx++ )
      {
        var container = new Container();

        _scrollView.Add(container);

        if ( _scrollView.Subviews.Length == 1 )
        {
          container.Anchor(NSLayoutAttribute.Top, _scrollView, NSLayoutAttribute.Top, 10);
        }
        else
        {
          var prevView = _scrollView.Subviews[_scrollView.Subviews.Length - 2];
          container.Anchor(NSLayoutAttribute.Top, prevView, NSLayoutAttribute.Bottom, 10);
        }

        container
          .Anchor(NSLayoutAttribute.Left, _scrollView, NSLayoutAttribute.Left, 10)
          .Anchor(NSLayoutAttribute.Width, _scrollView, NSLayoutAttribute.Width, -20);

        container.ExpandedConstraint = 
          NSLayoutConstraint.Create(
            container, 
            NSLayoutAttribute.Height,                
            NSLayoutRelation.Equal,
            _scrollView, 
            NSLayoutAttribute.Height,               
            1, 
            -20);

        container.Header.Text = "hopla";

//        var image = new UIImageView(UIImage.FromBundle("bloodborne.jpg"));
//        container.Content.Add(image);
//        image.FitToParent(0);

        var webView = new WKWebView(new CGRect(), new WKWebViewConfiguration());
        webView.ScrollView.ScrollEnabled = false;
        webView.Layer.BackgroundColor = UIColor.White.CGColor;

        container.Content = webView;

        webView.LoadRequest(new NSUrlRequest(new NSUrl("https://www.google.com")));
      }

      var finalView = _scrollView.Subviews[_scrollView.Subviews.Length - 1];
      finalView.Anchor(NSLayoutAttribute.Bottom, _scrollView, NSLayoutAttribute.Bottom, -10);
    }

    public override void ViewDidLayoutSubviews()
    {
      base.ViewDidLayoutSubviews();
      _scrollView.ContentInset = UIEdgeInsets.Zero;
    }

  }
}

