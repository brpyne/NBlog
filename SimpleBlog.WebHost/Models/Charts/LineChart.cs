using System;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;

namespace Fullback.WebHost.Models.Charts
{
    public class LineChart : BaseChart
    {
        public LineChart()
            : base("lineChart")
        {
            GlobalOptions = new GlobalOptions
                {
                    Global = new Global {UseUTC = false}
                };

            Chart = new Chart
                {
                    DefaultSeriesType = ChartTypes.Line,
                    MarginRight = 0,
                    MarginBottom = 25,
                    ClassName = "chart",
                    BorderWidth = 1
                };

            XAxis = new XAxis
                {
                    Type = AxisTypes.Datetime,
                    MinRange = 14*24*3600000,
                };

            YAxis = new YAxis
                {
                    Min = 0,
                    StartOnTick = false,
                    EndOnTick = false
                };

            Tooltip = new Tooltip()
                {
                    Formatter = @"function() {
                                        return '<b>'+ this.series.name +'</b><br/>'+
                                    this.x +': '+ this.y;
                                }"
                    };

            Legend = new Legend()
                    {
                        Layout = Layouts.Vertical,
                        Align = HorizontalAligns.Center,
                        VerticalAlign = VerticalAligns.Middle,
                        X = -250,
                        Y = -120,
                        BorderWidth = 1
                    };

            HChart = new Highcharts("lineChart");
        }

        public DateTime StartDate { get; set; }
        public Series[] Series { get; set; }

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