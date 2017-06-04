﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Backpropag_Simu
{
    class Sigmoid
    {
        public static double output(double x)
        {
            return 1.0 / (1.0 + Math.Exp(-x));
        }

        public static double derivative(double x)
        {
            return x * (1 - x);
        }
    }
}
