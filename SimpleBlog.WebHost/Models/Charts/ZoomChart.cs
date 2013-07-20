using System;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Fullback.Data;

namespace Fullback.WebHost.Models.Charts
{
    public class ZoomChart : BaseChart
    {
        public ZoomChart() : base("zoomChart")
        {
            GlobalOptions = new GlobalOptions {Global = new Global {UseUTC = false}};

            Chart = new Chart {ZoomType = ZoomTypes.X, SpacingRight = 20};

            Title = new Title {Text = String.Empty};
            Subtitle = new Subtitle {Text = String.Empty};

            XAxis = new XAxis
                {
                    Title = new XAxisTitle() { Text = String.Empty },
                    Type = AxisTypes.Datetime,
                    MinRange = 14*24*3600000,
                };

            YAxis = new YAxis
                {
                    Title = new YAxisTitle() { Text = String.Empty },
                    Min = 0,
                    StartOnTick = false,
                    EndOnTick = false
                };

            Tooltip = new Tooltip {Shared = true};

            Legend = new Legend {Enabled = false};

            HChart = new Highcharts(ChartName);

            Series = new Series
                {
                    Type = ChartTypes.Area,
                };
        }

        public Series Series { get; set; }
        public DateTime StartDate { get; set; }

        public Team Team { get; set; }

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
                      .SetPlotOptions(PlotOptions)
                      .SetSeries(Series);

                return HChart;
            }
        }


        public PlotOptions PlotOptions
        {
            get
            {
                return new PlotOptions
                    {
                        Area = new PlotOptionsArea
                            {
                                FillColor = new BackColorOrGradient(new Gradient
                                    {
                                        LinearGradient = new[] {0, 0, 0, 300},
                                        Stops = new object[,] {{0, "rgb(64, 96, 126)"}, {1, "rgb(29, 55, 80)"}}
                                    }),
                                LineWidth = 1,
                                Marker = new PlotOptionsAreaMarker
                                    {
                                        Enabled = false,
                                        States = new PlotOptionsAreaMarkerStates
                                            {
                                                Hover = new PlotOptionsAreaMarkerStatesHover
                                                    {
                                                        Enabled = true,
                                                        Radius = 5
                                                    }
                                            }
                                    },
                                Shadow = false,
                                States =
                                    new PlotOptionsAreaStates {Hover = new PlotOptionsAreaStatesHover {LineWidth = 1}},
                                PointInterval = 24*3600*1000,
                                PointStart = new PointStart(StartDate)
                            }
                    };
            }
        }
    }
}