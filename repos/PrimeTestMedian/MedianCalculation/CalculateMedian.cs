using System;
using System.Collections.Generic;
using LoggerService;

namespace MedianCalculation
{
    public class CalculateMedian : ICalculateMedian
    {
        ILoggerManager _logger;

        public CalculateMedian(ILoggerManager logger)
        {
            _logger = logger;
        }
        public double CalcMedian(List<double> list)
        {
            double median =0;
            try
            {
                //order the list in ascending order 
                list.Sort();
                // check the total count even or odd and calculate the median
                int count = list==null ? 0 : list.Count;

                if (count > 2)
                {
                    if (count % 2 == 0)
                        median = (list[count / 2] + list[(count / 2) + 1]) / 2;
                    else
                        median = list[count / 2];
                }
                else if (count == 2)
                {
                    median = (list[count - 2] + list[count - 1]) / 2;
                }
                else if(count == 1)
                {
                    median = list[count-1];
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"error in CalcMedian " + ex.Message);
                throw ex;
            }

            return median;

        }

        public double GetMedianValueWith20AboveAndBelow(ref double aboue20,ref double below20, List<double> list)
        {
            var median = CalcMedian(list);
            aboue20 = median + median * 20 / 100;
            below20 = median - median * 20 / 100;
            return median;
        }
    }
}
