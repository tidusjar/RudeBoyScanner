using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RudeBoyScanner.Core;

namespace RudeBoyScanner.UI.ViewModels
{
    public class WordListViewModel : INotifyPropertyChanged
    {
        public ColumnConfig WordColumnConfig { get; set; }
        private readonly ObservableCollection<string> _wordList;
        public ObservableCollection<string> WordList
        {
            get { return _wordList; }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public WordListViewModel()
        {

            _wordList = new ObservableCollection<string>();
            _wordList.CollectionChanged +=_wordList_CollectionChanged;

            WordColumnConfig = new ColumnConfig
            {
                Columns = new List<Column> 
                { 
                    new Column { Header = "Word", DataField = "WordList" },
                }
            };
        }

        private void _wordList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Notify("WordList");
        }
        
        protected void Notify(string propName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
