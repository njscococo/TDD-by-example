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
            return from.Equals("CHF") && to.Equals("USD") ? 2 : 1;
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

        
    }
}
