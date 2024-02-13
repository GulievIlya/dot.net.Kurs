using Курсовой;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Курсовой
{

    internal static class Program
    {

        public static Graph graph;
        public static List<Vertex> ListVertex;

       
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ListVertex = new List<Vertex>();
            graph = new Graph();


            Application.Run(new Form1(graph, ListVertex));
          









        }
    }
}
