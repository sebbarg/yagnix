using System;

namespace Yagnix.YxTable
{
  public class CellSelectedEventArgs<ModelType> : EventArgs
  {
    public ModelType Model { get; set; }
  }
}

