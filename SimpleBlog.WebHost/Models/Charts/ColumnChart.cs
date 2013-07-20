using System.Drawing;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Fullback.WebInterface.Models;

namespace Fullback.WebHost.Models.Charts
{
    public class ColumnChart : BaseChart
    {
        public ColumnChart() : base("columnChart")
        {
            Chart = new Chart {DefaultSeriesType = ChartTypes.Column};
            Title = new Title {Text = "Alert Count By Team (Monthly)"};
            Subtitle = new Subtitle {Text = "Total accumulation of alerts in a month"};
            Legend = new Legend
                {
                    Layout = Layouts.Vertical,
                    Align = HorizontalAligns.Left,
                    VerticalAlign = VerticalAligns.Top,
                    X = 100,
                    Y = 70,
                    Floating = true,
                    BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF")),
                    Shadow = true
                };
            YAxis = new YAxis {Min = 0, Title = new YAxisTitle {Text = "Alert Count"}};
            XAxis = new XAxis {Categories = Months};
            Tooltip = new Tooltip {Formatter = @"function() { return ''+ this.y +' Alerts'; }"};
        }

        public string[] Months
        {
            get
            {
                var months = new[]
                    {
                        "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
                    };
                return months;
            }
        }

        public Highcharts Highchart
        {
            get
            {
                var mailItems = new MailItemModel();

                HChart.InitChart(Chart)
                      .SetTitle(Title)
                      .SetSubtitle(Subtitle)
                      .SetXAxis(XAxis)
                      .SetYAxis(YAxis)
                      .SetLegend(Legend)
                      .SetTooltip(Tooltip)
                      .SetPlotOptions(new PlotOptions
                          {
                              Column = new PlotOptionsColumn
                                  {
                                      PointPadding = 0.2,
                                      BorderWidth = 0
                                  }
                          })
                      .SetSeries(new[]
                          {
                              new Series
                                  {
                                      Name = "Tokyo",
                                      Data = new Data(new object[]
                                          {
                                              49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6,
                                              54.4
                                          })
                                  },
                              new Series
                                  {
                                      Name = "London",
                                      Data = new Data(new object[]
                                          {
                                              48.9, 38.8, 39.3, 41.4, 47.0, 48.3, 59.0, 59.6, 52.4, 65.2, 59.3, 51.2
                                          })
                                  },
                              new Series
                                  {
                                      Name = "New York",
                                      Data = new Data(new object[]
                                          {
                                              83.6, 78.8, 98.5, 93.4, 106.0, 84.5, 105.0, 104.3, 91.2, 83.5, 106.6, 92.3
                                          })
                                  },
                              new Series
                                  {
                                      Name = "Berlin",
                                      Data = new Data(new object[]
                                          {
                                              42.4, 33.2, 34.5, 39.7, 52.6, 75.5, 57.4, 60.4, 47.6, 39.1, 46.8, 51.1
                                          })
                                  }
                          });


                return HChart;
            }
        }
    }
}