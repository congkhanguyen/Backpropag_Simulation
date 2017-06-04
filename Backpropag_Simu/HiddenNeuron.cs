using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backpropag_Simu
{
    class HiddenNeuron: Neuron
    {

        public HiddenNeuron( string name, double learningRate, double moment)
        {
            this.learningRate = learningRate;
            this.moment = moment;
            previous = "X";
            this.name = name;
            inputs = new double[3];
            weights = new double[3];
            r = new Random(10);
        }
        public override double output()
        {
            outPut =  Sigmoid.output(weights[0] + weights[1] * inputs[1] + weights[2] * inputs[2]);
            return outPut;
        }

        public override void randomizeWeights()
        {
            weights[0] = r.NextDouble();// Bias weight
            weights[1] = r.NextDouble();
            weights[2] = r.NextDouble();
        }


        public override void adjustWeights()
        {
            //W(t + 1)
            weights[0] += learningRate * diff + detaWei[0] * moment;
            weights[1] += learningRate * diff * inputs[1] + detaWei[1] * moment;
            weights[2] += learningRate * diff * inputs[2] + detaWei[2] * moment;

            //Update deltaWei between W(t) - W(t-1)
            detaWei[0] = learningRate * diff + detaWei[0] * moment;
            detaWei[1] = learningRate * diff * inputs[1] + detaWei[1] * moment;
            detaWei[2] = learningRate * diff * inputs[2] + detaWei[2] * moment;
        }
    }
}
