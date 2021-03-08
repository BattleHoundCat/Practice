
namespace MultiThreadApp
{
    partial class MainForm
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
            this.btnWeatherProcess = new System.Windows.Forms.Button();
            this.btnTimerProcess = new System.Windows.Forms.Button();
            this.btnParseTextProcess = new System.Windows.Forms.Button();
            this.btnCloseAllTasks = new System.Windows.Forms.Button();
            this.lblSumTasks = new System.Windows.Forms.Label();
            this.txtBoxWeather = new System.Windows.Forms.TextBox();
            this.txtBoxTimer = new System.Windows.Forms.TextBox();
            this.txtBoxText = new System.Windows.Forms.TextBox();
            this.txtBoxLogging = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnWeatherProcess
            // 
            this.btnWeatherProcess.Location = new System.Drawing.Point(62, 73);
            this.btnWeatherProcess.Name = "btnWeatherProcess";
            this.btnWeatherProcess.Size = new System.Drawing.Size(121, 28);
            this.btnWeatherProcess.TabIndex = 0;
            this.btnWeatherProcess.Text = "Get Weather";
            this.btnWeatherProcess.UseVisualStyleBackColor = true;
            this.btnWeatherProcess.Click += new System.EventHandler(this.btnWeatherProcess_Click);
            // 
            // btnTimerProcess
            // 
            this.btnTimerProcess.Location = new System.Drawing.Point(62, 107);
            this.btnTimerProcess.Name = "btnTimerProcess";
            this.btnTimerProcess.Size = new System.Drawing.Size(121, 28);
            this.btnTimerProcess.TabIndex = 1;
            this.btnTimerProcess.Text = "Run Timer";
            this.btnTimerProcess.UseVisualStyleBackColor = true;
            this.btnTimerProcess.Click += new System.EventHandler(this.btnTimerProcess_Click);
            // 
            // btnParseTextProcess
            // 
            this.btnParseTextProcess.Location = new System.Drawing.Point(62, 141);
            this.btnParseTextProcess.Name = "btnParseTextProcess";
            this.btnParseTextProcess.Size = new System.Drawing.Size(121, 28);
            this.btnParseTextProcess.TabIndex = 2;
            this.btnParseTextProcess.Text = "Run Parse Text";
            this.btnParseTextProcess.UseVisualStyleBackColor = true;
            this.btnParseTextProcess.Click += new System.EventHandler(this.btnParseTextProcess_Click);
            // 
            // btnCloseAllTasks
            // 
            this.btnCloseAllTasks.Location = new System.Drawing.Point(62, 243);
            this.btnCloseAllTasks.Name = "btnCloseAllTasks";
            this.btnCloseAllTasks.Size = new System.Drawing.Size(161, 54);
            this.btnCloseAllTasks.TabIndex = 4;
            this.btnCloseAllTasks.Text = "Close All Tasks";
            this.btnCloseAllTasks.UseVisualStyleBackColor = true;
            this.btnCloseAllTasks.Click += new System.EventHandler(this.btnCloseAllTasks_Click);
            // 
            // lblSumTasks
            // 
            this.lblSumTasks.AutoSize = true;
            this.lblSumTasks.Location = new System.Drawing.Point(59, 42);
            this.lblSumTasks.Name = "lblSumTasks";
            this.lblSumTasks.Size = new System.Drawing.Size(108, 13);
            this.lblSumTasks.TabIndex = 5;
            this.lblSumTasks.Text = "Sum Active Tasks : 0";
            // 
            // txtBoxWeather
            // 
            this.txtBoxWeather.Location = new System.Drawing.Point(308, 73);
            this.txtBoxWeather.Name = "txtBoxWeather";
            this.txtBoxWeather.Size = new System.Drawing.Size(264, 20);
            this.txtBoxWeather.TabIndex = 6;
            // 
            // txtBoxTimer
            // 
            this.txtBoxTimer.Location = new System.Drawing.Point(308, 107);
            this.txtBoxTimer.Name = "txtBoxTimer";
            this.txtBoxTimer.Size = new System.Drawing.Size(264, 20);
            this.txtBoxTimer.TabIndex = 7;
            // 
            // txtBoxText
            // 
            this.txtBoxText.Location = new System.Drawing.Point(308, 141);
            this.txtBoxText.Multiline = true;
            this.txtBoxText.Name = "txtBoxText";
            this.txtBoxText.Size = new System.Drawing.Size(264, 53);
            this.txtBoxText.TabIndex = 8;
            // 
            // txtBoxLogging
            // 
            this.txtBoxLogging.Location = new System.Drawing.Point(308, 200);
            this.txtBoxLogging.Name = "txtBoxLogging";
            this.txtBoxLogging.Size = new System.Drawing.Size(264, 20);
            this.txtBoxLogging.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 309);
            this.Controls.Add(this.txtBoxLogging);
            this.Controls.Add(this.txtBoxText);
            this.Controls.Add(this.txtBoxTimer);
            this.Controls.Add(this.txtBoxWeather);
            this.Controls.Add(this.lblSumTasks);
            this.Controls.Add(this.btnCloseAllTasks);
            this.Controls.Add(this.btnParseTextProcess);
            this.Controls.Add(this.btnTimerProcess);
            this.Controls.Add(this.btnWeatherProcess);
            this.Name = "MainForm";
            this.Text = "MultiThread App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnWeatherProcess;
        private System.Windows.Forms.Button btnTimerProcess;
        private System.Windows.Forms.Button btnParseTextProcess;
        private System.Windows.Forms.Button btnCloseAllTasks;
        private System.Windows.Forms.Label lblSumTasks;
        private System.Windows.Forms.TextBox txtBoxWeather;
        private System.Windows.Forms.TextBox txtBoxTimer;
        private System.Windows.Forms.TextBox txtBoxText;
        private System.Windows.Forms.TextBox txtBoxLogging;
    }
}

