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
			this.nameLabel = new System.Windows.Forms.Label();
			this.nameInput = new System.Windows.Forms.TextBox();
			this.ageLabel = new System.Windows.Forms.Label();
			this.ageInput = new System.Windows.Forms.NumericUpDown();
			this.questLabel = new System.Windows.Forms.Label();
			this.questInput = new System.Windows.Forms.TextBox();
			this.colorGroup = new System.Windows.Forms.GroupBox();
			this.colorGreenInput = new System.Windows.Forms.RadioButton();
			this.colorBlueInput = new System.Windows.Forms.RadioButton();
			this.colorRedInput = new System.Windows.Forms.RadioButton();
			this.colorLabel = new System.Windows.Forms.Label();
			this.resetButton = new System.Windows.Forms.Button();
			this.submitButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ageInput)).BeginInit();
			this.colorGroup.SuspendLayout();
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
			// nameLabel
			// 
			this.nameLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.nameLabel.Location = new System.Drawing.Point(16, 53);
			this.nameLabel.Name = "nameLabel";
			this.nameLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 3);
			this.nameLabel.Size = new System.Drawing.Size(477, 22);
			this.nameLabel.TabIndex = 1;
			this.nameLabel.Text = "Name";
			// 
			// nameInput
			// 
			this.nameInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.nameInput.Location = new System.Drawing.Point(16, 75);
			this.nameInput.Name = "nameInput";
			this.nameInput.Size = new System.Drawing.Size(477, 20);
			this.nameInput.TabIndex = 2;
			// 
			// ageLabel
			// 
			this.ageLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.ageLabel.Location = new System.Drawing.Point(16, 95);
			this.ageLabel.Name = "ageLabel";
			this.ageLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 3);
			this.ageLabel.Size = new System.Drawing.Size(477, 22);
			this.ageLabel.TabIndex = 3;
			this.ageLabel.Text = "Age";
			// 
			// ageInput
			// 
			this.ageInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.ageInput.Location = new System.Drawing.Point(16, 117);
			this.ageInput.Name = "ageInput";
			this.ageInput.Size = new System.Drawing.Size(477, 20);
			this.ageInput.TabIndex = 4;
			// 
			// questLabel
			// 
			this.questLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.questLabel.Location = new System.Drawing.Point(16, 137);
			this.questLabel.Name = "questLabel";
			this.questLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 3);
			this.questLabel.Size = new System.Drawing.Size(477, 22);
			this.questLabel.TabIndex = 5;
			this.questLabel.Text = "What is your quest?";
			// 
			// questInput
			// 
			this.questInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.questInput.Location = new System.Drawing.Point(16, 159);
			this.questInput.Name = "questInput";
			this.questInput.Size = new System.Drawing.Size(477, 20);
			this.questInput.TabIndex = 6;
			// 
			// colorGroup
			// 
			this.colorGroup.Controls.Add(this.colorGreenInput);
			this.colorGroup.Controls.Add(this.colorBlueInput);
			this.colorGroup.Controls.Add(this.colorRedInput);
			this.colorGroup.Dock = System.Windows.Forms.DockStyle.Top;
			this.colorGroup.Location = new System.Drawing.Point(16, 201);
			this.colorGroup.Name = "colorGroup";
			this.colorGroup.Padding = new System.Windows.Forms.Padding(8, 0, 8, 8);
			this.colorGroup.Size = new System.Drawing.Size(477, 72);
			this.colorGroup.TabIndex = 8;
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
			this.colorLabel.Location = new System.Drawing.Point(16, 179);
			this.colorLabel.Name = "colorLabel";
			this.colorLabel.Padding = new System.Windows.Forms.Padding(0, 6, 0, 3);
			this.colorLabel.Size = new System.Drawing.Size(477, 22);
			this.colorLabel.TabIndex = 7;
			this.colorLabel.Text = "What is your favorite color?";
			// 
			// resetButton
			// 
			this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.resetButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.resetButton.Location = new System.Drawing.Point(337, 277);
			this.resetButton.Name = "resetButton";
			this.resetButton.Size = new System.Drawing.Size(75, 23);
			this.resetButton.TabIndex = 9;
			this.resetButton.Text = "&Reset";
			this.resetButton.UseVisualStyleBackColor = true;
			// 
			// submitButton
			// 
			this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.submitButton.Location = new System.Drawing.Point(418, 277);
			this.submitButton.Name = "submitButton";
			this.submitButton.Size = new System.Drawing.Size(75, 23);
			this.submitButton.TabIndex = 10;
			this.submitButton.Text = "&Submit";
			this.submitButton.UseVisualStyleBackColor = true;
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
			this.Controls.Add(this.colorGroup);
			this.Controls.Add(this.colorLabel);
			this.Controls.Add(this.questInput);
			this.Controls.Add(this.questLabel);
			this.Controls.Add(this.ageInput);
			this.Controls.Add(this.ageLabel);
			this.Controls.Add(this.nameInput);
			this.Controls.Add(this.nameLabel);
			this.Controls.Add(this.titleLabel);
			this.MinimumSize = new System.Drawing.Size(525, 350);
			this.Name = "MainWindow";
			this.Padding = new System.Windows.Forms.Padding(16, 8, 16, 8);
			this.Text = "Basic MVVM Quickstart";
			((System.ComponentModel.ISupportInitialize)(this.ageInput)).EndInit();
			this.colorGroup.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label titleLabel;
		private System.Windows.Forms.Label nameLabel;
		private System.Windows.Forms.TextBox nameInput;
		private System.Windows.Forms.Label ageLabel;
		private System.Windows.Forms.NumericUpDown ageInput;
		private System.Windows.Forms.Label questLabel;
		private System.Windows.Forms.TextBox questInput;
		private System.Windows.Forms.GroupBox colorGroup;
		private System.Windows.Forms.RadioButton colorGreenInput;
		private System.Windows.Forms.RadioButton colorBlueInput;
		private System.Windows.Forms.RadioButton colorRedInput;
		private System.Windows.Forms.Label colorLabel;
		private System.Windows.Forms.Button resetButton;
		private System.Windows.Forms.Button submitButton;
	}
}