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
using System.Windows.Shapes;
using TaskLinerClientApp.Controls;

namespace TaskLinerClientApp
{
    /// <summary>
    /// Логика взаимодействия для MakeCompanyWindow.xaml
    /// </summary>
    public partial class MakeCompanyWindow : Window, ICloseable
    {
        public MakeCompanyWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
