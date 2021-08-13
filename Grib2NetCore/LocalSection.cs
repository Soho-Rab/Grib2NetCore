using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grib2NetCore
{
    public class LocalSection
    {
        public int Section { get; set; }
        public int Length { get; set; }

        public LocalSection(byte[] bytes, int index)
        {
            Length = BitConverter.ToInt32(new byte[] { bytes[index++], bytes[index++], bytes[index++], bytes[index++] }.Reverse().ToArray());
            Section = bytes[index++];
        }
    }
}
