﻿namespace SendMessage实现进程通信之Receiver
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lsvMsgList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lsvMsgList
            // 
            this.lsvMsgList.FormattingEnabled = true;
            this.lsvMsgList.ItemHeight = 15;
            this.lsvMsgList.Location = new System.Drawing.Point(125, 80);
            this.lsvMsgList.Name = "lsvMsgList";
            this.lsvMsgList.Size = new System.Drawing.Size(332, 274);
            this.lsvMsgList.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lsvMsgList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReceiver_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmReceiver_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsvMsgList;
    }
}

