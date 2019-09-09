using System;
using System.Collections.Generic;
using System.Text;

namespace PayRollCalculation
{
    public interface IPrintData
    {
        void Printdata(List<PayrollOut> pFileList);
    }
}
