using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_Ejercicio1_8puzzle
{
    class UninformedSearch
    {
        public UninformedSearch()
        {

        }

        public List<Node> BreadthFirstSearch(Node root)
        {
            List<Node> PathToSolution = new List<Node>();
            List<Node> OpenList = new List<Node>(); //Lista que se puede expandir
            List<Node> ClosedList = new List<Node>(); //Las que ya fueron vistas y expandidas

            OpenList.Add(root); // Iniciar con la raíz
            bool goalFound = false; //Se llegó a la meta

            while (OpenList.Count > 0 && !goalFound) //Mientras haya posibilidades y no se haya llegado a la meta
            {
                //Las 3 lineas Simulan una cola 
                Node currentNode = OpenList[0]; //Primer elemento
                ClosedList.Add(currentNode); // Para no volver a entrar ahí
                OpenList.RemoveAt(0); //Sacarlo

                currentNode.ExpandNode();
                currentNode.PrintPuzzle();

                for (int i = 0; i < currentNode.Children.Count; i++)
                {

                    Node currentChild = currentNode.Children[i];

                    //Aquí imprimiremos todos los estados

                    if (currentChild.GoalTest())
                    {
                        Console.WriteLine("Goal Found.");
                        goalFound = true;
                        PathTrace(PathToSolution, currentChild);
                        //Trace path to root node
                    }

                    //OpenList contiene currentChild && ClosedList contains currents child
                    if (!Contains(OpenList, currentChild) && !Contains(ClosedList, currentChild))
                    {
                        OpenList.Add(currentChild);
                    }

                }
            }

            return PathToSolution;
        }

        public List<Node> DeepFirstSearch(Node root)
        {
            List<Node> PathToSolution = new List<Node>();
            List<Node> OpenList = new List<Node>(); //Lista que se puede expandir
            List<Node> ClosedList = new List<Node>(); //Las que ya fueron vistas y expandidas

            OpenList.Add(root); // Iniciar con la raíz
            bool goalFound = false; //Se llegó a la meta

            while (OpenList.Count > 0 && !goalFound) //Mientras haya posibilidades y no se haya llegado a la meta
            {
                //Las 3 lineas Simulan una cola 
                Node currentNode = OpenList.Last(); //Primer elemento
                ClosedList.Add(currentNode); // Para no volver a entrar ahí
                OpenList.Remove(currentNode); //Sacarlo

                currentNode.ExpandNode();
                currentNode.PrintPuzzle();

                for (int i = 0; i < currentNode.Children.Count; i++)
                {

                    Node currentChild = currentNode.Children[i];

                    //Aquí imprimiremos todos los estados

                    if (currentChild.GoalTest())
                    {
                        Console.WriteLine("Goal Found.");
                        goalFound = true;
                        PathTrace(PathToSolution, currentChild);
                        //Trace path to root node
                    }

                    //OpenList contiene currentChild && ClosedList contains currents child
                    if (!Contains(OpenList, currentChild) && !Contains(ClosedList, currentChild))
                    {
                        OpenList.Add(currentChild);
                    }

                }
            }

            return PathToSolution;
        }
        public void PathTrace(List<Node> path , Node n)
        {
            Console.WriteLine("Tracin path...");
            Node current = n;
            path.Add(current);

            while(current.Parent != null) //Agregará todos los nodos padres de donde está hasta la raíz
            {
                current = current.Parent;
                path.Add(current);
            }

        }

        public static bool Contains(List<Node> list,Node c)
        {
            bool contains = false;

            for(int i = 0; i < list.Count;i++ )
            {
                if(list[i].IsSamePuzzle(c.Puzzle))
                {
                    contains = true;
                }
            }
            return contains;
        }
    }
}
