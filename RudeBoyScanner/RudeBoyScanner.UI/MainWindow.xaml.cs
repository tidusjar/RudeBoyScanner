using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RudeBoyScanner.Core;
using RudeBoyScanner.UI.ViewModels;

namespace RudeBoyScanner.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FilePath { get; set; }
        public SearchWords SearchWords = new SearchWords();
        public ListViewModel ViewModel { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ListViewModel();
            DataContext = ViewModel;
        }

        private void OpenFileDialogue(object sender, RoutedEventArgs e)
        {
            var path = string.Empty;

            var dlg = new Microsoft.Win32.OpenFileDialog();
            var result = dlg.ShowDialog();

            if (result != true) return;

            var filename = dlg.FileName;
            path = filename;

            FilePath = path;
        }

        private void StartSearch(object sender, RoutedEventArgs e)
        {
            if (Words.AllWords.Count < 1)
            {
                MessageBox.Show("Please enter in some words (File > Search Words", "Please enter words",
                    MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            foreach (var allWord in Words.AllWords.Where(allWord => !SearchWords.Word.Contains(allWord)))
            {
                SearchWords.Word.Add(allWord);
            }

            var slr = new SingleLineReader(FilePath);
            var results = slr.FindTextInSingleFile(SearchWords);

            foreach (var result in results)
                ViewModel.Records.Add(result);
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenSearchWordsSettings(object sender, RoutedEventArgs e)
        {
            var window = new WordList();
            window.Show();
        }
    }
}
