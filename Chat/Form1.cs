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

			

			Configuracion conf = new Configuracion();
			conf.TiempoAvizo1(new TimeSpan(10, 07, 00));         // alerta admin1
			conf.TiempoAvizo2(new TimeSpan(10, 07, 15));         //alerta admin2
			conf.SetUpTimer1(new TimeSpan(16, 41, 00));      //msg bienvenida
		    conf.SetUpTimer3(new TimeSpan(16, 42, 00));      //msg avizo
			conf.SetUpTimer2(new TimeSpan(16, 43, 00));      //msg despedida

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
			Configuracion vista_confi = new Configuracion();
			vista_confi.Show();
			vista_confi.Activate();
			vista_confi.BringToFront();
		}
	}
}
