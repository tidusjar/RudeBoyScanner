using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using RudeBoyScanner.UI.ViewModels;

namespace RudeBoyScanner.UI
{
    /// <summary>
    /// Interaction logic for WordList.xaml
    /// </summary>
    public partial class WordList
    {
        public WordListViewModel Model { get; set; }
        public WordList()
        {
            InitializeComponent();
            Model = new WordListViewModel();
            DataContext = Model;

            foreach (var word in UI.Words.AllWords.Where(word => !Model.WordList.Contains(word)))
            {
                Model.WordList.Add(word);
            }
        }

        private void AddWord(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(WordBox.Text))
            {
                MessageBox.Show("Please enter something in", "Enter a word", MessageBoxButton.OK, MessageBoxImage.Stop, MessageBoxResult.OK);
                return;
            }

            Model.WordList.Add(WordBox.Text);
            UI.Words.AllWords.Add(WordBox.Text);
        }
    }
}
