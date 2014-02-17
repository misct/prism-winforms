using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BasicMVVMQuickstart_WinForms.ViewModels;
using Microsoft.Practices.Prism.Mvvm;

namespace BasicMVVMQuickstart_WinForms.Views
{
	public partial class MainWindow : Form, IView
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		MainWindowViewModel _vm;

		public object DataContext
		{
			get { return _vm; }
			set 
			{
				var vm = value as MainWindowViewModel;
				if (_vm == vm)
					return;
				vmSrc.DataSource = _vm = vm;
			}
		}

		private void resetButton_Click(object sender, EventArgs e)
		{
			var cmd = _vm.ResetCommand;
			if (cmd.CanExecute(null))
				cmd.Execute(null);
		}

		private void submitButton_Click(object sender, EventArgs e)
		{
			var cmd = _vm.SubmitCommand;
			if (cmd.CanExecute(null))
				cmd.Execute(null);
		}
	}
}
