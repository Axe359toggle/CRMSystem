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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ShowroomManager_CusComp1 : Window
    {
        public ShowroomManager_CusComp1()
        {
            InitializeComponent();
        }

        private void back_btn_Click(object sender, RoutedEventArgs e)
        {
            Login.b1.backButton(this);
        }

        private void next_btn_Click(object sender, RoutedEventArgs e)
        {
            Login.b1.addWindowAndOpenNextWindow(this, new CustomerInsert());
        }
    }
}
