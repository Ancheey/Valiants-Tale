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

namespace Valiants_Tale.Resources.Controls
{
    /// <summary>
    /// Logika interakcji dla klasy ActionWindow.xaml
    /// </summary>
    public partial class ActionWindow : Window
    {
        public ActionWindow()
        {
            InitializeComponent();
            Deactivated += CloseWindow;
        }
        void CloseWindow(object o, EventArgs e)
        {
            Close();
        }
    }
}
