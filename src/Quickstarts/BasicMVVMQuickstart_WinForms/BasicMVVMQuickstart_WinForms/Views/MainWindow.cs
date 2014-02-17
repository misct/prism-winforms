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

			var vm = new MainWindowViewModel();

			this.DataContext = vm;
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
				_vm = vm;
				vmSrc.DataSource = vm;
				qaView.DataContext = (vm != null ?
					vm.QuestionnaireViewModel :
					null);
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
