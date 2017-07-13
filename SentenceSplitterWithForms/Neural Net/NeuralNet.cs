using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SentenceSplitterWithForms.Helper;
using SentenceSplitterWithForms.Neural_Net.Neuron;
using SentenceSplitterWithForms.Neural_Net.Neuron.Connection;

namespace SentenceSplitterWithForms.Neural_Net
{
    [Serializable]
    class NeuralNet
    {
        public List<InputNeuron> InputLayer { get; set; } = new List<InputNeuron>();
        public List<WorkingNeuron> HiddenLayer { get; set; } = new List<WorkingNeuron>();
        public List<WorkingNeuron> OutputLayer { get; set; } = new List<WorkingNeuron>();

        public void CalculateValues(byte[] input)
        {
            var rand = new Random();
            for (var i = 0; i < input.Length; i++)
            {
                if (i >= InputLayer.Count)
                {
                    var inputN = new InputNeuron();
                    AddInputNeuron(inputN);
                    GenerateInputMesh(inputN, rand);
                    var neuron = new WorkingNeuron();
                    AddOutputNeuron(neuron);
                    GenerateOutputMesh(neuron, rand);
                }
                InputLayer[i].Setvalue(input[i]);
            }
            foreach (var neuron in HiddenLayer)
            {
                neuron.GetValue();
            }
            foreach (var neuron in OutputLayer)
            {
                neuron.GetValue();
            }
        }

        public void CreateLayers(int inputSize, int hiddenSize, int outputSize)
        {
            for (var i = 0; i < inputSize; i++)
            {
                InputLayer.Add(new InputNeuron());
            }
            for (var i = 0; i < hiddenSize; i++)
            {
                HiddenLayer.Add(new WorkingNeuron());
            }
            for (var i = 0; i < outputSize; i++)
            {
                OutputLayer.Add(new WorkingNeuron());
            }
            GenerateFullMesh(new Random());
        }

        public void AddInputNeuron(InputNeuron neuron) => InputLayer.Add(neuron);

        public void AddHiddenNeuron(WorkingNeuron neuron) => HiddenLayer.Add(neuron);

        public void AddOutputNeuron(WorkingNeuron neuron) => OutputLayer.Add(neuron);

        public void GenerateInputMesh(InputNeuron neuron, Random rand)
        {
            foreach (var hidden in HiddenLayer)
            {
                hidden.Connections.Add(new Connection(neuron, (float)rand.NextDouble() - 0.5f));
            }
        }

        public void GenerateHiddenMesh(WorkingNeuron neuron, Random rand)
        {
            var item = HiddenLayer.FindIndex(i => i == neuron);
            foreach (var input in InputLayer)
            {
                HiddenLayer[item].Connections.Add(new Connection(input, (float)rand.NextDouble() - 0.5f));
            }
            foreach (var output in OutputLayer)
            {
                output.Connections.Add(new Connection(HiddenLayer[item], (float)rand.NextDouble() - 0.5f));
            }
        }

        public void GenerateOutputMesh(WorkingNeuron neuron, Random rand)
        {
            var item = OutputLayer.FindIndex(i => i == neuron);
            foreach (var hidden in HiddenLayer)
            {
                OutputLayer[item].Connections.Add(new Connection(hidden, (float)rand.NextDouble() - 0.5f));
            }
        }

        public void GenerateFullMesh(Random rand)
        {
            foreach (var wn in HiddenLayer)
            {
                foreach (var input in InputLayer)
                {
                    wn.AddNeuronConnection(new Connection(input, (float)rand.NextDouble() - 0.5f));
                }
            }

            foreach (var wn in OutputLayer)
            {
                foreach (var wn2 in HiddenLayer)
                {
                    wn.AddNeuronConnection(new Connection(wn2, (float)rand.NextDouble() - 0.5f));
                }
            }
        }

        public void Invalidate()
        {
            foreach (var wn in HiddenLayer)
            {
                wn.Invalidate();
            }
            foreach (var wn in OutputLayer)
            {
                wn.Invalidate();
            }
        }

        #region TrainingMethod
        public void TrainNetwork(List<float> result)
        {
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < result.Count; j++)
                {
                    if (float.IsNaN(OutputLayer[j].GetValue()))
                    {
                        MessageBox.Show("Undefinierter Wert");
                        break;
                    }
                    OutputLayer[j].Err += Neuron.Neuron.SigmoidDerivate(OutputLayer[j].GetValue()) * (result[j] - OutputLayer[j].GetValue());
                    OutputLayer[j].AdjustWeights();
                }

                foreach (var hidden in HiddenLayer)
                {
                    if (float.IsNaN(hidden.GetValue()))
                    {
                        MessageBox.Show("Undefinierter Wert");
                        break;
                    }
                    var test1 = Neuron.Neuron.SigmoidDerivate(hidden.GetValue());
                    foreach (var output in OutputLayer)
                    {
                        hidden.Err += test1 * output.Err * output.Connections[output.Connections.FindIndex(p => p.EntNeur == hidden)].Wei;
                    }
                    hidden.AdjustWeights();
                }
            }
            Invalidate();
            BinarySerialization.WriteToBinaryFile("C:\\dev\\Projects\\Tests\\SentenceSplitterTest\\SentenceSplitterWithForms\\Store\\NetStore.bin", this);
        }
        #endregion
    }
}
