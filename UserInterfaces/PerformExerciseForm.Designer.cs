namespace KinectCoordinateMapping.UserInterfaces
{
    partial class PerformExerciseForm
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
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            this.PerformButton = new System.Windows.Forms.Button();
            this.ExercisePanel = new System.Windows.Forms.Panel();
            this.SelectExerciseLabel = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Workout_Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Workout_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.startPosPicBox = new System.Windows.Forms.PictureBox();
            this.endPosPictBox = new System.Windows.Forms.PictureBox();
            this.startPic = new System.Windows.Forms.Label();
            this.EndPic = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.startPosPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPosPictBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PerformButton
            // 
            this.PerformButton.Location = new System.Drawing.Point(391, 394);
            this.PerformButton.Name = "PerformButton";
            this.PerformButton.Size = new System.Drawing.Size(221, 44);
            this.PerformButton.TabIndex = 0;
            this.PerformButton.Text = "Perfrom Exercise";
            this.PerformButton.UseVisualStyleBackColor = true;
            this.PerformButton.Click += new System.EventHandler(this.PerformButton_Click);
            // 
            // ExercisePanel
            // 
            this.ExercisePanel.AutoScroll = true;
            this.ExercisePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExercisePanel.Location = new System.Drawing.Point(12, 28);
            this.ExercisePanel.Name = "ExercisePanel";
            this.ExercisePanel.Size = new System.Drawing.Size(181, 360);
            this.ExercisePanel.TabIndex = 1;
            // 
            // SelectExerciseLabel
            // 
            this.SelectExerciseLabel.AutoSize = true;
            this.SelectExerciseLabel.Location = new System.Drawing.Point(12, 12);
            this.SelectExerciseLabel.Name = "SelectExerciseLabel";
            this.SelectExerciseLabel.Size = new System.Drawing.Size(96, 13);
            this.SelectExerciseLabel.TabIndex = 2;
            this.SelectExerciseLabel.Text = "Select An Exercise";
            // 
            // listView1
            // 
            this.listView1.BackgroundImageTiled = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Workout_Desc,
            this.Workout_Type});
            this.listView1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem3,
            listViewItem4});
            this.listView1.LabelEdit = true;
            this.listView1.Location = new System.Drawing.Point(213, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(742, 97);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Workout_Desc
            // 
            this.Workout_Desc.DisplayIndex = 1;
            this.Workout_Desc.Text = "Description";
            this.Workout_Desc.Width = 496;
            // 
            // Workout_Type
            // 
            this.Workout_Type.DisplayIndex = 0;
            this.Workout_Type.Text = "Workout Type";
            this.Workout_Type.Width = 99;
            // 
            // startPosPicBox
            // 
            this.startPosPicBox.Location = new System.Drawing.Point(213, 164);
            this.startPosPicBox.Name = "startPosPicBox";
            this.startPosPicBox.Size = new System.Drawing.Size(362, 224);
            this.startPosPicBox.TabIndex = 4;
            this.startPosPicBox.TabStop = false;
            // 
            // endPosPictBox
            // 
            this.endPosPictBox.Location = new System.Drawing.Point(609, 164);
            this.endPosPictBox.Name = "endPosPictBox";
            this.endPosPictBox.Size = new System.Drawing.Size(362, 224);
            this.endPosPictBox.TabIndex = 5;
            this.endPosPictBox.TabStop = false;
            // 
            // startPic
            // 
            this.startPic.AutoSize = true;
            this.startPic.Location = new System.Drawing.Point(213, 145);
            this.startPic.Name = "startPic";
            this.startPic.Size = new System.Drawing.Size(86, 13);
            this.startPic.TabIndex = 7;
            this.startPic.Text = "Starting Position:";
            // 
            // EndPic
            // 
            this.EndPic.AutoSize = true;
            this.EndPic.Location = new System.Drawing.Point(609, 145);
            this.EndPic.Name = "EndPic";
            this.EndPic.Size = new System.Drawing.Size(83, 13);
            this.EndPic.TabIndex = 8;
            this.EndPic.Text = "Ending Position:";
            // 
            // PerformExerciseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 450);
            this.Controls.Add(this.EndPic);
            this.Controls.Add(this.startPic);
            this.Controls.Add(this.endPosPictBox);
            this.Controls.Add(this.startPosPicBox);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.SelectExerciseLabel);
            this.Controls.Add(this.ExercisePanel);
            this.Controls.Add(this.PerformButton);
            this.Name = "PerformExerciseForm";
            this.Text = "PerformExerciseForm";
            ((System.ComponentModel.ISupportInitialize)(this.startPosPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endPosPictBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PerformButton;
        private System.Windows.Forms.Panel ExercisePanel;
        private System.Windows.Forms.Label SelectExerciseLabel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Workout_Desc;
        private System.Windows.Forms.ColumnHeader Workout_Type;
        private System.Windows.Forms.PictureBox startPosPicBox;
        private System.Windows.Forms.PictureBox endPosPictBox;
        private System.Windows.Forms.Label startPic;
        private System.Windows.Forms.Label EndPic;
    }
}