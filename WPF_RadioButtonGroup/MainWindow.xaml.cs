using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_RadioButtonGroup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AccessibleStackPanel_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }

    // Create a StackPanel with a custom AutomationPeer, in order for 
    // it to be exposed through the Control view of the UIA tree.
    public class AccessibleStackPanel : StackPanel
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new AccessibleStackPanelAutomationPeer(this);
        }
    }

    public class AccessibleStackPanelAutomationPeer : FrameworkElementAutomationPeer
    {
        public AccessibleStackPanelAutomationPeer(AccessibleStackPanel owner) :
            base(owner)
        {
        }

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            // This control is logically a container for a group of other control.
            return AutomationControlType.Group;
        }
    }
}
