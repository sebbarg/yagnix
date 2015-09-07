using System;
using System.Collections.Generic;

namespace Yagnix.YxTable
{
  public class Section<ModelType>
  {
    public string Header { get; set; }
    public string Footer { get; set; }

    public List<CellModel<ModelType>> Items { get; private set; }

    public Section()
    {
      Items = new List<CellModel<ModelType>>();
    }
  }
}

