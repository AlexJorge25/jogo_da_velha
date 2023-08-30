using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JogoDaVelhaC_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[,] grade = new string[3, 3];
            preencherMatriz(grade);
            string simbolo = "X";
            bool temVencedor = false;
            while (!temVencedor)
            {
                Console.WriteLine("  0 1 2\n0 x x x\n1 x x x\n2 x x x\n ");

                Console.WriteLine("Informe linha: ");
                int linha = int.Parse(Console.ReadLine());

                Console.WriteLine("Informe Coluna: ");
                int coluna = int.Parse(Console.ReadLine());

                if(linha > 2 || coluna > 2)
                {
                    Console.Clear();
                    Console.WriteLine("Jogada invalida,Digite novamente: ");
                    continue;
                }
                if (grade[linha, coluna] != " ")
                {
                    Console.Clear();
                    Console.WriteLine("Posição ja ocupada,Digite novamente: ");
                    continue;
                }
                Console.WriteLine("Quer continuar:\n1 - Sim\n2 - Não ");
                int continuar = int.Parse(Console.ReadLine());
                if (continuar == 2)
                {
                    temVencedor = true;
                    break;
                }

                grade[linha, coluna] = simbolo;
                
                Console.Clear();
                listarMatriz(grade);
                temVencedor = verificarVencedor(grade);
                if (!temVencedor)
                {
                    simbolo = simbolo ==  "X" ? "O" : "X";
                }

            }
            
            Console.Write($"Vencedor foi: {simbolo}");
            Console.ReadKey();
        }
        static void preencherMatriz(string[,] matriz)
        {
            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    matriz[linha, coluna] = " ";
                }
            }
        }
        static void listarMatriz(string[,] matriz)
        {
            
            for(int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                Console.WriteLine("------");
                for(int coluna = 0;coluna < matriz.GetLength(1); coluna++)
                {
                   
                    Console.Write(matriz[linha,coluna] + "|");
                    
                }
                Console.WriteLine();

            }
        }
        static bool verificarVencedor(string[,] matriz)
        {
            /*   0 1 2
               0 x x x
               1 x x x
               2 x x x  */
            string simbolo = matriz[0, 0];
            /*   0 1 2
               0 w w w
               1 x x x
               2 x x x  */
            if (simbolo == matriz[0,1] && simbolo == matriz[0,2] && simbolo != " ")
            {
                return true;
            }
            /*    0 1 2
                0 w x x
                1 x w x
                2 x x w  */
            else if (simbolo == matriz[1, 1] && simbolo == matriz[2, 2] && simbolo != " ")
            {
                return true;
            }
            
            /*   0 1 2
               0 x x x
               1 x x x
               2 x x x  */
            string simbolo1 = matriz[1, 0];
            /*   0 1 2
               0 w x x
               1 w x x
               2 w x x  */
            if (simbolo1 == matriz[0, 0] && simbolo1 == matriz[2, 0] && simbolo1 != " ")
            {
                return true;
            }
            /*   0 1 2
               0 x x x
               1 w w w
               2 x x x  */
            else if (simbolo1 == matriz[1, 1] && simbolo1 == matriz[1, 2] && simbolo1 != " ")
            {
                return true;
            }
            /*   0 1 2
               0 x x x
               1 x x x
               2 x x x  */
            string simbolo2 = matriz[2, 0];
            /*   0 1 2
               0 x x w
               1 x w x
               2 w x x  */
            
            if (simbolo2 == matriz[1, 1] && simbolo2 == matriz[0, 2] && simbolo2 != " ")
            {
                return true;
            }
            /*   0 1 2
               0 x x x
               1 x x x
               2 w x x  */
            else if (simbolo2 == matriz[2, 1] && simbolo2 == matriz[2, 2] && simbolo2 != " ")
            {
                return true;
            }
            /*   0 1 2
               0 x x x
               1 x x x
               2 x x x  */
            string simbolo3 = matriz[0, 1];
            if (simbolo3 == matriz[1, 1] && simbolo3 == matriz[2, 1] && simbolo3 != " ")
            {
                return true;
            }
            /*   0 1 2
               0 x x w
               1 x x w
               2 x x w  */
            string simbolo4 = matriz[0, 2];
            if (simbolo4 == matriz[1, 2] && simbolo4 == matriz[2, 2] && simbolo4 != " ")
            {
                return true;
            }


            return false;
        }

    }
}
