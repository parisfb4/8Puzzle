using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_Ejercicio1_8puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            //Puzzle Inicial
            int[] puzzle_initial =
            {
                2,4,5,
                6,0,7,
                8,3,1
            };

            Node root = new Node(puzzle_initial);   //Envia el puzzle inicial a la clase
            UninformedSearch ui = new UninformedSearch();

            List<Node> solution = ui.BreadthFirstSearch(root);
            
            if(solution.Count>0)
            {
                Console.WriteLine("Solución encontrada");
                for (int i = 0; i<solution.Count;i++)
                {
                    solution[i].PrintPuzzle();
                }
            }
            else
            {
                Console.WriteLine("No hay solución para este problema");                    
            }
            Console.Read();
        }
    }
}
