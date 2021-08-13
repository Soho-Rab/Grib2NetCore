using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grib2NetCore
{
    public class GRIBMessage
    {
        public IndicatorSection IndicatorSection { get; set; }
        public IdentificationSection IdentificationSection { get; set; }
        public GRIBMessage(byte[] bytes, int index)
        {
            IndicatorSection = new IndicatorSection(bytes, index);
            index += IndicatorSection.Length;
            IdentificationSection = new IdentificationSection(bytes, index);
            index += IdentificationSection.Length;
        }
    }
}
