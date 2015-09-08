using System;
using System.Collections.Generic;

namespace Yagnix.YxTable
{
  public class Section
  {
    public string Header { get; set; }
    public string Footer { get; set; }

    public List<CellModel> Cells { get; private set; }

    public Section()
    {
      Cells = new List<CellModel>();
    }
  }
}

