using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class SeriliazableDictionary_3Item<TKey, TValue1, TValue2> : Dictionary<TKey, Tuple<TValue1, TValue2>>, ISerializable
    {

        public List<TKey> keys = new List<TKey>();
        public List<TValue1> values1 = new List<TValue1>();
        public List<TValue2> values2 = new List<TValue2>();
        public void OnAfterDeserialize()
        {
            this.Clear();
            for (int i = 0; i < keys.Count; i++)
            {
                this.Add(keys[i], Tuple.Create(values1[i], values2[i]));
            }

        }

        public void OnBeforeSerialize()
        {
            keys.Clear();
            values1.Clear();
            values2.Clear();
            foreach (KeyValuePair<TKey, Tuple<TValue1, TValue2>> pair in this)
            {
                keys.Add(pair.Key);
                values1.Add(pair.Value.Item1);
                values2.Add(pair.Value.Item2);
            }
        }

    }


    

}
