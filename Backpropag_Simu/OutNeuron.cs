using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backpropag_Simu
{
    class OutNeuron: Neuron
    {
        public OutNeuron(string name, double learningRate, double moment)
        {
            this.moment = moment;
            this.learningRate = learningRate;
            this.name = name;
            inputs = new double[6];
            weights = new double[6];
            previous = "U";
            r = new Random(10);
        }
      

        public override double output()
        {
             outPut = Sigmoid.output(weights[0] + weights[1] * inputs[1] + weights[2] * inputs[2] + weights[3] * inputs[3] + weights[4] * inputs[4] + weights[5] * inputs[5]);
             return outPut;
        }

         public override void randomizeWeights()
        {
            weights[0] = r.NextDouble(); //Bias weight
            weights[1] = r.NextDouble();
            weights[2] = r.NextDouble();
            weights[3] = r.NextDouble();
            weights[4] = r.NextDouble();
            weights[5] = r.NextDouble();
        }


         public override void adjustWeights()
        {
            weights[0] += learningRate * diff + detaWei[0] * moment;
            weights[1] += learningRate * diff * inputs[1] + detaWei[1] * moment;
            weights[2] += learningRate * diff * inputs[2] + detaWei[2] * moment;
            weights[3] += learningRate * diff * inputs[3] + detaWei[3] * moment;
            weights[4] += learningRate * diff * inputs[4] + detaWei[4] * moment;
            weights[5] += learningRate * diff * inputs[5] + detaWei[5] * moment;

             //Update deltaWei
            detaWei[0] = learningRate * diff + detaWei[0] * moment;
            detaWei[1] = learningRate * diff * inputs[1] + detaWei[1] * moment;
            detaWei[2] = learningRate * diff * inputs[2] + detaWei[2] * moment;
            detaWei[3] = learningRate * diff * inputs[3] + detaWei[3] * moment;
            detaWei[4] = learningRate * diff * inputs[4] + detaWei[4] * moment;
            detaWei[5] = learningRate * diff * inputs[5] + detaWei[5] * moment;
        }
    }
}
