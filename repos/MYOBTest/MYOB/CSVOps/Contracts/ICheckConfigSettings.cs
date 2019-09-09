using System;
using System.Collections.Generic;
using System.Text;

namespace CSVOps.Contracts
{
    public interface ICheckConfigSettings
    {
        string strFileExt { get; set; }
        string strDelimiter { get; set; }
        string strPayYear { get; set; }
        bool CheckConfigSetting();
    }
}
