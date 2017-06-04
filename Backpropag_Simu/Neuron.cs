using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backpropag_Simu
{
    class Neuron
    {
        public double outPut;
        public double moment;
        public Double[] detaWei;
        public string name;
        public string previous;
        public double[] inputs;
        public double[] weights;
        public double diff;
        protected double learningRate;
        protected double biasWeight;

        protected Random r;

        public Neuron()
        {
            learningRate = 0;
            detaWei = new Double[6]{ 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
            moment = 0;
            outPut = 0;
            previous = "";
            name = "";
            diff = 0;
            biasWeight = 0;
        }

        public virtual double output()
        {
            return 0;
        }
        public virtual void randomizeWeights()
        {

        }

        public virtual void adjustWeights()
        {

        }
    }
}
