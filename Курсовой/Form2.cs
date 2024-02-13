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
using System.Web;
using System.Collections.Specialized;

namespace Курсовой
{

    public partial class Form2 : Form
    {
        public static Form2 Instance;
        public static string Dnff;
        public static string Dnfk;
        public static Graph graph;
        public static List<Vertex> ListVertex;
        
        public void UpdateGraphg(Graph graph2, List<Vertex> ListVertexx)
        {
            ListVertex = ListVertexx;
            graph = graph2;
        }

        public void UpdateGraph(Graph graph2, List<Vertex> ListVertexx)
        {
            Dnff ="    sd";
            
            foreach (var item in ListVertex)
            {
                graph.AddVertex(item);
            }
            

            var matrix = graph.GetMatrix();
            List<Edge> bul_func = graph.GetDNF();

            Edge.RemoveIdential(bul_func);

            foreach (var zh in bul_func)
            {
                textBox2.Text += zh;
            }


            int[,] matrix2 = matrix;
            
            for (int i = 0; i < graph.VertexCount; i++) // Матрица дополняется единицами по главной диагонали
            {
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    
                    if (i == j)
                    {
                        matrix2[i, j] = 1;
                        foreach (var item in ListVertex)
                        {
                            if (j == item.Name)
                            {
                                graph.AddEdge(item, item);
                                break;
                            }
                        }
                    }


                }
            }
            
          
            string Ddd = graph.GetExternalDisjuncts(matrix2);
            this.textBox1.Text += "   " +Ddd;
            //Form2.Instance.textBox3.Text = Program.graph.GetGraphText();


        }

        public Form2(Graph graph, List<Vertex> ListVertex)
        {
            
            Instance = this;
            InitializeComponent();
            this.FormClosing += Form2_FormClosing; // Добавляем обработчик события FormClosing
            graph = graph;
            ListVertex = ListVertex;
            
            
        }


        public void textBox1_TextChanged(object sender, EventArgs e) //Днф 
        {
           

        }
        private void button1_Click(object sender, EventArgs e) // Ввод днф
        {


            string[] graphTextArray = Program.graph.GetGraphText();
            string[] Mnoj;
            


            Dnff = textBox4.Text;
            Dnfk = textBox5.Text;
            string[] boo = Dnff.Split(new char[] { 'V' });
            string[] bo1 = Dnfk.Split(new char[] { 'V' });

            List<string> InternalSets = graph.GetInternalSets(boo);
            
            string Obv = string.Join("V", InternalSets.Concat(bo1).Distinct()); 

            Obv.ToArray();

            string[] Obv1 = Obv.Split(new char[] { 'V' });
            Mnoj = new string[Obv1.Length];
            for (int i = 0; i < Obv1.Length; i++)
            {
                // Убираем скобки
                Obv1[i] = Obv1[i].Replace("(", "").Replace(")", "");
                // Разбиваем член на переменные
                string[] variables = Obv1[i].Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
                // Создаем новый член без * и добавляем его в массив
                Mnoj[i] = string.Join("", variables);


            }
            for (int b = 0; b < Mnoj.Length-1; b++) // берем множества x1x2x3 
            {
                Mnoj[b] = Mnoj[b].Replace("X", "");
                
                int sravnenie = int.Parse(Mnoj[b]);
               
                int c = 0;
                int k = 0;
                if (sravnenie < 10)
                {
                    
                    for (int j = 0; j < graphTextArray.Length; j++)
                    {
                        if (graphTextArray[j].Contains(sravnenie.ToString())) c++;

                    }
                if (c >= Program.graph.GetNumber() - 1) Form2.Instance.textBox3.Text += "{X" + sravnenie.ToString() +"}"+ Environment.NewLine;
                }
                if (sravnenie > 10)
                {
                    int n1 = sravnenie / 10;// Получаем первую цифру
                    int n2 = sravnenie % 10;// Получаем вторую цифру
                    for (int j = 0; j < graphTextArray.Length; j++)
                    {
                        graphTextArray[j].Replace("X", "");
                        if (n2 == 1) { 
                            if (graphTextArray[j].Contains(n2.ToString()+"2")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "3")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "4")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "5")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "6")) k++;
                        }
                        if (n2 == 2) {
                            if (graphTextArray[j].Contains(n2.ToString() + "1")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "3")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "4")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "5")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "6")) k++;
                        }
                        if (n2 == 3) {
                            if (graphTextArray[j].Contains(n2.ToString() + "2")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "1")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "4")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "5")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "6")) k++;
                        }
                        if (n2 == 4) {
                            if (graphTextArray[j].Contains(n2.ToString() + "2")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "3")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "1")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "5")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "6")) k++;
                        }
                        if (n2 == 5) {
                            if (graphTextArray[j].Contains(n2.ToString() + "2")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "3")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "4")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "1")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "6")) k++;
                        }
                        if (n2 == 6) {
                            if (graphTextArray[j].Contains(n2.ToString() + "2")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "3")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "4")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "5")) k++;
                            if (graphTextArray[j].Contains(n2.ToString() + "1")) k++;
                        }


                    }
                    if (k >= Program.graph.GetNumber() - 1) textBox3.Text += "X==" + sravnenie.ToString() + Environment.NewLine;

                }
            }


            //for (int j = 0; j < graphTextArray.Length; j++)
            //{
            //    if (graphTextArray[j].Contains(sravnenie.ToString())) c++;
            //}
            //Form2.Instance.textBox3.Text += "X=" + sravnenie.ToString() + Environment.NewLine;







        }



        public void textBox3_TextChanged(object sender, EventArgs e) // мин. доминирующее множество - вывод в текст. окно
        {
           

        }
        private void textBox4_TextChanged(object sender, EventArgs e) //Ввод Днф
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {
            InitializeComponent();

        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
            // В противном случае (например, если закрытие формы происходит из кода),
            // приложение не завершается, и вы можете выполнить другие необходимые действия.
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e) //Кнф внутри
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e) //Ввод днф внутреннего множества
        {
            

        }
    }
}
