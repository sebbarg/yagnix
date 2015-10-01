using System;
using Foundation;

namespace Yagnix
{
  public static class IosVersion
  {
    public static int Major { get; private set; }
    public static int Minor { get; private set; }

    static IosVersion()
    {
      using ( var pi = new NSProcessInfo() )  
      {
        Major = (int)pi.OperatingSystemVersion.Major;
        Minor = (int)pi.OperatingSystemVersion.Minor;
      }
    }
  }
}

