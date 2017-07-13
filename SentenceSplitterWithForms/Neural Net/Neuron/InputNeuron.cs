using System;

namespace SentenceSplitterWithForms.Neural_Net.Neuron
{
    [Serializable]
    class InputNeuron : Neuron
    {
        private float Val { get; set; }
        public void Setvalue(float x) => Val = x;
        public override float GetValue() => Val;
    }
}
