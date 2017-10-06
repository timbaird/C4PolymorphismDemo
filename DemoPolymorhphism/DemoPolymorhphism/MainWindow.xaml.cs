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

namespace DemoPolymorhphism
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Fighter vF1 = new Fighter("Tim", 200, "bow");
        Fighter vF2 = new Fighter("James", 20, "punch");

        public MainWindow()
        {
            InitializeComponent();
            labelTim.Content = vF1.vHitpoints.ToString();
            labelJackson.Content = vF2.vHitpoints.ToString();
        }

        private void button_play_click(object sender, RoutedEventArgs e)
        {
            while(vF1.vHitpoints > 0 && vF2.vHitpoints > 0)
            {
                MessageBox.Show(vF1.vName + "  attacking");

                vF1.Attack(vF2);

                labelTim.Content = vF1.vHitpoints.ToString();
                labelJackson.Content = vF2.vHitpoints.ToString();

                MessageBox.Show(vF2.vName + "  attacking");

                vF2.Attack(vF1);

                labelTim.Content = vF1.vHitpoints.ToString();
                labelJackson.Content = vF2.vHitpoints.ToString();
            }

            MessageBox.Show("Game Over");

        }
    }
}
