using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ti4
{
    class Attack
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static Dictionary<string, List<int>> RepeatedBlocks(string input)
        {
            var repeatedMap = new Dictionary<string, List<int>>();
            for (var i = 0; i < input.Length - 3; i++)
            {
                string block = input.Substring(i, 3);
                if (!repeatedMap.ContainsKey(block))
                    repeatedMap[block] = new List<int>();
                repeatedMap[block].Add(i);
            }

            return repeatedMap;
        }

        public static List<int> CalcKeyLengths(Dictionary<string, List<int>> repeatedMap)
        {
            var keyLengths = new List<int>();
            foreach (var map in repeatedMap)
            {
                var positions = map.Value;
                for (var i = 0; i < positions.Count - 1; i++)
                {
                    for (var j = i + 1; j < positions.Count; j++)
                    {
                        var distance = positions[j] - positions[i];
                        if (distance > 0)
                            keyLengths.Add(distance);
                    }
                }
            }

            return keyLengths;
        }
    }
}
