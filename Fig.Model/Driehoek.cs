using System;
using System.Collections.Generic;
using System.Text;

namespace Fig.Model
{
    public class Driehoek : Figuur
    {
        public double dim2 { get; set; }
        
        public double BerekenLengteC()
        {
            return Math.Sqrt(dim1 * dim1 + dim2 * dim2);
        }

        public override double BerekenOppervlakte()
        {
            return (dim1 * dim2) / 2;
        }

        public override double BerekenOmtrek()
        {
            return BerekenLengteC() + dim1 + dim2; 
        }

    }
}