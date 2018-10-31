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

namespace CRMSystem
{
    /// <summary>
    /// Interaction logic for ShowroomManager_mainmenu.xaml
    /// </summary>
    public partial class ShowroomManager_mainmenu : Window
    {
        public ShowroomManager_mainmenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login.b1.backButton(this);
        }

        private void cusComp_btn_Click(object sender, RoutedEventArgs e)
        {
            Login.b1.addWindowAndOpenNextWindow(this, new ShowroomManager_CusComp1());
        }
    }
}
