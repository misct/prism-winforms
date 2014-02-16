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
			this.colorGroup = new System.Windows.Forms.GroupBox();
			this.colorGreenInput = new System.Windows.Forms.RadioButton();
			this.colorBlueInput = new System.Windows.Forms.RadioButton();
			this.colorRedInput = new System.Windows.Forms.RadioButton();
			this.colorLabel = new System.Windows.Forms.Label();
			this.questInput = new System.Windows.Forms.TextBox();
			this.questLabel = new System.Windows.Forms.Label();
			this.ageInput = new System.Windows.Forms.NumericUpDown();
			this.ageLabel = new System.Windows.Forms.Label();
			this.nameInput = new System.Windows.Forms.TextBox();
			this.nameLabel = new System.Windows.Forms.Label();
			this.colorGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ageInput)).BeginInit();
			this.SuspendLayout();
			// 
			// colorGroup
			// 
			this.colorGroup.Controls.Add(this.colorGreenInput);
			this.colorGroup.Controls.Add(this.colorBlueInput);
			this.colorGroup.Controls.Add(this.colorRedInput);
			this.colorGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.colorGroup.Location = new System.Drawing.Point(0, 148);
			this.colorGroup.Name = "colorGroup";
			this.colorGroup.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
			this.colorGroup.Size = new System.Drawing.Size(477, 72);
			this.colorGroup.TabIndex = 16;
			this.colorGroup.TabStop = false;
			// 
			// colorGreenInput
			// 
			this.colorGreenInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.colorGreenInput.Location = new System.Drawing.Point(8, 47);
			this.colorGreenInput.Name = "colorGreenInput";
			this.colorGreenInput.Size = new System.Drawing.Size(461, 17);
			this.colorGreenInput.TabIndex = 2;
			this.colorGreenInput.TabStop = true;
			this.colorGreenInput.Text = "Green";
			this.colorGreenInput.UseVisualStyleBackColor = true;
			// 
			// colorBlueInput
			// 
			this.colorBlueInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.colorBlueInput.Location = new System.Drawing.Point(8, 30);
			this.colorBlueInput.Name = "colorBlueInput";
			this.colorBlueInput.Size = new System.Drawing.Size(461, 17);
			this.colorBlueInput.TabIndex = 1;
			this.colorBlueInput.TabStop = true;
			this.colorBlueInput.Text = "Blue";
			this.colorBlueInput.UseVisualStyleBackColor = true;
			// 
			// colorRedInput
			// 
			this.colorRedInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.colorRedInput.Location = new System.Drawing.Point(8, 13);
			this.colorRedInput.Name = "colorRedInput";
			this.colorRedInput.Size = new System.Drawing.Size(461, 17);
			this.colorRedInput.TabIndex = 0;
			this.colorRedInput.TabStop = true;
			this.colorRedInput.Text = "Red";
			this.colorRedInput.UseVisualStyleBackColor = true;
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
			this.questInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.questInput.Location = new System.Drawing.Point(0, 106);
			this.questInput.Name = "questInput";
			this.questInput.Size = new System.Drawing.Size(477, 20);
			this.questInput.TabIndex = 14;
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
			// QuestionnaireView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.colorGroup);
			this.Controls.Add(this.colorLabel);
			this.Controls.Add(this.questInput);
			this.Controls.Add(this.questLabel);
			this.Controls.Add(this.ageInput);
			this.Controls.Add(this.ageLabel);
			this.Controls.Add(this.nameInput);
			this.Controls.Add(this.nameLabel);
			this.Name = "QuestionnaireView";
			this.Size = new System.Drawing.Size(477, 229);
			this.colorGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ageInput)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox colorGroup;
		private System.Windows.Forms.RadioButton colorGreenInput;
		private System.Windows.Forms.RadioButton colorBlueInput;
		private System.Windows.Forms.RadioButton colorRedInput;
		private System.Windows.Forms.Label colorLabel;
		private System.Windows.Forms.TextBox questInput;
		private System.Windows.Forms.Label questLabel;
		private System.Windows.Forms.NumericUpDown ageInput;
		private System.Windows.Forms.Label ageLabel;
		private System.Windows.Forms.TextBox nameInput;
		private System.Windows.Forms.Label nameLabel;
	}
}
