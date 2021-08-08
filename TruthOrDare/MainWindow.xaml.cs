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
            ApplicationContext.PlayerList = new List<Player>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int lineCount = Participants.LineCount;

            for (int i = 0; i < lineCount; i++)
            {
                ApplicationContext.PlayerList.Add(new Player(Participants.GetLineText(i)));
            }

            MessageBox.Show(ApplicationContext.PlayerList[0].Name.ToString());
        }
    }
}
