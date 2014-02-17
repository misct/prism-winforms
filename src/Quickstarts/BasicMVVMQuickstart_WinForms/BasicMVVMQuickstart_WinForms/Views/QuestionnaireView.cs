using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.Prism.Mvvm;
using BasicMVVMQuickstart_WinForms.ViewModels;

namespace BasicMVVMQuickstart_WinForms.Views
{
	public partial class QuestionnaireView : UserControl, IView
	{
		public QuestionnaireView()
		{
			InitializeComponent();
		}

		QuestionnaireViewModel _vm;

		[DefaultValue(null)]
		public object DataContext
		{
			get
			{
				return _vm;
			}
			set
			{
				var vm = value as QuestionnaireViewModel;
				if (_vm == vm)
					return;
				vmSrc.DataSource = _vm = vm;
			}
		}
	}
}
