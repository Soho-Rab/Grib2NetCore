using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Grib2NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] bytes = File.ReadAllBytes("C:\\Users\\LiuHa\\Downloads\\fnl_20210808_00_00.grib2");
            List<GRIBMessage> list = new List<GRIBMessage>();
            for (int i = 0; i < bytes.Length;)
            {
                GRIBMessage ds = new GRIBMessage(bytes, i);
                list.Add(ds);
                i += ds.IndicatorSection.TotalLength;
            }
        }
    }
}
