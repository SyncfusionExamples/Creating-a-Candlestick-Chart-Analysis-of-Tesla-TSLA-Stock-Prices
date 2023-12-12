using Syncfusion.Maui.Charts;
namespace CandlestickSample
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

       
        private void DayRange_Changed(object sender, EventArgs e)
        {            
            Label1.Background = Colors.LightSkyBlue;
            Label2.Background = Colors.Transparent;
            Label3.Background = Colors.Transparent;
            Label4.Background = Colors.Transparent;

            xAxis.AutoScrollingDeltaType = DateTimeIntervalType.Days;
            xAxis.AutoScrollingDelta = 7;
        }

        private void WeekRange_Changed(object sender, EventArgs e)
        {
            Label1.Background = Colors.Transparent;
            Label2.Background = Colors.LightSkyBlue;
            Label3.Background = Colors.Transparent;
            Label4.Background = Colors.Transparent;
            xAxis.AutoScrollingDeltaType = DateTimeIntervalType.Days;
            xAxis.AutoScrollingDelta = 15;
        }

        private void MonthRange_Changed(object sender, EventArgs e)
        {
            Label1.Background = Colors.Transparent;
            Label2.Background = Colors.Transparent;
            Label3.Background = Colors.LightSkyBlue;
            Label4.Background = Colors.Transparent;
            xAxis.AutoScrollingMode = Syncfusion.Maui.Charts.ChartAutoScrollingMode.End;
            xAxis.AutoScrollingDeltaType = DateTimeIntervalType.Months;
            xAxis.AutoScrollingDelta = 2;
        }

        private void YearRange_Changed(object sender, EventArgs e)
        {
            Label1.Background = Colors.Transparent;
            Label2.Background = Colors.Transparent;
            Label3.Background = Colors.Transparent;
            Label4.Background = Colors.LightSkyBlue;
            yAxis.Minimum = 90;
            yAxis.Maximum = 320;
            xAxis.AutoScrollingDeltaType = DateTimeIntervalType.Years;
            xAxis.AutoScrollingDelta = 1;
        }

        int month = int.MaxValue;
      
        private void xAxis_LabelCreated(object sender, ChartAxisLabelEventArgs e)
        {
            DateTime baseDate = new(1899, 12, 30);
            var date = baseDate.AddDays(e.Position);
            if (date.Month != month)
            {
                ChartAxisLabelStyle labelStyle = new();
                labelStyle.LabelFormat = "yyyy";
                labelStyle.FontAttributes = FontAttributes.Bold;
                e.LabelStyle = labelStyle;

                month = date.Month;
            }
            else
            {
                ChartAxisLabelStyle labelStyle = new();
                labelStyle.LabelFormat = "MMM-dd";
                e.LabelStyle = labelStyle;
            }
        }
    }

   
}