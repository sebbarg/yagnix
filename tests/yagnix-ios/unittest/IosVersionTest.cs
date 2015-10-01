using System;
using System.Threading.Tasks;
using NUnit.Framework;
using UIKit;
using Yagnix;

namespace unittest
{
  [TestFixture]
  public class IosVersionTest
  {

    [Test]
    public void TestVersion()
    {
      var version = UIDevice.CurrentDevice.SystemVersion;
      var majorMinor = version.Split(new [] { "." }, StringSplitOptions.RemoveEmptyEntries);

      Assert.IsTrue(majorMinor.Length >= 2);
      Assert.IsTrue(Int32.Parse(majorMinor[0]) > 0);
      Assert.AreEqual(Int32.Parse(majorMinor[0]), IosVersion.Major);
      Assert.AreEqual(Int32.Parse(majorMinor[1]), IosVersion.Minor);
    }
  }

}

