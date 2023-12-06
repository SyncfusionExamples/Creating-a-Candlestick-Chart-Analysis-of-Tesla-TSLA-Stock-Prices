using Syncfusion.Maui.Charts;
namespace CandlestickSample
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void segmentedControl_SelectionChanged(object sender, Syncfusion.Maui.Buttons.SelectionChangedEventArgs e)
        {
            xAxis.AutoScrollingMode = Syncfusion.Maui.Charts.ChartAutoScrollingMode.Start;

            switch (e.NewIndex)
            {
                case 0:
                    xAxis.AutoScrollingDeltaType = DateTimeIntervalType.Days;
                    xAxis.AutoScrollingDelta = 7;
                    break;

                case 1:
                    xAxis.AutoScrollingDeltaType = DateTimeIntervalType.Days;
                    xAxis.AutoScrollingDelta = 15;
                    break;

                case 2:
                    xAxis.AutoScrollingDeltaType = DateTimeIntervalType.Months;
                    xAxis.AutoScrollingDelta = 4;
                    break;

                case 3:
                    xAxis.AutoScrollingDeltaType = DateTimeIntervalType.Years;
                    xAxis.AutoScrollingDelta = 1;
                    break;

                default:
                    break;
            }
        }
    }
}