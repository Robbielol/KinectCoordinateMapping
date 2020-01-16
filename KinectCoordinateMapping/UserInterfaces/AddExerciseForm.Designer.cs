namespace KinectCoordinateMapping.UserInterfaces
{
    partial class AddExerciseForm
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
            this.record_Button = new System.Windows.Forms.Button();
            this.exercise_Textbox = new System.Windows.Forms.TextBox();
            this.name_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trainer_label = new System.Windows.Forms.Label();
            this.trainer_Textbox = new System.Windows.Forms.TextBox();
            this.WOTypeLabel = new System.Windows.Forms.Label();
            this.workoutTypeBox = new System.Windows.Forms.ComboBox();
            this.descLabel = new System.Windows.Forms.Label();
            this.descBox = new System.Windows.Forms.TextBox();
            this.startInstructionsLabel = new System.Windows.Forms.Label();
            this.endInstructionsLabel = new System.Windows.Forms.Label();
            this.startInstructBox = new System.Windows.Forms.TextBox();
            this.endInstructBox = new System.Windows.Forms.TextBox();
            this.durationLabel = new System.Windows.Forms.Label();
            this.durationCounter = new System.Windows.Forms.NumericUpDown();
            this.exExsistLabel = new System.Windows.Forms.Label();
            this.requiredLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.durationCounter)).BeginInit();
            this.SuspendLayout();
            // 
            // record_Button
            // 
            this.record_Button.Location = new System.Drawing.Point(336, 391);
            this.record_Button.Name = "record_Button";
            this.record_Button.Size = new System.Drawing.Size(128, 33);
            this.record_Button.TabIndex = 0;
            this.record_Button.Text = "Record";
            this.record_Button.UseVisualStyleBackColor = true;
            this.record_Button.Click += new System.EventHandler(this.record_Button_Click);
            // 
            // exercise_Textbox
            // 
            this.exercise_Textbox.Location = new System.Drawing.Point(156, 35);
            this.exercise_Textbox.Name = "exercise_Textbox";
            this.exercise_Textbox.Size = new System.Drawing.Size(188, 20);
            this.exercise_Textbox.TabIndex = 1;
            this.exercise_Textbox.TextChanged += new System.EventHandler(this.exercise_Textbox_TextChanged);
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.Location = new System.Drawing.Point(64, 39);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(88, 13);
            this.name_label.TabIndex = 2;
            this.name_label.Text = "* Exercise Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 4;
            // 
            // trainer_label
            // 
            this.trainer_label.AutoSize = true;
            this.trainer_label.Location = new System.Drawing.Point(482, 35);
            this.trainer_label.Name = "trainer_label";
            this.trainer_label.Size = new System.Drawing.Size(87, 13);
            this.trainer_label.TabIndex = 5;
            this.trainer_label.Text = "Personal Trainer:";
            // 
            // trainer_Textbox
            // 
            this.trainer_Textbox.Location = new System.Drawing.Point(575, 32);
            this.trainer_Textbox.Name = "trainer_Textbox";
            this.trainer_Textbox.Size = new System.Drawing.Size(186, 20);
            this.trainer_Textbox.TabIndex = 6;
            // 
            // WOTypeLabel
            // 
            this.WOTypeLabel.AutoSize = true;
            this.WOTypeLabel.Location = new System.Drawing.Point(67, 82);
            this.WOTypeLabel.Name = "WOTypeLabel";
            this.WOTypeLabel.Size = new System.Drawing.Size(85, 13);
            this.WOTypeLabel.TabIndex = 7;
            this.WOTypeLabel.Text = "* Workout Type:";
            // 
            // workoutTypeBox
            // 
            this.workoutTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.workoutTypeBox.FormattingEnabled = true;
            this.workoutTypeBox.Items.AddRange(new object[] {
            "Upper-body",
            "Legs",
            "Arms",
            "Abdominal"});
            this.workoutTypeBox.Location = new System.Drawing.Point(156, 79);
            this.workoutTypeBox.MaxDropDownItems = 30;
            this.workoutTypeBox.Name = "workoutTypeBox";
            this.workoutTypeBox.Size = new System.Drawing.Size(188, 21);
            this.workoutTypeBox.TabIndex = 8;
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(86, 244);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(63, 13);
            this.descLabel.TabIndex = 10;
            this.descLabel.Text = "Description:";
            // 
            // descBox
            // 
            this.descBox.Location = new System.Drawing.Point(154, 241);
            this.descBox.Multiline = true;
            this.descBox.Name = "descBox";
            this.descBox.Size = new System.Drawing.Size(543, 144);
            this.descBox.TabIndex = 11;
            // 
            // startInstructionsLabel
            // 
            this.startInstructionsLabel.AutoSize = true;
            this.startInstructionsLabel.Location = new System.Drawing.Point(53, 124);
            this.startInstructionsLabel.Name = "startInstructionsLabel";
            this.startInstructionsLabel.Size = new System.Drawing.Size(96, 13);
            this.startInstructionsLabel.TabIndex = 12;
            this.startInstructionsLabel.Text = "* Start Instructions:";
            // 
            // endInstructionsLabel
            // 
            this.endInstructionsLabel.AutoSize = true;
            this.endInstructionsLabel.Location = new System.Drawing.Point(426, 124);
            this.endInstructionsLabel.Name = "endInstructionsLabel";
            this.endInstructionsLabel.Size = new System.Drawing.Size(93, 13);
            this.endInstructionsLabel.TabIndex = 13;
            this.endInstructionsLabel.Text = "* End Instructions:";
            this.endInstructionsLabel.Click += new System.EventHandler(this.endInstructionsLabel_Click);
            // 
            // startInstructBox
            // 
            this.startInstructBox.Location = new System.Drawing.Point(156, 121);
            this.startInstructBox.Multiline = true;
            this.startInstructBox.Name = "startInstructBox";
            this.startInstructBox.Size = new System.Drawing.Size(253, 74);
            this.startInstructBox.TabIndex = 14;
            // 
            // endInstructBox
            // 
            this.endInstructBox.Location = new System.Drawing.Point(525, 121);
            this.endInstructBox.Multiline = true;
            this.endInstructBox.Name = "endInstructBox";
            this.endInstructBox.Size = new System.Drawing.Size(253, 75);
            this.endInstructBox.TabIndex = 15;
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(43, 217);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(107, 13);
            this.durationLabel.TabIndex = 16;
            this.durationLabel.Text = "Duration To Halfway:";
            // 
            // durationCounter
            // 
            this.durationCounter.DecimalPlaces = 1;
            this.durationCounter.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.durationCounter.Location = new System.Drawing.Point(156, 215);
            this.durationCounter.Name = "durationCounter";
            this.durationCounter.Size = new System.Drawing.Size(46, 20);
            this.durationCounter.TabIndex = 17;
            this.durationCounter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // exExsistLabel
            // 
            this.exExsistLabel.AutoSize = true;
            this.exExsistLabel.ForeColor = System.Drawing.Color.Red;
            this.exExsistLabel.Location = new System.Drawing.Point(153, 58);
            this.exExsistLabel.Name = "exExsistLabel";
            this.exExsistLabel.Size = new System.Drawing.Size(263, 13);
            this.exExsistLabel.TabIndex = 18;
            this.exExsistLabel.Text = "*Exercise already exsists. Other text fields not required.";
            this.exExsistLabel.Visible = false;
            // 
            // requiredLabel
            // 
            this.requiredLabel.AutoSize = true;
            this.requiredLabel.ForeColor = System.Drawing.Color.Red;
            this.requiredLabel.Location = new System.Drawing.Point(482, 401);
            this.requiredLabel.Name = "requiredLabel";
            this.requiredLabel.Size = new System.Drawing.Size(242, 13);
            this.requiredLabel.TabIndex = 19;
            this.requiredLabel.Text = "All text boxes marked with \'*\' cannot be left empty.";
            this.requiredLabel.Visible = false;
            // 
            // AddExerciseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.requiredLabel);
            this.Controls.Add(this.exExsistLabel);
            this.Controls.Add(this.durationCounter);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.endInstructBox);
            this.Controls.Add(this.startInstructBox);
            this.Controls.Add(this.startInstructionsLabel);
            this.Controls.Add(this.descBox);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.workoutTypeBox);
            this.Controls.Add(this.WOTypeLabel);
            this.Controls.Add(this.trainer_Textbox);
            this.Controls.Add(this.trainer_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.exercise_Textbox);
            this.Controls.Add(this.record_Button);
            this.Controls.Add(this.endInstructionsLabel);
            this.Name = "AddExerciseForm";
            this.Text = "AddExerciseForm";
            ((System.ComponentModel.ISupportInitialize)(this.durationCounter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button record_Button;
        private System.Windows.Forms.TextBox exercise_Textbox;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label trainer_label;
        private System.Windows.Forms.TextBox trainer_Textbox;
        private System.Windows.Forms.Label WOTypeLabel;
        private System.Windows.Forms.ComboBox workoutTypeBox;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.TextBox descBox;
        private System.Windows.Forms.Label startInstructionsLabel;
        private System.Windows.Forms.Label endInstructionsLabel;
        private System.Windows.Forms.TextBox startInstructBox;
        private System.Windows.Forms.TextBox endInstructBox;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.NumericUpDown durationCounter;
        private System.Windows.Forms.Label exExsistLabel;
        private System.Windows.Forms.Label requiredLabel;
    }
}