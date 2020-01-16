using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KinectCoordinateMapping.UserInterfaces
{
    public partial class MenuWindow
    {
        
        private System.ComponentModel.IContainer components = null;

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
            this.RecordExerciseButton = new System.Windows.Forms.Button();
            this.PerformExerciseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RecordExerciseButton
            // 
            this.RecordExerciseButton.Location = new System.Drawing.Point(105, 195);
            this.RecordExerciseButton.Name = "RecordExerciseButton";
            this.RecordExerciseButton.Size = new System.Drawing.Size(253, 37);
            this.RecordExerciseButton.TabIndex = 0;
            this.RecordExerciseButton.Text = "Record Exercise";
            this.RecordExerciseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.RecordExerciseButton.UseVisualStyleBackColor = true;
            this.RecordExerciseButton.Click += new System.EventHandler(this.RecordExerciseButton_Click);
            // 
            // PerformExerciseButton
            // 
            this.PerformExerciseButton.Location = new System.Drawing.Point(464, 195);
            this.PerformExerciseButton.Name = "PerformExerciseButton";
            this.PerformExerciseButton.Size = new System.Drawing.Size(253, 37);
            this.PerformExerciseButton.TabIndex = 1;
            this.PerformExerciseButton.Text = "Perform Exercise";
            this.PerformExerciseButton.UseVisualStyleBackColor = true;
            this.PerformExerciseButton.Click += new System.EventHandler(this.PerformExerciseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(352, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Virtual Personal Trainer";
            // 
            // MenuWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 470);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PerformExerciseButton);
            this.Controls.Add(this.RecordExerciseButton);
            this.Name = "MenuWindow";
            this.Text = "MenuWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RecordExerciseButton;
        private System.Windows.Forms.Button PerformExerciseButton;
        private System.Windows.Forms.Label label1;
    }
}