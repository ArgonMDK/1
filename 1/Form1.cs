using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.Linq;
using System.Data.SqlClient;

namespace _1
{
    public partial class Form1 : Form
    {
        static string conStr = "Data Source=DESKTOP-1PNR289;Initial Catalog=avto;Integrated Security=True";
        DataContext context = new DataContext(conStr);
        public Form1()
        {
            InitializeComponent();
            Table<Пункты> Пунк = context.GetTable<Пункты>();
            dataGridView1.DataSource = Пунк.ToList();
            Table<Рейсы> Рейс = context.GetTable<Рейсы>();
            dataGridView3.DataSource = Рейс.ToList();
            Table<Маршрут> Марш = context.GetTable<Маршрут>();
            dataGridView2.DataSource = Марш.ToList();
            Table<Автобусы> Автобус = context.GetTable<Автобусы>();
            dataGridView4.DataSource = Автобус.ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Пункты Пун = new Пункты { Пункт_назначения = textBox3.Text };
            context.GetTable<Пункты>().InsertOnSubmit(Пун);
            context.SubmitChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Маршрут Мар = new Маршрут { Пункт_отпр = textBox1.Text, Пункт_приб = textBox2.Text };
            context.GetTable<Маршрут>().InsertOnSubmit(Мар);
            context.SubmitChanges();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Маршрут Ма = context.GetTable<Маршрут>().FirstOrDefault(x => x.Код_маршрута == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            Ма.Пункт_отпр = textBox4.Text;
            Ма.Пункт_приб = textBox5.Text;
            context.SubmitChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var f = context.GetTable<Автобусы>().Where(x => x.Водитель.Contains(Convert.ToString(comboBox3.SelectedValue)));
            dataGridView4.DataSource = f.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "avtoDataSet.Автобусы". При необходимости она может быть перемещена или удалена.
            this.автобусыTableAdapter.Fill(this.avtoDataSet.Автобусы);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView3.RowCount; i++)
            {
                for (int j = 0; j < dataGridView3.ColumnCount; j++)
                {
                    if (dataGridView3.Rows[i].Cells[j].Value != null)
                    {
                        if (dataGridView3.Rows[i].Cells[j].Value.ToString().Contains(textBox6.Text))
                        {
                            dataGridView3.Rows[i].Selected = true;
                            break;
                        }
                        dataGridView3.Rows[i].Selected = false;
                    }
                }
            }
        }
    }
}
