using Microsoft.ML.Data;

namespace Diplom.Models
{
    public class ForecastData
    {
        [LoadColumn(0)]
        public DateTime Date { get; set; }

        [LoadColumn(1)]
        public float TotalVolume { get; set; }
    }

    public class ForecastOutput
    {
        [ColumnName("ForecastedVolume")]
        public float[] Forecast { get; set; }

        [ColumnName("LowerBound")]
        public float[] LowerBound { get; set; }

        [ColumnName("UpperBound")]
        public float[] UpperBound { get; set; }
    }
}
