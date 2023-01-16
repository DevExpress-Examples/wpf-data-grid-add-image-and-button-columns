using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace GridControlCellTemplate.Model
{
    public class Record : BindableBase
    {
        public string Text {
            get => GetValue<string>();
            set => SetValue(value);
        }

        public bool IsRead {
            get => GetValue<bool>();
            set => SetValue(value);
        }

        public Record(string text) {
            Text = text;
        }

        public static IEnumerable<Record> GetData(int quantity) {
            var sentences = Regex.Split(File.ReadAllText(@"Model/Sentences.txt"), @"(?<=[\.!\?])\s+");

            var gen = new Random(42);

            for (int i = 0; i < quantity; i++) {
                yield return new Record(sentences[gen.Next(sentences.Length)]);
            }
        }
    }
}