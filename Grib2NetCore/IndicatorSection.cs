using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grib2NetCore
{
    public class IndicatorSection
    {
        public int Section { get; set; }
        public int Length { get; set; }
        public string Indicator { get; set; }
        public DisciplineOfProcessedData Discipline { get; set; }
        public GRIBEdition Edition { get; set; }
        public int TotalLength { get; set; }

        public IndicatorSection(byte[] bytes, int index)
        {
            Section = 0;
            Length = 16;
            Indicator = Encoding.ASCII.GetString(new byte[] { bytes[index++], bytes[index++], bytes[index++], bytes[index++] }.ToArray());
            if (Indicator != "GRIB")
            {
                throw new Exception("Invalid file start.");
            }
            index++;
            index++;
            Discipline = (DisciplineOfProcessedData)bytes[index++];
            Edition = (GRIBEdition)bytes[index++];
            TotalLength = (int)BitConverter.ToInt64(new byte[] { bytes[index++], bytes[index++], bytes[index++], bytes[index++], bytes[index++], bytes[index++], bytes[index++], bytes[index++] }.Reverse().ToArray());
        }
    }

    public enum DisciplineOfProcessedData
    {
        MeteorologicalProducts = 0,
        HydrologicalProducts = 1,
        LandSurfaceProducts = 2,
        SatelliteRemoteSensingProducts = 3,
        SpaceWeatherProducts = 4,
        OceanographicProducts = 10,
        Missing = 255
    }

    public enum GRIBEdition
    {
        GRIB = 1,
        GRIB2 = 2
    }
}
