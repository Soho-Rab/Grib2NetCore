using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grib2NetCore
{
    public class IdentificationSection
    {
        public int Section { get; set; }
        public int Length { get; set; }
        public int Center { get; set; }
        public int SubCenter { get; set; }
        public MasterTableVersion MasterTableVersion { get; set; }
        public LocalTableVersion LocalTableVersion { get; set; }
        public SignificanceOfReferenceTime SignificanceOfReferenceTime { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
        public ProductionStatusOfProcessedData ProductionStatusOfProcessedData { get; set; }
        public TypeOfProcessedData TypeOfProcessedData { get; set; }

        public IdentificationSection(byte[] bytes, int index)
        {
            Length = BitConverter.ToInt32(new byte[] { bytes[index++], bytes[index++], bytes[index++], bytes[index++] }.Reverse().ToArray());
            Section = bytes[index++];
            Center = BitConverter.ToInt16(new byte[] { bytes[index++], bytes[index++] }.Reverse().ToArray());
            SubCenter = BitConverter.ToInt16(new byte[] { bytes[index++], bytes[index++] }.Reverse().ToArray());
            MasterTableVersion = (MasterTableVersion)bytes[index++];
            LocalTableVersion = (LocalTableVersion)bytes[index++];
            SignificanceOfReferenceTime = (SignificanceOfReferenceTime)bytes[index++];
            Year = BitConverter.ToInt16(new byte[] { bytes[index++], bytes[index++] }.Reverse().ToArray());
            Month = bytes[index++];
            Day = bytes[index++];
            Hour = bytes[index++];
            Minute = bytes[index++];
            Second = bytes[index++];
            ProductionStatusOfProcessedData = (ProductionStatusOfProcessedData)bytes[index++];
            TypeOfProcessedData = (TypeOfProcessedData)bytes[index++];
        }
    }

    public enum MasterTableVersion
    {
        Experimental = 0,
        VersionImplementedOn20011107 = 1,
        VersionImplementedOn20031104 = 2,
        VersionImplementedOn20051102 = 3,
        VersionImplementedOn20071107 = 4,
        VersionImplementedOn20091104 = 5,
        VersionImplementedOn20100915 = 6,
        VersionImplementedOn20110504 = 7,
        VersionImplementedOn20111108 = 8,
        VersionImplementedOn20120502 = 9,
        VersionImplementedOn20121107 = 10,
        VersionImplementedOn20130508 = 11,
        VersionImplementedOn20131114 = 12,
        VersionImplementedOn20140507 = 13,
        VersionImplementedOn20141105 = 14,
        VersionImplementedOn20150506 = 15,
        VersionImplementedOn20151111 = 16,
        VersionImplementedOn20160504 = 17,
        VersionImplementedOn20161102 = 18,
        VersionImplementedOn20170503 = 19,
        VersionImplementedOn20171108 = 20,
        VersionImplementedOn20180502 = 21,
        VersionImplementedOn20181107 = 22,
        VersionImplementedOn20190515 = 23,
        VersionImplementedOn20191106 = 24,
        PreOperationalToBeImplementedByNextAmendment = 25,
        Missing = 255,
    }

    public enum LocalTableVersion
    {
        None = 0,
        Local = 1,
        Missing = 255
    }

    public enum SignificanceOfReferenceTime
    {
        Analysis = 0,
        StartOfForecast = 1,
        VerifyingTimeOfForecast = 2,
        ObservationTime = 3,
        Missing = 255
    }

    public enum ProductionStatusOfProcessedData
    {
        OperationalProducts = 0,
        OperationalTestProducts = 1,
        ResearchProducts = 2,
        ReAnalysisProducts = 3,
        THORPEXInteractiveGrandGlobalEnsembleTIGGE = 4,
        THORPEXInteractiveGrandGlobalEnsembleTIGGETest = 5,
        S2SOperationalProducts = 6,
        S2STestProducts = 7,
        UncertaintiesInEnsemblesOfRegionalReanalysisProjectUERRA = 8,
        UncertaintiesInEnsemblesOfRegionalReanalysisProjectUERRATest = 9,
        Missing = 255
    }

    public enum TypeOfProcessedData
    {
        AnalysisProducts = 0,
        ForecastProducts = 1,
        AnalysisAndForecastProducts = 2,
        ControlForecastProducts = 3,
        PerturbedForecastProducts = 4,
        ControlAndPerturbedForecastProducts = 5,
        ProcessedSatelliteObservations = 6,
        ProcessedRadarObservations = 7,
        EventProbability = 8,
        ExperimentalProducts = 192,
        Missing = 255
    }
}
