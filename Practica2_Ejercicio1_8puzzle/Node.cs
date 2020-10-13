using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2_Ejercicio1_8puzzle
{
    class Node
    {
        #region Variables y Metodos
        private List<Node> children = new List<Node>();         //Lista para los nodos hijos que resultan al realizar un movimiento
        private Node parent;                                    //Nodo padre 
        private int[] puzzle = new int[9];                      //Arreglo del puzzle, o estructura actual
        private int x = 0;                                      //Indicador de posicion del 0

        public int[] Puzzle { get => puzzle; set => puzzle = value; }
        public int X { get => x; set => x = value; }
        internal List<Node> Children { get => children; set => children = value; }
        internal Node Parent { get => parent; set => parent = value; }
        #endregion

        #region Constructor
        public Node(int [] value)
        {
            SetPuzzle(value); //Establecer el puzzle actual
        }
        #endregion

        //Funcion para copear el puzzle inicial a la clase para ser alamacenado
        public void SetPuzzle(int[] value)
        {
            for (int i = 0; i < puzzle.Length; i++)
            {
                this.puzzle[i] = value[i];
            }
        }

        //
    }
}
