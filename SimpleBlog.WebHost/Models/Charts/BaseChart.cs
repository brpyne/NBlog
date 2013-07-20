using System;
using DotNet.Highcharts;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;

namespace Fullback.WebHost.Models.Charts
{
    public class BaseChart
    {
        public string ChartName = "chart";
        protected Highcharts HChart;

        public BaseChart()
        {
            HChart = new Highcharts(ChartName);
        }

        public BaseChart(string chartName):this()
        {
            ChartName = chartName;
        }

        public GlobalOptions GlobalOptions { get; set; }

        public Chart Chart { get; set; }

        public Title Title { get; set; }

        public Subtitle Subtitle { get; set; }

        public XAxis XAxis { get; set; }

        public YAxis YAxis { get; set; }

        public Tooltip Tooltip { get; set; }

        public Legend Legend { get; set; }
    }
}