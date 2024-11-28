using CoolProp;
using SharpProp;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PropertyLookerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FluidViewModel FluidVM = new FluidViewModel(FluidsList.Methane);
        public MainWindow()
        {
            InitializeComponent();
            DataContext = FluidVM;
        }
    }
}