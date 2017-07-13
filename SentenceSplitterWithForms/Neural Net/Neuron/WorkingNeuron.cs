using System;
using System.Collections.Generic;

namespace SentenceSplitterWithForms.Neural_Net.Neuron
{
    [Serializable]
    class WorkingNeuron : Neuron
    {
        public float? Err { get; set; } = 1;
        public float? Val { get; set; }
        public List<Connection.Connection> Connections { get; set; } = new List<Connection.Connection>();

        public void AddNeuronConnection(Connection.Connection conn) => Connections.Add(conn);

        private void Calculate()
        {
            float value = 0;
            foreach (var c in Connections)
            {
                var test = c.GetValue();
                value += test;
            }
            value = Sigmoid(value);
            Val = value;
        }

        public void Invalidate() => Val = null;

        public override float GetValue()
        {
            if (Val == null)
            {
                Calculate();
            }
            return Val ?? 0;
        }

        public void AdjustWeights()
        {
            foreach (var connection in Connections)
            {
                connection.Wei += (Err ?? 0) + connection.GetValue();
            }
        }
    }
}
