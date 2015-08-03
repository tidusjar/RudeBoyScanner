using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RudeBoyScanner.Core;

namespace RudeBoyScanner.UI.ViewModels
{
    public class ListViewModel : INotifyPropertyChanged
    {
        public ColumnConfig ColumnConfig { get; set; }
        private readonly ObservableCollection<Record> _record;
        public ObservableCollection<Record> Records
        {
            get { return _record; }
        }

        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public ListViewModel()
        {
            _record = new ObservableCollection<Record>();
            _record.CollectionChanged += _record_CollectionChanged;
            ColumnConfig = new ColumnConfig
            {
                Columns = new List<Column> 
                { 
                    new Column { Header = "Line No.", Id = 1, DataField = "LineNumber" },
                    new Column { Header = "File", DataField = "File" },
                    new Column { Header = "Word", DataField = "Word" },
                    new Column { Header = "Content", DataField = "Content" } 
                }
            };
        }

        private void _record_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Notify("Record");
        }
    }


    public class ColumnConfig
    {
        public IEnumerable<Column> Columns { get; set; }
    }

    public class Column
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string DataField { get; set; }
    }
}
