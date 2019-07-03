using System;       // MicroSoft Visual Studio Express 2015 for Windows Desktop
using System.Numerics;          // needed for BigInteger
using System.Windows.Forms;     // needed for Clipboard

namespace fermat_a
{   class Program
    {   [STAThread]             // needed for Clipboard
        static void Main()
        {
            /* Variables ****************************************************************/
            BigInteger a, b, c, n;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            /* Assign Data **************************************************************/
            n = 339850094323758691; // 764567807 * 444499613 (3:51 minutes)
            a = iSqrt(n) + 1;
            c = (a * a) - n;        // start with remainder compliment 
            b = iSqrt(c);
            Console.WriteLine("\t Fermat 'a' Factoring\n {0}", n);

            /* Algorithm ****************************************************************/
            while ((b * b) != c)
            {   c += a++ + a;
                b = iSqrt(c);
            }
            /* Output Data **************************************************************/
            Console.WriteLine("\n p = {0}\n q = {1}", a + b, a - b);
            Console.WriteLine(" Press <Enter> to write to Clipboard");
            Console.Read(); Console.Read();
            sb.Append(a + b + "\n"); sb.Append(a - b + "\n");   // store in a string
            Clipboard.SetText(sb.ToString());                   // output to clipboard
            Console.Read();
        } // end of Main

          /* Methods ******************************************************************/
        private static BigInteger iSqrt(BigInteger num)
        { // Finds the integer square root of a positive number
            if (0 == num) { return 0; }             // Avoid zero divide
            BigInteger n = (num / 2) + 1;           // Initial estimate, never low
            BigInteger n1 = (n + (num / n)) >> 1;   // right shift to divide by 2
            while (n1 < n)
            {   n = n1;
                n1 = (n + (num / n)) >> 1;          // right shift to divide by 2
            }
            return n;
        } // end iSqrt()
    } // end Program
} // end namespace
