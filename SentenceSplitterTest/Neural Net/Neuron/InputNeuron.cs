using System;

namespace SentenceSplitterTest.Neural_Net.Neuron
{
    [Serializable]
    class InputNeuron : Neuron
    {
        private float _value { get; set; }
        public void Setvalue(float x) => _value = x;
        public override float GetValue() => _value;
    }
}
