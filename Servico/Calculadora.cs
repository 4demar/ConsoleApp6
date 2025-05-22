
namespace Service
{
    public class Calculadora
    {
        public static int Somar(int n1, int n2)
        {
            return n1 + n2;
        }

        public static int Subtrair(int n1, int n2)
        {
            return n1 - n2;
        }

        public static int Multiplicar(int n1, int n2)
        {
            return n1 * n2;
        }

        public static double Dividir(double n1, double n2)
        {
            if (n2 == 0)
                throw new ArgumentException("Denominador não pode ser zero.");

            return n1 / n2;
        }
    }
}
