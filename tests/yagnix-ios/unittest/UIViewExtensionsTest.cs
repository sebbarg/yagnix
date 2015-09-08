using System;
using System.Threading.Tasks;
using NUnit.Framework;
using UIKit;
using Yagnix;

namespace unittest
{
  [TestFixture]
  public class UIViewExtensionsTest
  {

    [Test]
    public void CanGetParentController()
    {
      var controller = new UIViewController();
      var view1 = new UIView();

      controller.View.Add(view1);

      var view2 = new UIView();
      view1.Add(view2);

      Assert.IsTrue(view1.ParentController() == controller);
      Assert.IsTrue(view2.ParentController() == controller);
    }
  }

}

