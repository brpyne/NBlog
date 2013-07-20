using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Options;

namespace Fullback.WebHost.ViewModels.Charts
{
    public class MailItemStatistics : BaseChart
    {
        public MailItemStatistics() : base("alertCountColumnChart")
        {
        }

        public Highcharts Highchart
        {
            get
            {
                HChart.SetOptions(GlobalOptions)
                      .InitChart(Chart)
                      .SetTitle(Title)
                      .SetSubtitle(Subtitle)
                      .SetXAxis(XAxis)
                      .SetYAxis(YAxis)
                      .SetTooltip(Tooltip)
                      .SetLegend(Legend)
                    //.SetPlotOptions(PlotOptions)
                      .SetSeries(new Series
                          {
                              Type = ChartTypes.Area,
                              Name = "Alert Count",
                              //Data = ChartData
                          });

                return HChart;
            }
        }
    }
}