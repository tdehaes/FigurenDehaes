using System;
using System.Collections.Generic;
using System.Text;

namespace Fig.Model
{
    public class Cirkel : Figuur
    {
        public override double BerekenOppervlakte()
        {
            return dim1 * dim1 * Math.PI;
        }

        public override double BerekenOmtrek()
        {
            return dim1 * 2 * Math.PI;
        }
    }
}
