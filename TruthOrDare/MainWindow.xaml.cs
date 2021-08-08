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
using static TruthOrDare.ApplicationContext;

namespace TruthOrDare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PlayerList = new List<Player>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int lineCount = Participants.LineCount;

            for (int i = 0; i < lineCount; i++)
            {
                PlayerList.Add(new Player(Participants.GetLineText(i).Replace("\n", "").Replace("\r", "")));
            }

            if (autosortChkbox.IsChecked == true)
            {
                var rnd = new Random();
                PlayerList.Shuffle();
            }

            // string listText2 = string.Join("\n", PlayerList.Select(r => r.Name));
            // MessageBox.Show(listText2);

            // Open play window
            Window playWindow = new PlayWindow();
            playWindow.Show();
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }
    }
}
