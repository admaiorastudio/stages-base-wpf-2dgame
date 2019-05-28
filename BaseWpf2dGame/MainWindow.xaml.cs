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
using System.Windows.Threading;

namespace BaseWpf2dGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        private Game _game;

        public MainWindow()
        {
            InitializeComponent();

            _game = new Game(this.Canvas);

            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromMilliseconds(16);
            _timer.Tick += this.DispatcherTimer_Tick;
            _timer.Start();
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            _game.Update();
            _game.Draw();
        }
    }
}
