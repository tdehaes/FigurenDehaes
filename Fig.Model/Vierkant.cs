using System;
using System.Collections.Generic;
using System.Text;

namespace Fig.Model
{
    public class Vierkant : Figuur
    {
        public override double BerekenOppervlakte()
        {
            return dim1 * dim1;
        }

        public override double BerekenOmtrek()
        {
            return dim1 * 4;
        }
    }
}
