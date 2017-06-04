using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
namespace Backpropag_Simu
{
    public partial class TrainErrorForm : Form
    {
        public TrainErrorForm()
        {
            InitializeComponent();
        }

        public void showData( List<double> lstErro)
        {
            if (lstErro.Count() != 0)
            {
                GraphPane zedPane = this.zedGraph_TrainError.GraphPane;

                zedPane.Title.Text = "Backpro NN Training Error";
                zedPane.XAxis.Title.Text = "Epoch";
                zedPane.YAxis.Title.Text = "Error";
                zedPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 255), 90F);
                zedPane.Fill = new Fill(Color.FromArgb(204, 204, 204));


                PointPairList lstData = new PointPairList();
                for (int i = 0; i < lstErro.Count; i++)
                {
                    lstData.Add((double)(i + 1), lstErro[i]);

                }
                LineItem line = zedPane.AddCurve("Training", lstData, Color.Blue, SymbolType.None);

                this.zedGraph_TrainError.IsShowPointValues = true;
                this.zedGraph_TrainError.AxisChange();
            }
        }
    }
}
