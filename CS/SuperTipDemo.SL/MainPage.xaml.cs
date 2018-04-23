using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;

namespace SuperTipDemo.SL {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            InitializeSuperTipFromCode();
        }

        private void InitializeSuperTipFromCode() {
            SuperTip tip = new SuperTip();
            SuperTipControl tipControl = new SuperTipControl();
            tipControl.SuperTip = tip;
            SuperTipHeaderItem header = new SuperTipHeaderItem();
            header.Content = "New";
            SuperTipItem item = new SuperTipItem();
            item.Content = "Create a new document";

            SuperTipItem item2 = new SuperTipItem();
            item2.Content = "Opens a new document in a new tab";

            tip.Items.Add(header);
            tip.Items.Add(item);
            tip.Items.Add(new SuperTipItemSeparator());
            tip.Items.Add(item2);

            FrameworkElementHelper.SetToolTip(stdBtn, tipControl);
            barBtn.SuperTip = tip;
            bNewCode.SuperTip = tip;
        }

        private void HideGrids() {
            if(stdCtrlFromCode == null) return;
            stdCtrlFromCode.Visibility = Visibility.Collapsed;
            stdCtrlFromXaml.Visibility = Visibility.Collapsed;
            barFromCode.Visibility = Visibility.Collapsed;
            barFromXAML.Visibility = Visibility.Collapsed;
            RibbonFromCode.Visibility = Visibility.Collapsed;
            RibbonFromXAML.Visibility = Visibility.Collapsed;
        }

        private void thRadioButton_Checked(object sender, RoutedEventArgs e) {
            RadioButton rb = e.OriginalSource as RadioButton;
            if(rb == null) return;
            string themeName = rb.Content.ToString();
            ThemeManager.ApplicationThemeName = themeName;
        }

        private void ctrlRadioButton_Checked(object sender, RoutedEventArgs e) {
            RadioButton rb = sender as RadioButton;
            if(rb == null || stdCtrlFromCode == null) return;
            HideGrids();
            if(rb.Content.ToString() == "Standard Controls") {
                stdCtrlFromCode.Visibility = Visibility.Visible;
                stdCtrlFromXaml.Visibility = Visibility.Visible;
            } else if(rb.Content.ToString() == "Bars") {
                barFromCode.Visibility = Visibility.Visible;
                barFromXAML.Visibility = Visibility.Visible;
            } else {
                RibbonFromCode.Visibility = Visibility.Visible;
                RibbonFromXAML.Visibility = Visibility.Visible;
            }
        }
    }
}
