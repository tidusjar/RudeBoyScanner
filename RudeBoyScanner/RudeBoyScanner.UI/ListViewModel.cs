using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RudeBoyScanner.Core;

namespace RudeBoyScanner.UI
{
    public class ListViewModel : INotifyPropertyChanged
    {
        public ColumnConfig ColumnConfig { get; set; }
        private IEnumerable<Record> _record;
        public IEnumerable<Record> Records
        {
            get { return _record; }
            set
            {
                // The `Records` has updated, trigger the PropertyChanged event
                if (!(Equals(value, _record)))
                {
                    _record = value;

                    var handler = PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs("Records"));
                    }
                }
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
            Records = new List<Record>();
            ColumnConfig = new ColumnConfig
            {
                Columns = new List<Column> 
                { 
                    new Column { Header = "Line No.", Id = 1, DataField = "LineNumber" },
                    new Column { Header = "File", DataField = "File" },
                    new Column { Header = "Content", DataField = "Content" } 
                }
            };
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
