using System.Collections.Generic;

namespace MedianCalculation
{
    public interface ICalculateMedian
    {
        double GetMedianValueWith20AboveAndBelow(ref double aboue20, ref double below20,List<double> list);
    }
}