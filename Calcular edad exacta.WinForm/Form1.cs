using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Contados_de_dias_vividos.WinForm
{
    public partial class Form1 : Form
    {
        int Anio_Nacimiento;
        int Mes_Nacimiento;
        int Dia_Nacimiento;

        int Anio_Actual;
        int Mes_Actual;
        int Dia_Actual;

        int Anios_Vividos;
        int Meses_Vividos;
        int Dias_Vividos;
        public Form1()
        {
            InitializeComponent();
            Bitmap img = new Bitmap(Application.StartupPath + @"\img\fondo.jpg");
            this.BackgroundImage = img;
        }
        
        public void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Anio_Nacimiento = dateTimePicker1.Value.Year;
            Mes_Nacimiento = dateTimePicker1.Value.Month;
            Dia_Nacimiento = dateTimePicker1.Value.Day;
            MessageBox.Show(System.Convert.ToString("Fecha de nacimiento seleccionada correctamente"));
        }

        public void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            Anio_Actual = dateTimePicker2.Value.Year;
            Mes_Actual = dateTimePicker2.Value.Month;
            Dia_Actual = dateTimePicker2.Value.Day;
            MessageBox.Show(System.Convert.ToString("Fecha actual seleccionada correctamente"));
        }

        public void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            
            while (i != 51)
            {


                
                string cadena = new string('|', i);
                lblCargando.Text = cadena;
                Thread.Sleep(5);
                this.Refresh();
                i = i + 1;
                    
            }

            bool opcion0 = false;
            if (Anio_Actual == 0)
            {
                MessageBox.Show("Debes remarcar aunque sea una vez la fecha actual o dara error en los numeros.");
                
                opcion0 = true;
            }

            if (opcion0 == true)
            {
                Meses_Vividos = -1;
                Dias_Vividos = -1;
                Anios_Vividos = -1;
                
            }
            

            bool opcion1 = false;
            if (Dia_Actual < Dia_Nacimiento & Mes_Actual < Mes_Nacimiento & opcion0== false)
            {
                opcion1 = true;
            }
            
            bool opcion2 = false;
            if(Dia_Actual < Dia_Nacimiento & Mes_Actual > Mes_Nacimiento)
            {
                opcion2 = true;
            }
            bool opcion3 = false;
            if (Dia_Actual > Dia_Nacimiento & Mes_Actual < Mes_Nacimiento)
            {
                opcion3 = true;
            }
            bool opcion4 = false;
            if (Dia_Actual >= Dia_Nacimiento & Mes_Actual >= Mes_Nacimiento)
            {
                opcion4 = true;
            }

            

            if (opcion1 == true)
            {
                Meses_Vividos = (12 - Mes_Nacimiento) + Mes_Actual - 1;
                Dias_Vividos = (30 - Dia_Nacimiento) + Dia_Actual;
                Anios_Vividos = Anio_Actual - Anio_Nacimiento - 1;
            }

            else if (opcion2 == true)
            {
                Meses_Vividos = (Mes_Actual - Mes_Nacimiento) - 1;
                Dias_Vividos = (30 - Dia_Nacimiento) + Dia_Actual;
                Anios_Vividos = Anio_Actual - Anio_Nacimiento;


            }

            else if (opcion3 == true)
            {
                Meses_Vividos = (12 - Mes_Nacimiento) + Mes_Actual;
                Dias_Vividos = Dia_Actual - Dia_Nacimiento;
                Anios_Vividos = Anio_Actual - Anio_Nacimiento - 1;
            }

            else if (opcion4 == true)
            {
                Meses_Vividos = Mes_Actual - Mes_Nacimiento;
                Dias_Vividos = Dia_Actual - Dia_Nacimiento;
                Anios_Vividos = Anio_Actual - Anio_Nacimiento;
            }

            

            
            lblAnios.Text = System.Convert.ToString(Anios_Vividos);
            lblMes.Text = System.Convert.ToString(Meses_Vividos);
            lblDias.Text = System.Convert.ToString(Dias_Vividos);

            
        }

        public void button2_Click(object sender, EventArgs e)
        {
            int Cantidad_Dias_Meses = Meses_Vividos * 30;
            int Cantidad_Dias_Anios = Anios_Vividos * 365;
            int Cantidad_Dias_Total = Dias_Vividos + Cantidad_Dias_Anios + Cantidad_Dias_Meses;
            lblTotalDias.Text = System.Convert.ToString(Cantidad_Dias_Total);
        }
    }
}
