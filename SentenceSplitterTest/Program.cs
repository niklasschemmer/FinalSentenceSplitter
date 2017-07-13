using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SentenceSplitterTest.Helper;
using SentenceSplitterTest.Neural_Net;
using SentenceSplitterTest.Neural_Net.Neuron;

namespace SentenceSplitterTest
{
    class Program
    {
        static void Main(string[] args)
        {
            NeuralNet net;
            net = JsonSaver.ReadFromJsonFile<NeuralNet>("C:\\dev\\Projects\\Tests\\SentenceSplitterTest\\SentenceSplitterTest\\Store\\NetStore.json");
            if (net == null)
            {
                net = new NeuralNet();
                for (var i = 0; i < 100; i++)
                {
                    net.AddHiddenNeuron(new WorkingNeuron());
                }
                JsonSaver.WriteToJsonFile("C:\\dev\\Projects\\Tests\\SentenceSplitterTest\\SentenceSplitterTest\\Store\\NetStore.json", net);
            }

            while (true)
            {
                Console.Write("Gib deinen Text ein.");
                var lines = Console.ReadLine()??"";
                Console.WriteLine(string.Concat(Enumerable.Repeat("|", lines.Length)));
                var charArr = string.Join("\n", lines);
                net.CalculateValues(Encoding.ASCII.GetBytes(charArr));
            }
        }
    }
}
