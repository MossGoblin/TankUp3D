using System;
using System.Collections.Generic;
using System.Text;

public struct SensorPackage : IProduct
{
    public int NumberOfAgents;
    public int TotalSizeOfAgents;
    public int MaxSizeOfAgents;
    public bool LayersInRange;
    public bool UpgradesInRange;
}
