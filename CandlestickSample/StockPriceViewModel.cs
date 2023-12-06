using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CandlestickSample
{
    public class StockPriceViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<StockPriceModel> _stockPrices;
      
        public ObservableCollection<StockPriceModel> StockPrices
        {
            get
            {
                return _stockPrices;
            }
            set
            {
                _stockPrices = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StockPrices"));
            }
        }
        public StockPriceViewModel()
        {
            StockPrices = new ObservableCollection<StockPriceModel>(ReadCSV("CandlestickSample.Resources.Raw.tesla.csv"));
        }

        private IEnumerable<StockPriceModel> ReadCSV(string resourceStream)
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream inputStream = executingAssembly.GetManifestResourceStream(resourceStream);

            string? line;
            List<string> lines = new List<string>();
            using StreamReader reader = new StreamReader(inputStream);
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines.Select(line =>
            {
                string[] data = line.Split(',');
                DateTime date = DateTime.ParseExact(data[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                return new StockPriceModel((date), Convert.ToDouble(data[1]), Convert.ToDouble(data[2]), Convert.ToDouble(data[3]), Convert.ToDouble(data[4]));
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
