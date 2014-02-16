namespace BasicMVVMQuickstart_WinForms.Views
{
	partial class MainWindow
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.titleLabel = new System.Windows.Forms.Label();
			this.resetButton = new System.Windows.Forms.Button();
			this.submitButton = new System.Windows.Forms.Button();
			this.questionnaireView1 = new BasicMVVMQuickstart_WinForms.Views.QuestionnaireView();
			this.SuspendLayout();
			// 
			// titleLabel
			// 
			this.titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.titleLabel.Font = new System.Drawing.Font("Comic Sans MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.titleLabel.Location = new System.Drawing.Point(16, 8);
			this.titleLabel.Name = "titleLabel";
			this.titleLabel.Size = new System.Drawing.Size(477, 45);
			this.titleLabel.TabIndex = 0;
			this.titleLabel.Text = "Basic MVVM";
			// 
			// resetButton
			// 
			this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.resetButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.resetButton.Location = new System.Drawing.Point(337, 277);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(75, 23);
			this.resetButton.TabIndex = 2;
			this.resetButton.Text = "&Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			// 
			// submitButton
			// 
			this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.submitButton.Location = new System.Drawing.Point(418, 277);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(75, 23);
			this.submitButton.TabIndex = 3;
			this.submitButton.Text = "&Submit";
			this.submitButton.UseVisualStyleBackColor = true;
			// 
			// questionnaireView1
			// 
			this.questionnaireView1.Dock = System.Windows.Forms.DockStyle.Top;
			this.questionnaireView1.Location = new System.Drawing.Point(16, 53);
			this.questionnaireView1.Name = "questionnaireView1";
			this.questionnaireView1.Size = new System.Drawing.Size(477, 229);
			this.questionnaireView1.TabIndex = 1;
			// 
			// MainWindow
			// 
			this.AcceptButton = this.submitButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.resetButton;
			this.ClientSize = new System.Drawing.Size(509, 311);
			this.Controls.Add(this.submitButton);
			this.Controls.Add(this.resetButton);
			this.Controls.Add(this.questionnaireView1);
			this.Controls.Add(this.titleLabel);
			this.MinimumSize = new System.Drawing.Size(525, 350);
			this.Name = "MainWindow";
			this.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
			this.Text = "Basic MVVM Quickstart";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.Button submitButton;
		private QuestionnaireView questionnaireView1;
	}
}