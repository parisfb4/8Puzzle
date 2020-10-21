using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_Ejercicio1_8puzzle
{
    class Menu
    {       
        public void mostrarMenu()
        {
            int opc = 0;
            do
            {
                Console.WriteLine(" \t 8 puzzle - Algoritmos de búsqueda\n" +
                    "1) Amplitud\n" +
                    "2) Profundidad\n" +
                    "3) Profundidad iterativa\n" +
                    "4) Salir");
                opc = Convert.ToInt16(Console.ReadLine());

                switch(opc)
                {
                    case 1:
                        Amplitud();
                        break;
                    case 2:
                        Profundidad();
                        break;
                    case 3:
                        Console.WriteLine("Profundidad iterativa, (en proceso)");
                        break;
                    case 4:
                        Console.WriteLine("Adios");
                        break;
                    default:
                        break;
                }

            } while (opc != 4);
        }
        public void Amplitud()
        {
            //Puzzle Inicial
            int[] puzzle_initial = generarPuzzleAleatorio();

            Node root = new Node(puzzle_initial);   //Envia el puzzle inicial a la clase
            UninformedSearch ui = new UninformedSearch();
           
            List<Node> solution = ui.BreadthFirstSearch(root);
            if (solution.Count > 0)
            {
                Console.WriteLine("Solución encontrada");
                for (int i = 0; i < solution.Count; i++)
                {
                    solution[i].PrintPuzzle();
                }
            }
            else
            {
                Console.WriteLine("No hay solución para este problema");
            }                 
        }
        public void Profundidad()
        {
            //Puzzle Inicial
            int[] puzzle_initial = generarPuzzleAleatorio();

            Node root = new Node(puzzle_initial);   //Envia el puzzle inicial a la clase
            UninformedSearch ui = new UninformedSearch();

            List<Node> solution = ui.DeepFirstSearch(root);
            if (solution.Count > 0)
            {
                Console.WriteLine("Solución encontrada");
                for (int i = 0; i < solution.Count; i++)
                {
                    solution[i].PrintPuzzle();
                }
            }
            else
            {
                Console.WriteLine("No hay solución para este problema");
            }
        }

        public int[] generarPuzzleAleatorio()
        {
            int space = 9;
            Random rnd = new Random();
            int[] number = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> numbersChosen = new List<int>();
            int[] tablero = new int[space];

            int posible;
            for(int i = 0; i< space; ++i)
            {
               
               posible = rnd.Next(9);
                while (numbersChosen.Contains(posible))
                {
                    
                    
                    posible = rnd.Next(9);
                }
                tablero[i] = posible;
                numbersChosen.Add(posible);
            }

            return tablero;
        }
    }
}
