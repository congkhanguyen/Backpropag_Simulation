namespace Backpropag_Simu
{
    partial class TrainErrorForm
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
            this.components = new System.ComponentModel.Container();
            this.zedGraph_TrainError = new ZedGraph.ZedGraphControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // zedGraph_TrainError
            // 
            this.zedGraph_TrainError.Location = new System.Drawing.Point(3, 4);
            this.zedGraph_TrainError.Name = "zedGraph_TrainError";
            this.zedGraph_TrainError.ScrollGrace = 0D;
            this.zedGraph_TrainError.ScrollMaxX = 0D;
            this.zedGraph_TrainError.ScrollMaxY = 0D;
            this.zedGraph_TrainError.ScrollMaxY2 = 0D;
            this.zedGraph_TrainError.ScrollMinX = 0D;
            this.zedGraph_TrainError.ScrollMinY = 0D;
            this.zedGraph_TrainError.ScrollMinY2 = 0D;
            this.zedGraph_TrainError.Size = new System.Drawing.Size(718, 476);
            this.zedGraph_TrainError.TabIndex = 0;
            this.toolTip1.SetToolTip(this.zedGraph_TrainError, "Click Ctrl and using mouse to move data error\r\n");
            // 
            // TrainErrorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 483);
            this.Controls.Add(this.zedGraph_TrainError);
            this.Name = "TrainErrorForm";
            this.Text = "TrainErrorForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraph_TrainError;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}