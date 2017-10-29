using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2017.Shklianik._05
{
    public class Polynomial
    {
#region private fields
        private double[] coefficients;
        private int power;
        #endregion

        #region public methods

        /// <summary>
        /// The Polynomial constructor.
        /// </summary>
        /// <param name="array">double array</param>
        public Polynomial(double[] array)
        {
            power = array.Length - 1;
            coefficients = new double[power + 1];
            array.CopyTo(coefficients, 0);
            
        }
        /// <summary>
        /// The Power and Coefficients getters.
        /// </summary>
        /// <returns>Power return degree of polynom, Coefficients return array</returns>

        public int Power { get => power; }

        public double[] Coefficients
        {
            get
            {
                double[] coefficients = new double[this.coefficients.Length];
                this.coefficients.CopyTo(coefficients,0);
                return coefficients;
            }
        }

        /// <summary>
        /// The Equals method which compare objcts.
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>true or false</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            if (obj.GetHashCode() != GetHashCode()) return false;
            double[] newArr = ((Polynomial)obj).Coefficients;
            for (int i =0; i<= power; i++)
            {
                if (coefficients[i] != newArr[i]) return false;
            }
            return true;
        }

        /// <summary>
        /// The GetHashCode method which return hash code of power polynomial.
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return power;   
        }

        /// <summary>
        /// The ToString method which convert to string.
        /// </summary>
        /// <returns>string of polynomial</returns>
        public override string ToString()
        {
            string res = "";
            for (int i=0; i < power; i++)
            {
                res += coefficients[i].ToString() + ",";
            }
            res += coefficients[power].ToString();
            return res;
        }

        /// <summary>
        /// The operator +() method which overload plus opretion .
        /// </summary>
        /// <param name="pol1">first object</param>
        /// <param name="pol2">second object</param>
        /// <returns>sum of pol1 + pol2</returns>
        public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
        {
            double[] maxArray;
            double[] minArray;
            if (pol1.Power > pol2.Power)
            {
                maxArray = pol1.Coefficients;
                minArray = pol2.Coefficients;
                
            }
            else
            {
                maxArray = pol2.Coefficients;
                minArray = pol1.Coefficients;
            }
            int arrayMaxLength = maxArray.Length;
            int arrayMinLength = minArray.Length;


            for (int i = 0; i < arrayMinLength; i++)
            {
                maxArray[i] = minArray[i] + maxArray[i];
            }

            return new Polynomial(maxArray);
        }

        /// <summary>
        /// The operator *() method which multiplying of pol and number .
        /// </summary>
        /// <param name="pol">object</param>
        /// <param name="number"> number</param>
        /// <returns>mult pol*number</returns>
        public static Polynomial operator  *(Polynomial pol, int number)
        {
            double[] coefficients = pol.Coefficients;
            int coeffLength = pol.Power;
            for(int i = 0; i<=coeffLength; i++)
            {
                coefficients[i] *= number;
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// The operator *() method which multiplying of number and pol .
        /// </summary>
        /// <param name="number"> number</param>
        /// <param name="pol">object</param>
        /// <returns>multnumber*pol</returns>
        public static Polynomial operator *(int number, Polynomial pol)
        {
            return pol*number;
        }

        public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
        {
            return pol1 + pol2 * (-1);
        }

        public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
        {
            double[] coefficients1 = pol1.Coefficients;
            double[] coefficients2 = pol2.Coefficients;
            double[] newCoefficiets = new double[pol1.Power + pol2.Power + 1];

            for(int k = 0; k<= pol1.Power + pol2.Power; k++)
            {
                newCoefficiets[k] = 0;
                for (int i = 0; i <= k; i++)
                {
                    if (i <= pol1.Power && k-i <= pol2.Power)
                    {
                        newCoefficiets[k] += coefficients1[i] * coefficients2[k-i];
                    }
                }
            }
            
            return new Polynomial(newCoefficiets);
        }

        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            return pol1.Equals(pol2);
        }

        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            return !pol1.Equals(pol2);
        }
#endregion

    }
}



