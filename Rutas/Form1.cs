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
                    int ventaID;
                    if (int.TryParse(textBox4.Text, out ventaID))
                    {
                        ventas.VentaID = ventaID;
                    }
                    else
                    {
                        MessageBox.Show("El ID de venta ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int clienteID;
                    if (int.TryParse(textBox8.Text, out clienteID))
                    {
                        ventas.ClienteID = clienteID;
                    }
                    else
                    {
                        MessageBox.Show("El ID de cliente ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ventas.Ruta = textBox5.Text;

                    decimal precio;
                    if (decimal.TryParse(textBox6.Text, out precio))
                    {
                        ventas.Precio = precio;
                    }
                    else
                    {
                        MessageBox.Show("El precio ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int numeroPersonas;
                    if (int.TryParse(textBox7.Text, out numeroPersonas))
                    {
                        ventas.NumeroPersonas = numeroPersonas;
                    }
                    else
                    {
                        MessageBox.Show("El número de personas ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bd.Ventas.Add(ventas);
                    bd.SaveChanges();
                    MessageBox.Show("Registrado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int clienteID = Convert.ToInt32(textBox9.Text); // Obtener el ID del cliente desde algún campo en tu formulario
                using (var bd = new RutasEntities())
                {
                    // Buscar el cliente en la base de datos
                    var cliente = bd.Clientes.FirstOrDefault(c => c.ClienteID == clienteID);
                    if (cliente == null)
                    {
                        MessageBox.Show("El cliente no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Obtener la cantidad de personas registradas para este cliente
                    var cantidadPersonas = bd.Ventas.Where(v => v.ClienteID == clienteID).Sum(v => v.NumeroPersonas);

                    // Obtener el precio inicial para este cliente
                    var precioInicial = bd.Ventas.Where(v => v.ClienteID == clienteID).Sum(v => v.Precio * v.NumeroPersonas);

                    // Calcular el porcentaje de descuento según la cantidad de personas registradas
                    decimal descuento = 0;
                    if (cantidadPersonas >= 2 && cantidadPersonas < 7)
                    {
                        descuento = 0.08m; // 8%
                    }
                    else if (cantidadPersonas >= 7 && cantidadPersonas < 16)
                    {
                        descuento = 0.13m; // 13%
                    }
                    else if (cantidadPersonas >= 16)
                    {
                        descuento = 0.15m; // 15%
                    }

                    // Calcular el precio final con descuento
                    decimal  precioFinal =   descuento;
                    decimal precio = descuento * precioFinal;
                    decimal final = precio - precioFinal;

                    // Mostrar los resultados
                    MessageBox.Show($"Cliente: {cliente.Nombre}\nCantidad de personas: {cantidadPersonas}\nPrecio inicial: {precioInicial}\nPorcentaje de descuento: {descuento * 100}%\nPrecio final con descuento: {precioFinal}", "Descuento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular descuento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
