using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Chat
{
    public partial class Form1 : Form
    {
		public Form1()
		{
			InitializeComponent();
			

			
			Configuracion conf = Configuracion.getInstancia();
			conf.CargarDatos();
			conf.Obtener();

			conf.EjecutarDiario(new TimeSpan(00, 00, 00));

		}

		private void btn_login_Click(object sender, EventArgs e)
		{
            /*
			login formLogin = new login();
			formLogin.Show();
			formLogin.Activate();
			formLogin.BringToFront();
            */
            PruebaSkypeFb prueba = new PruebaSkypeFb();
            prueba.Show();
            prueba.Activate();
            prueba.BringToFront();
		}

		private void Btn_Configuracion_Click(object sender, EventArgs e)
		{
			Configuracion vista_confi =  Configuracion.getInstancia();
			vista_confi.Show();
			vista_confi.Activate();
			vista_confi.BringToFront();
		}
	}
}
