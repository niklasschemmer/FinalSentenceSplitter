using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using SentenceSplitterWithForms.Helper;
using SentenceSplitterWithForms.Neural_Net;
using SentenceSplitterWithForms.Neural_Net.Neuron;

namespace SentenceSplitterWithForms
{
    public partial class Form1 : Form
    {
        private NeuralNet _net;
        private string _resultPreview;

        public Form1()
        {
            InitializeComponent();
        }

        private void FormOnload(object sender, EventArgs e)
        {
            try
            {
                _net = BinarySerialization.ReadFromBinaryFile<NeuralNet>("C:\\dev\\Projects\\Tests\\SentenceSplitterTest\\SentenceSplitterWithForms\\Store\\NetStore.bin");
            }
            catch (Exception)
            {
                // ignored
            }
            if (_net == null)
            {
                _net = new NeuralNet();
                for (var i = 0; i < 500; i++)
                {
                    _net.AddHiddenNeuron(new WorkingNeuron());
                }
                BinarySerialization.WriteToBinaryFile("C:\\dev\\Projects\\Tests\\SentenceSplitterTest\\SentenceSplitterWithForms\\Store\\NetStore.bin", _net);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartButtons(false);
            var textInput = Input.Text;
            Result.Text = Input.Text;
            _net.CalculateValues(Encoding.ASCII.GetBytes(textInput));
            for (int i = 0, j = 0; i < _net.OutputLayer.Count && j < textInput.Length; i++, j++)
            {
                if (_net.OutputLayer[i].Val > 0.95)
                {
                    textInput = textInput.Substring(0, j) + "|" + textInput.Substring(j, textInput.Length - j);
                    j++;
                }
            }
            Output.Text = textInput;
            StartButtons(true);
        }

        private void Train_Click(object sender, EventArgs e)
        {
            if (Result.Text.Replace("|", "") == Input.Text)
            {
                StartButtons(false);
                var target = Result.Text;
                var shouldBe = new List<float>();
                for (var i = 0; i < target.Length; i++)
                {
                    if (target[i] == '|')
                    {
                        shouldBe.Add(1);
                        i++;
                    }
                    else
                    {
                        shouldBe.Add(0);
                    }
                }
                _net.TrainNetwork(shouldBe);
                StartButtons(true);
            }
            Result.Text = "";
        }

        private void StartButtons(bool start)
        {
            Train.Enabled = start;
            Analyse.Enabled = start;
        }

        private void Result_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            _resultPreview = ((TextBox)sender).Text;
        }

        private void Result_KeyUp(object sender, KeyEventArgs e)
        {
            var box = (TextBox)sender;
            if (box.Text.Replace("|", "") != Input.Text.Replace("|", ""))
            {
                box.Text = _resultPreview;
            }
        }
    }
}
