﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDD
{
    public class Dollar
    {
        public  int amount ;
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

        public bool equals(Object obj)
        {
            Dollar dollar = obj as Dollar;

            return this.amount == dollar.amount;
        }

        
    }
}