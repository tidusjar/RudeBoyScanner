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

namespace RudeBoyScanner.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FilePath { get; set; }
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
            var slr = new SingleLineReader(FilePath);
            var results = slr.FindLineNumberAndPosition("Text to search for"); //TODO
            ViewModel.Records = results;
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
