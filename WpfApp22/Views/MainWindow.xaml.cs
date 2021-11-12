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
using WpfApp22.Models;
using WpfApp22.ViewModels;

namespace WpfApp22
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var mnv = new MainViewModel(new List<Card>
            {
                new Card
                {
                    Name = "A",
                    Surname = "B",
                    CardNumber = 1234567890987654,
                    Money = 145
                },
                new Card
                {
                    Name = "C",
                    Surname = "D",
                    CardNumber = 9876543210987654,
                    Money = 178
                },
                new Card
                {
                    Name = "E",
                    Surname = "F",
                    CardNumber = 1234567890123456,
                    Money = 406
                },
                new Card
                {
                    Name = "G",
                    Surname = "H",
                    CardNumber = 1234560123456789,
                    Money = 290
                },
            });

            this.DataContext = mnv;
        }
    }
}
