﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SQLDataProducer.ModalWindows
{
    /// <summary>
    /// Interaction logic for ExecutionSummaryWindow.xaml
    /// </summary>
    public partial class ExecutionSummaryWindow : Window
    {
        public ExecutionSummaryWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
