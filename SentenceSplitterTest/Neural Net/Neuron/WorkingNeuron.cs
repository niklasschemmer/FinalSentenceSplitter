using System;
using System.Collections.Generic;

namespace SentenceSplitterTest.Neural_Net.Neuron
{
    [Serializable]
    class WorkingNeuron : Neuron
    {
        public float? Error { get; set; }
        public float? Value { get; set; }
        public List<Connection.Connection> Connections { get; set; } = new List<Connection.Connection>();

        public void AddNeuronConnection(Connection.Connection conn) => Connections.Add(conn);

        private void Calculate()
        {
            float value = 0;
            foreach (var c in Connections)
            {
                value += c.GetValue();
            }
            value = Neuron.Sigmoid(value);
            Value = value;
        }

        public void Invalidate() => Value = null;

        public override float GetValue()
        {
            if (Value == null)
            {
                Calculate();
            }
            return Value ?? 0;
        }

        public void AdjustWeights()
        {
            foreach (var connection in Connections)
            {
                connection.weight += Error ?? 0 + connection.GetValue();
            }
        }
    }
}
