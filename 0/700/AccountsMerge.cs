using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 721. 账户合并
    /// </summary>
    internal class AccountsMerge
    {
        public static IList<IList<string>> Run(IList<IList<string>> accounts)
        {
            Dictionary<string,List<HashSet<string>>> dic = new();
            foreach (var account in accounts) 
            {
                var data = account.Skip(1);
                if (dic.ContainsKey(account[0]))
                {
                    var list = dic[account[0]];

                    var overlaps = list.FindAll(v => v.Overlaps(data));
                    if (overlaps.Count > 0)
                    {
                        list.RemoveAll(v => overlaps.Contains(v));
                        HashSet<string> hash = new HashSet<string>(data);
                        overlaps.ForEach(v => hash.UnionWith(v));
                        list.Add(hash);
                    }
                    else
                    {
                        list.Add(new HashSet<string>(data));
                    }
                }
                else
                {
                    dic[account[0]] = new List<HashSet<string>>
                    {
                        new HashSet<string>(data)
                    };
                }
            }

            IList<IList<string>> result = new List<IList<string>>();
            foreach (var gruop in dic)
            {
                foreach(var user in gruop.Value)
                {
                    var emails = user.ToList();
                    emails.Sort(string.CompareOrdinal);
                    emails.Insert(0, gruop.Key);
                    result.Add(emails);
                }
            }

            return result;
        }
    }
}
