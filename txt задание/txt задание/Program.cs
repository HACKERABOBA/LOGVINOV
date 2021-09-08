using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace txt_задание
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = @"Peter Piper picked a peck of pickled peppers.A peck of pickled
                            peppers Peter Piper picked.If Peter Piper picked a peck of
                            pickled peppers, where is the peck that Peter Piper picked?";
            var matches = Regex.Split(data.ToLower(), "\r\n");

            Dictionary<string, Tmp> dct = new Dictionary<string, Tmp>();
            int index = 1;
            foreach (var sent in matches)
            {
                var words = Regex.Matches(sent, @"\w+(-\w+)*").Cast<Match>().Select(i => i.Value).ToArray();
                foreach (var word in words)
                {
                    if (!dct.ContainsKey(word))
                        dct.Add(word, new Tmp() { Rows = new HashSet<int>() });

                    var value = dct[word];
                    value.Rows.Add(index);
                    value.Count++;
                }
                index++;
            }

            foreach (var item in dct.OrderBy(b => b.Key))
            {
                Console.WriteLine("{0}{1}:{2}", item.Key.PadRight(10, '_'), item.Value.Count, string.Join(" ", item.Value.Rows));
            }
            Console.ReadKey();
        }
        class Tmp
        {
            public int Count;
            public HashSet<int> Rows;

        }
    }
}
