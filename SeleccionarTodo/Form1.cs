using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleccionarTodo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable datos = new DataTable();
            datos.Columns.Add("Columna1");
            datos.Columns.Add("Columna2");
            datos.Columns.Add("Columna3").DataType = typeof(bool);

            for (int i = 0; i<20;i++)
            {
                DataRow dr = datos.NewRow();
                dr[0] = i;
                dr[1] = i;
                dr[2] = false;
                datos.Rows.Add(dr);
            }

            dataGridView1.DataSource = datos;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                foreach (DataGridViewRow fila in dataGridView1.Rows)
                    fila.Cells[2].Value = true;
                
            }
            else
            {
                int counter = countChecks();
                if (counter == dataGridView1.Rows.Count)
                    foreach (DataGridViewRow fila in dataGridView1.Rows)
                        fila.Cells[2].Value = false;
                
            }

        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            dataGridView1.EndEdit();
            checkAll();
        }

        private void checkAll()
        {
            int counter = countChecks();
            if (counter == dataGridView1.Rows.Count)
                checkBox1.Checked = true;
            else
                checkBox1.Checked = false;
        }
        private int countChecks()
        {
            int counter = 0;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
                if ((bool)fila.Cells[2].Value)
                    counter++;
            return counter;
        }
    }
}
