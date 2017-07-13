using System;

namespace SentenceSplitterTest.Neural_Net.Neuron
{
    [Serializable]
    abstract class Neuron
    {
        public abstract float GetValue();

        public static float Sigmoid(float x)
        {
            var et = (float)Math.Pow(Math.E, x);
            return Double.IsNegativeInfinity(et) ? 0 : Double.IsPositiveInfinity(et) ? 1 : et / (1 + et);
        }

        public static float SigmoidDerivate(float x) => x * (1 - x);
    }
}
