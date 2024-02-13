using Курсовой;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Курсовой
{
   
    public partial class Form1 : Form
    {
        private bool isDirectedEdge = false; // Initial value, assuming the default is non-directed

        
        public static Form2 form2;
        private Graph graph;
        private List<Vertex> ListVertex;

        public Form1(Graph graph, List<Vertex> ListVertex)
        {

            form2 = new Form2(graph, ListVertex);
            form2.Hide();
            InitializeComponent();
            ListVertex= new List<Vertex>();

            //var q1 = new Vertex(1);
            //var q2 = new Vertex(2);
            //var q3 = new Vertex(3);
            //var q4 = new Vertex(4);

            //ListVertex.Add(new Vertex(1));
            //ListVertex.Add(new Vertex(2));
            //ListVertex.Add(new Vertex(3));
            //ListVertex.Add(new Vertex(4));


            //graph.AddEdge(q1, q2);
            //graph.AddEdge(q2, q1);

            //graph.AddEdge(q1, q3);
            //graph.AddEdge(q3, q1);

            //graph.AddEdge(q1, q4);
            //graph.AddEdge(q4, q3);


            this.graph = graph;
            this.ListVertex = ListVertex;


            
            //form2.UpdateGraph(this.graph,this.ListVertex);
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

            // Создайте экземпляр Form2
            // Покажите Form2 и скройте Form1
            form2.UpdateGraph(this.graph, this.ListVertex);
            form2.Show();
           
            this.Hide();
            


        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) //Номер вершины ! список
        {

        }
        private void button2_Click(object sender, EventArgs e) //Кнопка добавить вершину !
        {
            uint numericUpDownValue = (uint)numericUpDown1.Value;
            // Добавление вершины в граф
            string myString = numericUpDownValue.ToString();
            //Form2.Instance.textBox1.Text = myString;
            if (this.ListVertex == null)
            {
                this.ListVertex = new List<Vertex>();
            }
            this.ListVertex.Add(new Vertex(numericUpDownValue));

            form2.UpdateGraphg(graph,ListVertex);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) // Указание является ли ребро ориентированным или нет (0 - ориент ; 1-неориент)
        {
            isDirectedEdge = checkBox1.Checked;

            // Обработка изменения состояния чекбокса (ориентированное/неориентированное ребро)

        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e) // первая вершина
        {
                    // Обработка изменения значения первой вершины ребра

        }
        private void numericUpDown3_ValueChanged(object sender, EventArgs e) // вторая вершина
        {

        }
        private void button3_Click(object sender, EventArgs e) // ввести ребро ! 
        {
            uint From = (uint)numericUpDown2.Value;
            uint To = (uint)numericUpDown3.Value;
            var VertexFrom = new Vertex(From);
            var VertexTo = new Vertex(To);
            graph.AddEdge(VertexFrom, VertexTo);
            if (isDirectedEdge)
            {
                graph.AddEdge(VertexTo, VertexFrom);
            }
            form2.UpdateGraphg(graph, ListVertex);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
