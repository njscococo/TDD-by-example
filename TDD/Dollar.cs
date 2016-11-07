using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD
{
    public class Dollar
    {
        private  int amount ;
        //private int p;

        public Dollar(int amount)
        {
            // TODO: Complete member initialization
            this.amount = amount;
        }



        public Dollar times(int p)
        {
            //throw new NotImplementedException();
            
            return new Dollar(amount * p);
        }

        //public bool equals(Object obj)
        //{
        //    var dollar = obj as Dollar;
        //    if(dollar==null){
        //        return false;
        //    }
        //    dollar.

        //    return this.amount == dollar.amount;
        //}


       

        
    }
}
