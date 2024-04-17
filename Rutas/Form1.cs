using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rutas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var bd = new RutasEntities())
                {
                    var Cliente = new Clientes();

                    Cliente.ClienteID = Convert.ToInt32(textBox1.Text);
                    Cliente.Nombre = textBox2.Text;
                    Cliente.TipoCliente = textBox3.Text;
                    bd.Clientes.Add(Cliente);
                    bd.SaveChanges();
                    MessageBox.Show(" registrado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var bd = new RutasEntities())
                {
                    var ventas = new Ventas();
                    ventas.VentaID = Convert.ToInt32(textBox4.Text);
                    ventas.ClienteID = Convert.ToInt32(textBox1.Text);
                    ventas.Ruta = textBox5.Text;
                    ventas.Precio = Convert.ToInt32(textBox6.Text);
                    ventas.NumeroPersonas = Convert.ToInt32(textBox7.Text);
                    bd.Ventas.Add(ventas);
                    bd.SaveChanges();
                    MessageBox.Show(" registrado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
