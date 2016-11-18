using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using TDD;

namespace TDD
{
    public class Bank
    {
        private Hashtable rates = new Hashtable();

        public TDD.Money reduce(TDD.Expression source, string currency)
        {
            return source.reduce(this, currency);
        }

        public int rate(String from , String to)
        {
            if (from.Equals(to)) return 1;
            foreach(DictionaryEntry de in rates){
                var keyname = de.Key as Pair;
                var code = keyname.GetHashCode();
            }

            //var a = rates[0].GetHashCode();
            var newobj = new Pair(from, to);
            int rate = int.Parse(rates[newobj].ToString());
            return rate;
        }

        public  void addRate(String from, String to, int rate)
        {
            rates.Add(new Pair(from, to), rate);            
        }
    }

    public   class Pair
    {
        private String from;
        private String to;

        public Pair(String from, String to)
        {
            this.from = from;
            this.to = to;
        }

        public override bool Equals(object obj)
        {
            var pair = obj as Pair;
            if(pair == null){
                return false;
            }
            return from.Equals(pair.from) && to.Equals(pair.to);
            //return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }        
    }
}
