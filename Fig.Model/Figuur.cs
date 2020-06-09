using System;
using System.Collections.Generic;
using System.Text;

namespace Fig.Model
{
    public abstract class Figuur: FiguurInterface
    {

        public double dim1 { get; set; }

        public abstract double BerekenOppervlakte();

        public abstract double BerekenOmtrek();
    }
}
