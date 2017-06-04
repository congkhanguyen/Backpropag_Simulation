using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace Backpropag_Simu
{
    public partial class BackPropa_Simu : Form
    {
        //List of training data
        List<string[]> arrayListTrainData = new List<string[]>();

        //List of output
        List<double> lstOutPut = new List<double>();

        //List of Error
        List<double> lstErro = new List<double>();

        //List of neuron
        private List<Neuron> listNeu = new List<Neuron>();
        private int step = 0;
        private int currentEpock = 1;
        private int maxEpoch;
        public BackPropa_Simu()
        {
            InitializeComponent();
            this.ActiveControl = this.tbx_Epoch;
        }

        private void btn_GenData_Click(object sender, EventArgs e)
        {
            this.btn_GenData.Enabled = false;
            this.btn_StepExe.Enabled = true;
            this.btn_AllExe.Enabled = true;
            this.dtGrid_TrainData.Rows.Clear();
            this.arrayListTrainData.Clear();

            //The first dataset
            if (this.dmn_DataSet.Text == "1")
            {
                for (double x1 = 1.0/16; x1 <= 1.0/8; x1 += 1.0/16)
                {
                    for (double x2 = 0; x2 <= 1; x2 += 0.1)
                    {
                        string[] rows = new string[3];
                        rows[0] = Convert.ToString(x1);
                        rows[1] = Convert.ToString(x2);

                        double z = (1 + Math.Sin(4 * x1 * 180)) * x2 / 2;
                        rows[2] = Convert.ToString(z);

                        this.dtGrid_TrainData.Rows.Add(rows);
                        arrayListTrainData.Add(rows);
                    }
                }
            }
                //The second dataset 
            else if (this.dmn_DataSet.Text == "2")
            {
                for (double x1 = 1.0/16; x1 <= 1.0/2; x1 += 1.0/16)
                {
                    for (double x2 = 0; x2 <= 1; x2 += 0.1)
                    {
                        string[] rows = new string[3];
                        rows[0] = Convert.ToString(x1);
                        rows[1] = Convert.ToString(x2);

                        double z = (1 + Math.Sin(4 * x1 * 180)) * x2 / 2;
                        rows[2] = Convert.ToString(z);

                        this.dtGrid_TrainData.Rows.Add(rows);
                        arrayListTrainData.Add(rows);
                    }
                }
            }
            else
            {
                for (double x1 = 1.0 / 16; x1 <= 1.0 / 2; x1 += 1.0 / 16)
                {
                    for (double x2 = 0; x2 <= 1; x2 += (x2 < 0.1 || x2 > 0.9)?0.01:0.1)
                    {
           
                        string[] rows = new string[3];
                        rows[0] = Convert.ToString(x1);
                        rows[1] = Convert.ToString(x2);

                        double z = (1 + Math.Sin(4 * x1 * 180)) * x2 / 2;
                        rows[2] = Convert.ToString(z);

                        this.dtGrid_TrainData.Rows.Add(rows);
                        arrayListTrainData.Add(rows);
                    }
                }
            }
        }

        private void btn_CreatNeu_Click(object sender, EventArgs e)
        {
            this.btn_CreatNeu.Enabled = false;
            this.btn_GenData.Enabled = true;
            this.maxEpoch = Convert.ToInt16(this.tbx_Epoch.Text);
            if (this.dmn_HiddenNo.Text == "3")
            {
                foreach (Control c in this.grp_NeuNet.Controls)
                {
                    if (!c.Name.Contains("U2") && !c.Name.Contains("U4"))
                    {
                        c.Visible = true;
                    }
                    else if (c.Visible)
                    {
                        c.Visible = false;
                    }
                }
                ShapeContainer shapeContainer = this.grp_NeuNet.Controls.OfType<ShapeContainer>().FirstOrDefault();
                foreach (Shape i in shapeContainer.Shapes)
                {
                    if (!i.Name.Contains("U2") && !i.Name.Contains("U4"))
                    {
                        i.Visible = true;
                    }
                    else if (i.Visible)
                    {
                        i.Visible = false;
                    }
                }

                this.lbl_U3.Text = "U2";
                this.lbl_U5.Text = "U3";
                //Initinal neural network 
                Neuron U1 = new HiddenNeuron("U1", Convert.ToDouble(this.tbx_LearnRate.Text), Convert.ToDouble(this.tbx_moment.Text));
                Neuron U3 = new HiddenNeuron("U3", Convert.ToDouble(this.tbx_LearnRate.Text), Convert.ToDouble(this.tbx_moment.Text));
                Neuron U5 = new HiddenNeuron("U5", Convert.ToDouble(this.tbx_LearnRate.Text), Convert.ToDouble(this.tbx_moment.Text));
                Neuron V = new OutNeuron("V", Convert.ToDouble(this.tbx_LearnRate.Text), Convert.ToDouble(this.tbx_moment.Text));
                listNeu = new List<Neuron> { U1, null, U3, null, U5, V };

                //Random weight and show weight
                for (int i = 0; i < 6; i++)
                {
                    if (listNeu[i] != null)
                    {
                        listNeu[i].randomizeWeights();
                        for (int j = 0; j < listNeu[i].weights.Count(); j++)
                        {
                            foreach (Control c in this.grp_NeuNet.Controls)
                            {
                                if (c.Name.Contains("Wei" + listNeu[i].previous + Convert.ToString(j) + listNeu[i].name))
                                {
                                    c.Text = listNeu[i].weights[j].ToString();
                                }

                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Control c in this.grp_NeuNet.Controls)
                {
                    c.Visible = true;
                }
                ShapeContainer shapeContainer = this.grp_NeuNet.Controls.OfType<ShapeContainer>().FirstOrDefault();
                foreach (Shape i in shapeContainer.Shapes)
                {
                    i.Visible = true;
                }

                //Initinal neural network 
                Neuron U1 = new HiddenNeuron("U1", Convert.ToDouble(this.tbx_LearnRate.Text), Convert.ToDouble(this.tbx_moment.Text));
                Neuron U2 = new HiddenNeuron("U2", Convert.ToDouble(this.tbx_LearnRate.Text), Convert.ToDouble(this.tbx_moment.Text));
                Neuron U3 = new HiddenNeuron("U3", Convert.ToDouble(this.tbx_LearnRate.Text), Convert.ToDouble(this.tbx_moment.Text));
                Neuron U4 = new HiddenNeuron("U4", Convert.ToDouble(this.tbx_LearnRate.Text), Convert.ToDouble(this.tbx_moment.Text));
                Neuron U5 = new HiddenNeuron("U5", Convert.ToDouble(this.tbx_LearnRate.Text), Convert.ToDouble(this.tbx_moment.Text));
                Neuron V = new OutNeuron("V", Convert.ToDouble(this.tbx_LearnRate.Text), Convert.ToDouble(this.tbx_moment.Text));

                listNeu = new List<Neuron> { U1, U2, U3, U4, U5, V};

                //Random weight and show weight
                for (int i = 0; i < 6; i++)
                {
                    listNeu[i].randomizeWeights();
                    for (int j = 0; j < listNeu[i].weights.Count(); j++)
                    {
                        foreach (Control c in this.grp_NeuNet.Controls)
                        {
                            if (c.Name.Contains("Wei" + listNeu[i].previous + Convert.ToString(j) + listNeu[i].name))
                            {
                                c.Text = listNeu[i].weights[j].ToString();
                            }

                        }
                    }
                }

            }
        }

        private void btn_StepExe_Click(object sender, EventArgs e)
        {

            if (step < this.dtGrid_TrainData.Rows.Count - 1)
            {
                double x1 = Convert.ToDouble(arrayListTrainData[step][0]);
                double x2 = Convert.ToDouble(arrayListTrainData[step][1]);
                double Z = Convert.ToDouble(arrayListTrainData[step][2]);
                oneStep(x1, x2, Z);
                refreshForm();
                this.dtGrid_TrainData.CurrentCell = this.dtGrid_TrainData.Rows[step].Cells[3];
                step++;
            }
            else
            {
                currentEpock++;
                this.tbx_CurEpoch.Text = currentEpock.ToString();
                step = 0;
                double x1 = Convert.ToDouble(arrayListTrainData[step][0]);
                double x2 = Convert.ToDouble(arrayListTrainData[step][1]);
                double Z = Convert.ToDouble(arrayListTrainData[step][2]);
                oneStep(x1, x2, Z);
                refreshForm ();
                this.dtGrid_TrainData.CurrentCell = this.dtGrid_TrainData.Rows[step].Cells[3];
                step++;
            }
        }

        public void oneStep(double x1, double x2, double Z)
        {

            //Set up input for hidden layer
            List<double> outPutHidden = new List<double> { 1 };//{1 is for bias}
            for (int ne = 0; ne < 5; ne++)
            {
                if (listNeu[ne] != null)
                {
                    listNeu[ne].inputs = new double[] { 1, x1, x2 };
                    outPutHidden.Add(listNeu[ne].output());
                }
                else
                {
                    outPutHidden.Add(0);
                }
            }

            //output Hidden is the input of the output layer
            listNeu[5].inputs = outPutHidden.ToArray();

            double outPut = listNeu[5].output();

            //Error
            listNeu[5].diff = Sigmoid.derivative(outPut) * (Z - outPut); // 5 ~ output neuron
            listNeu[5].adjustWeights();

            for (int ne = 0; ne < 5; ne++)
            {
                if (listNeu[ne] != null)
                {
                    listNeu[ne].diff = Sigmoid.derivative(outPutHidden[ne + 1]) * listNeu[5].diff * listNeu[5].weights[ne + 1];
                    listNeu[ne].adjustWeights();
                }
            }

            //Error function (1/2 (output-targe)^2)
            lstErro.Add(Math.Pow((Z - outPut), 2) / 2);
            
            if (currentEpock == maxEpoch)
                lstOutPut.Add(outPut);
        }

        public void refreshForm()
        {
            // Show input
            this.tbx_InX0.Text = Convert.ToString(1);
            this.tbx_InX1.Text = Convert.ToString(arrayListTrainData[step][0]);
            this.tbx_InX2.Text = Convert.ToString(arrayListTrainData[step][1]);

            //Show ouput
            this.tbx_OutU1.Text = listNeu[0].outPut.ToString();
            this.tbx_OutU2.Text = (listNeu[1] != null) ? listNeu[1].outPut.ToString() : "0";
            this.tbx_OutU3.Text = listNeu[2].outPut.ToString();
            this.tbx_OutU4.Text = (listNeu[3] != null) ? listNeu[3].outPut.ToString() : "0";
            this.tbx_OutU5.Text = listNeu[4].outPut.ToString();
            this.tbx_OutV.Text = listNeu[5].outPut.ToString();
            this.dtGrid_TrainData.Rows[step].Cells[3].Value = listNeu[5].outPut.ToString();
            //Show updated weight
            for (int k = 0; k < 6; k++)
            {
                if (listNeu[k] != null)
                {
                    for (int j = 0; j < listNeu[k].weights.Count(); j++)
                    {
                        foreach (Control c in this.grp_NeuNet.Controls)
                        {
                            if (c.Name.Contains("Wei" + listNeu[k].previous + Convert.ToString(j) + listNeu[k].name))
                            {
                                c.Text = listNeu[k].weights[j].ToString();
                            }
                        }
                    }
                }
            }
        }
   
        private void btn_AllExe_Click(object sender, EventArgs e)
        {
            this.btn_StepExe.Enabled = false;
            this.btn_TrainError.Enabled = true;
            this.btn_test.Enabled = true;
            this.btn_AllExe.Enabled = false;
            this.backGroundWork.RunWorkerAsync();
            
        }

        private void backGroundWork_DoWork(object sender, DoWorkEventArgs e)
        {

            //Intreval
            double interval = maxEpoch / 100; 

            for (; currentEpock <= maxEpoch; )
            {
                for (; step < this.dtGrid_TrainData.Rows.Count - 1; step++)
                {
                    double x1 = Convert.ToDouble(arrayListTrainData[step][0]);
                    double x2 = Convert.ToDouble(arrayListTrainData[step][1]);
                    double Z = Convert.ToDouble(arrayListTrainData[step][2]);
                    oneStep(x1, x2, Z);
                }
                step = 0;
                backGroundWork.ReportProgress((int)((currentEpock) / interval));
                currentEpock++;
            }
        }

        private void backGroundWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            refreshForm();
            MessageBox.Show("Training complete!", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            this.tbx_CurEpoch.Text = (currentEpock -1).ToString();
            for (int i = 0; i < this.dtGrid_TrainData.Rows.Count -1; i++)
            {
                this.dtGrid_TrainData.Rows[i].Cells[3].Value = lstOutPut[i];
            }
        }
        private void backGroundWork_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.prGr_TrainAll.Increment(e.ProgressPercentage);
        }

        private void btn_TrainError_Click(object sender, EventArgs e)
        {
            
            TrainErrorForm errorForm = new TrainErrorForm();

            //Calculate total error for each epoch
            List<double> calTotalError = new List<double>();
            for (int i = 0; i < lstErro.Count(); i++)
            {
                if ((i + 1) % (this.dtGrid_TrainData.Rows.Count - 1) == 1)
                {
                    calTotalError.Add(0);
                }
                calTotalError[i / (this.dtGrid_TrainData.Rows.Count - 1)] = calTotalError[i / (this.dtGrid_TrainData.Rows.Count - 1)] + lstErro[i];
               
                //Average value
                if ((i + 1) % (this.dtGrid_TrainData.Rows.Count - 1) == 0)
                {
                    calTotalError[i / (this.dtGrid_TrainData.Rows.Count - 1)] = calTotalError[i / (this.dtGrid_TrainData.Rows.Count - 1)] / (this.dtGrid_TrainData.Rows.Count - 1);
                }
            }
            errorForm.showData(calTotalError);

            errorForm.ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.ShowDialog();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            //Hope that you dont input wrong values
            try
            {
                //Get input 
                String[] input = this.tbx_inputTest.Text.Split(',');
                double x1 = Convert.ToDouble(input[0]);
                double x2 = Convert.ToDouble(input[1]);
                //Set up input for hidden layer
                List<double> outPutHidden = new List<double> { 1 };//{1 is for bias}
                for (int ne = 0; ne < 5; ne++)
                {
                    if (listNeu[ne] != null)
                    {
                        listNeu[ne].inputs = new double[] { 1, x1, x2 };
                        outPutHidden.Add(listNeu[ne].output());
                    }
                    else
                    {
                        outPutHidden.Add(0);
                    }
                }

                //output Hidden is the input of the output layer
                listNeu[5].inputs = outPutHidden.ToArray();

                double outPut = listNeu[5].output();
                this.tbx_RealOut.Text = outPut.ToString();
                this.tbx_CorrectOut.Text =  ((1 + Math.Sin(4 * x1 * 180)) * x2 / 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input error: " + ex.ToString(), "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
