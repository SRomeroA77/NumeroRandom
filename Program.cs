using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumeroRandom
{
    class Program
    {
        public static int IngresarNumero()
        {
            try
            {
            int num;
            Console.WriteLine("Ingrasa número entre 0 y 100");
            int.TryParse(Console.ReadLine(), out num);
            return num;
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocurrido un error.");
                return IngresarNumero();
                throw;
            }
            
        }

        public static bool CompararNumeros(int numRandom, int numEntregado)
        {
            
            int diff = numEntregado - numRandom;
            int diffPositivo = diff > 0 ? diff : -diff;
            string direccion = diff > 0 ? "Abajo" : "Arriba";
            switch (diffPositivo)
            {
                case int num when num > 50:
                    Console.WriteLine($"Muy frio {direccion}");
                    break;
                case int num when num > 25 & num <= 50:
                    Console.WriteLine($"Frio {direccion}");
                    break;
                case int num when num > 10 & num <= 25:
                    Console.WriteLine($"Caliente {direccion}");
                    break;
                case int num when num > 4 & num <= 10:
                    Console.WriteLine($"Muy caliente {direccion}");
                    break;
                case int num when num >= 1 & num <= 4:
                    Console.WriteLine($"Te quemas!! Un poco más {direccion}");
                    break;
                case int num when num == 0:
                    Console.WriteLine($"Has acertado!!");
                    return true;
                    break;
                default:
                    Console.WriteLine("Ha ocurrido un error");
                    break;
            }
            return false;
        }
        static void Main(string[] args)
        {
            bool repetir = true;
            while (repetir)
            {
                Random rand = new Random();
                int random = rand.Next(0, 101);
                int intentos = 4;
                bool acierto = false;
                int miNumero;
                while (intentos > 0 && acierto == false)
                {
                    miNumero = IngresarNumero();
                    acierto = CompararNumeros(random, miNumero);
                    intentos--;
                }
                Console.WriteLine($"El numero aleatorio es: {random}");
                if (acierto)
                {
                    Console.WriteLine("Lo has conseguido");
                }
                else
                {
                    Console.WriteLine("No lo has conseguido");
                }
                Console.WriteLine("Quieres repetir¿? [si] [no]");
                repetir = Console.ReadLine() == "si" ? true : false;
            }
            
        }
    }
}
