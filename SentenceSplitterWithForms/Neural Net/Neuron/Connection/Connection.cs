using System;

namespace SentenceSplitterWithForms.Neural_Net.Neuron.Connection
{
    [Serializable]
    class Connection
    {
        public float Wei { get; set; }
        public Neuron EntNeur { get; set; }

        public Connection(Neuron n, float wei)
        {
            Wei = wei;
            EntNeur = n;
        }

        public float GetValue() => Wei * EntNeur.GetValue();
    }
}
