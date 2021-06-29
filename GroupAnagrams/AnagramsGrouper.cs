using System.Collections.Generic;
using System.Linq;

namespace GroupAnagrams
{
    public class AnagramsGrouper
    {
        public List<List<string>> Group(List<string> strs)
        {
            if (strs.Count() == 0) {
                return new List<List<string>>();
            }

            if (strs.Count() == 1) {
                return new List<List<string>> {
                    new List<string> {
                        strs[0]
                    }
                };
            }

            var dict = new Dictionary<string, List<string>>();
            foreach (var str in strs) {
                var lowerCaseCase = str.ToLower();
                var ch = lowerCaseCase.OrderBy(x => x);
                var orderedString = string.Join("", ch);
                
                if (dict.TryGetValue(orderedString, out var value)) {
                    value.Add(lowerCaseCase);
                } else {
                    dict.Add(orderedString, new List<string>(){ lowerCaseCase });
                }
            }

            return dict.Select(x => x.Value).ToList();
        }
    }
}