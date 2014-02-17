namespace BasicMVVMQuickstart_WinForms.Views
{
	partial class QuestionnaireView
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.colorLabel = new System.Windows.Forms.Label();
			this.questInput = new System.Windows.Forms.TextBox();
			this.dataSrc = new System.Windows.Forms.BindingSource(this.components);
			this.vmSrc = new System.Windows.Forms.BindingSource(this.components);
			this.questLabel = new System.Windows.Forms.Label();
			this.ageInput = new System.Windows.Forms.NumericUpDown();
			this.ageLabel = new System.Windows.Forms.Label();
			this.nameInput = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.colorInput = new System.Windows.Forms.ListBox();
			this.colorSrc = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.dataSrc)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.vmSrc)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ageInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.colorSrc)).BeginInit();
			this.SuspendLayout();
			// 
			// colorLabel
			// 
			this.colorLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.colorLabel.Location = new System.Drawing.Point(0, 126);
			this.colorLabel.Name = "colorLabel";
			this.colorLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 3);
			this.colorLabel.Size = new System.Drawing.Size(477, 22);
			this.colorLabel.TabIndex = 15;
			this.colorLabel.Text = "What is your favorite color?";
			// 
			// questInput
			// 
			this.questInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataSrc, "Quest", true));
			this.questInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.questInput.Location = new System.Drawing.Point(0, 106);
			this.questInput.Name = "questInput";
			this.questInput.Size = new System.Drawing.Size(477, 20);
			this.questInput.TabIndex = 14;
			// 
			// dataSrc
			// 
			this.dataSrc.AllowNew = false;
			this.dataSrc.DataMember = "Questionnaire";
			this.dataSrc.DataSource = this.vmSrc;
			// 
			// vmSrc
			// 
			this.vmSrc.DataSource = typeof(BasicMVVMQuickstart_WinForms.ViewModels.QuestionnaireViewModel);
			// 
			// questLabel
			// 
			this.questLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.questLabel.Location = new System.Drawing.Point(0, 84);
			this.questLabel.Name = "questLabel";
			this.questLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 3);
			this.questLabel.Size = new System.Drawing.Size(477, 22);
			this.questLabel.TabIndex = 13;
			this.questLabel.Text = "What is your quest?";
			// 
			// ageInput
			// 
			this.ageInput.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.dataSrc, "Age", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.ageInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.ageInput.Location = new System.Drawing.Point(0, 64);
			this.ageInput.Name = "ageInput";
			this.ageInput.Size = new System.Drawing.Size(477, 20);
			this.ageInput.TabIndex = 12;
			// 
			// ageLabel
			// 
			this.ageLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.ageLabel.Location = new System.Drawing.Point(0, 42);
			this.ageLabel.Name = "ageLabel";
			this.ageLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 3);
			this.ageLabel.Size = new System.Drawing.Size(477, 22);
			this.ageLabel.TabIndex = 11;
			this.ageLabel.Text = "Age";
			// 
			// nameInput
			// 
			this.nameInput.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dataSrc, "Name", true));
			this.nameInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.nameInput.Location = new System.Drawing.Point(0, 22);
			this.nameInput.Name = "nameInput";
			this.nameInput.Size = new System.Drawing.Size(477, 20);
			this.nameInput.TabIndex = 10;
			// 
			// nameLabel
			// 
			this.nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.nameLabel.Location = new System.Drawing.Point(0, 0);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 3);
			this.nameLabel.Size = new System.Drawing.Size(477, 22);
			this.nameLabel.TabIndex = 9;
			this.nameLabel.Text = "Name";
			// 
			// colorInput
			// 
			this.colorInput.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.dataSrc, "FavoriteColor", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
			this.colorInput.DataSource = this.colorSrc;
			this.colorInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.colorInput.FormattingEnabled = true;
			this.colorInput.Location = new System.Drawing.Point(0, 148);
			this.colorInput.Name = "colorInput";
			this.colorInput.Size = new System.Drawing.Size(477, 81);
			this.colorInput.TabIndex = 16;
			// 
			// colorSrc
			// 
			this.colorSrc.DataMember = "AllColors";
			this.colorSrc.DataSource = this.vmSrc;
			// 
			// QuestionnaireView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.colorInput);
			this.Controls.Add(this.colorLabel);
			this.Controls.Add(this.questInput);
			this.Controls.Add(this.questLabel);
			this.Controls.Add(this.ageInput);
			this.Controls.Add(this.ageLabel);
			this.Controls.Add(this.nameInput);
			this.Controls.Add(this.nameLabel);
			this.Name = "QuestionnaireView";
			this.Size = new System.Drawing.Size(477, 229);
			((System.ComponentModel.ISupportInitialize)(this.dataSrc)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.vmSrc)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ageInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.colorSrc)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label colorLabel;
		private System.Windows.Forms.TextBox questInput;
		private System.Windows.Forms.Label questLabel;
		private System.Windows.Forms.NumericUpDown ageInput;
		private System.Windows.Forms.Label ageLabel;
		private System.Windows.Forms.TextBox nameInput;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.ListBox colorInput;
		private System.Windows.Forms.BindingSource vmSrc;
		private System.Windows.Forms.BindingSource dataSrc;
		private System.Windows.Forms.BindingSource colorSrc;
	}
}
