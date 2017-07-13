using System;

namespace SentenceSplitterTest.Neural_Net.Neuron.Connection
{
    [Serializable]
    class Connection
    {
        public float weight { get; set; }
        public Neuron entrieNeuron { get; set; }

        public Connection(Neuron n, float weight)
        {
            this.weight = weight;
            this.entrieNeuron = n;
        }

        public float GetValue() => weight * entrieNeuron.GetValue();
    }
}
