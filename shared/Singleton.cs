namespace Yagnix
{
  public static class Singleton<T> where T : new()
  {
    public static T _ { get; }
    static Singleton()
    {
      _ = new T();
    }
  }
}

