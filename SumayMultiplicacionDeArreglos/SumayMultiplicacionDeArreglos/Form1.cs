using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SumayMultiplicacionDeArreglos
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.Load += new System.EventHandler(this.Form1_Load);
            }

            private void btnSimular_Click(object sender, EventArgs e)
            {
                SimularDados();
            }

            private void SimularDados()
            {
                int[] frecuencias = new int[11]; // Arreglo para contar sumas de 2 a 12

                Random rand = new Random(); // Generador de números aleatorios

                // Realizar 36000 lanzamientos de dos dados
                for (int tiro = 0; tiro < 36000; tiro++) // Corrected loop condition
                {
                    int dado1 = rand.Next(1, 7); // Lanzar el primer dado
                    int dado2 = rand.Next(1, 7); // Lanzar el segundo dado
                    int suma = dado1 + dado2; // Calcular la suma de los valores de los dados

                    frecuencias[suma - 2]++; // Incrementar el contador correspondiente (0-10)
                }

                // Limpiar el DataGridView antes de llenarlo
                dgvResultados.Rows.Clear();

                // Llenar el DataGridView con los resultados
                for (int tiro = 0; tiro < frecuencias.Length; tiro++)
                {
                    int suma = tiro + 2;
                    dgvResultados.Rows.Add(suma, frecuencias[tiro]);
                }

                // Calcular el porcentaje de veces que aparece el 7
                double porcentaje = (double)frecuencias[5] / 36000 * 100;
                lblResultado.Text = $"La suma 7 apareció {frecuencias[5]} veces, lo que representa el {porcentaje}% de los lanzamientos";
            }

            private void Form1_Load(object sender, EventArgs e)
            {
                // Configurar columnas del DataGridView
                dgvResultados.ColumnCount = 2;
                dgvResultados.Columns[0].Name = "Suma";
                dgvResultados.Columns[1].Name = "Frecuencia";

                // Ajustar el tamaño de las columnas para que se vean correctamente
                dgvResultados.Columns[0].Width = 100;
                dgvResultados.Columns[1].Width = 150;

                // Evitar que el usuario edite las celdas del DataGridView
                dgvResultados.ReadOnly = true;

                // Ajustar el modo de tamaño automático de las filas
                dgvResultados.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                // Centrar el contenido de las celdas
                dgvResultados.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }
