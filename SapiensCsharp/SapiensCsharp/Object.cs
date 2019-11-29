using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapiensCsharp
{
    public class Object
    {
        public double divided { get; set; }

        public int multiplied { get; set; }

        public Object()
        {

        }
        public Object(double var1, double var2)
        {
            divided = SafeDivision((double)var1, var2);
            multiplied = (int)Multiplication(var1, var2);
        }


        public double SafeDivision(double var1, double var2)
        {
            if (var2 == 0)
                throw new DivideByZeroException();
            return var1 / var2;
        }

        public double Multiplication(double var1, double var2)
        {
            return var1 * var2;
        }


    }
}
