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

		public object DataContext
		{
			get
			{
				return vmSrc.DataSource;
			}
			set
			{
				vmSrc.DataSource = value;
			}
		}
	}
}
