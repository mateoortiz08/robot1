using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Extensibility;
using System.IO;

namespace Chat
{
	

	public partial class Configuracion : Form
	{
		
		private static Configuracion myInstancia=null;

		private System.Threading.Timer timer;

		SkypeFB skype;


		public static Configuracion getInstancia()
		{
			if (myInstancia == null)
			{
				myInstancia = new Configuracion();
			}
			return myInstancia;
		}

		private Configuracion()
		{
			InitializeComponent();
			skype = new SkypeFB();
			CargarDatos();
			

		}


		
		

		public void TiempoAvizo1(TimeSpan alertTime,String dato,int condicional)
		{
			DateTime current = DateTime.Now;
			TimeSpan timeToGo = alertTime - current.TimeOfDay;
			if (timeToGo < TimeSpan.Zero)
			{
				return;//time already passed
			}
			this.timer = new System.Threading.Timer(x =>
			{
				switch (condicional)
				{
					
					case 1:
						skype.iniciarChat();
						skype.enviarMensaje(dato);
						break;
					case 2:
						skype.enviarMensaje(dato);
						skype.terminarChat();
						break;
					
				}


				
			}, null, timeToGo, Timeout.InfiniteTimeSpan);
		}

		public void alertas(TimeSpan alertTime, int condicional)
		{
			DateTime current = DateTime.Now;
			TimeSpan timeToGo = alertTime - current.TimeOfDay;
			if (timeToGo < TimeSpan.Zero)
			{
				return;//time already passed
			}
			this.timer = new System.Threading.Timer(x =>
			{
				switch (condicional)
				{
					case 1:
						AvizarComienzo();
						break;
					case 2:
						AvizarCierre();
						break;
					

				}


				
			}, null, timeToGo, Timeout.InfiniteTimeSpan);
		}



		public void AvizarComienzo()
		{
			MessageBox.Show("EN 2 MINUTOS SE INICIARA EL CHAT", "AVIZO");
		}

		public void AvizarCierre()
		{
			MessageBox.Show("EN 2 MINUTOS SE CERRARA EL CHAT", "AVIZO");
		}




		
		private void button1_Click(object sender, EventArgs e)
		{
			guardarDatos();
			Obtener();

		}


		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		public void Obtener()
		{
		    int hora1 = Convert.ToInt32(this.hora1.Text);
			int seg1= Convert.ToInt32(this.seg1.Text);
			int hora2 = Convert.ToInt32(this.hora2.Text);
			int seg2 = Convert.ToInt32(this.seg2.Text);

			
			

			String bienvenida = textBox1.Text;
			String despedida = textBox2.Text;

			TiempoAvizo1(new TimeSpan(hora1, seg1, 00), textBox1.Text, 1);   //inicia chat
			TiempoAvizo1(new TimeSpan(hora2, seg2, 00), textBox2.Text, 2);   //cierra chat 

			
			if (seg1 < 2 && seg2 < 2)
			{

				if (seg1 == 0 && seg2 == 0)
				{
					hora1 = hora1 - 1;
					hora2 = hora2 - 1;
					seg1 = 58;
					seg2 = 58;


					alertas(new TimeSpan(hora1, seg1, 00),  1);   //alerta inicial
					alertas(new TimeSpan(hora2, seg2, 00),  2);     //alerta final


				}
				else
				{

					hora1 = hora1 - 1;
					hora2 = hora2 - 1;
					seg1 = 59;
					seg2 = 59;

					alertas(new TimeSpan(hora1, seg1, 00), 1);   //alerta inicial
					alertas(new TimeSpan(hora2, seg2, 00), 2);      //alerta final

				}

			}
			else
			{
				seg1 = seg1 - 2;
				seg2 = seg2 - 2;
				alertas(new TimeSpan(hora1, seg1, 00), 1);   //alerta inicial
				alertas(new TimeSpan(hora2, seg2, 00), 2);      //alerta final



			}



		}

		public void CargarDatos()
		{

			String line;
			String[] array = new String[6];
			int i = 0;

			//Pass the file path and file name to the StreamReader constructor
			StreamReader sr = new StreamReader("C:\\Users\\mateo.ortiz\\Desktop\\datos.txt");

			//Read the first line of text
			line = sr.ReadLine();

			//Continue to read until you reach end of file
			while (line != null)
			{
				//write the lie to console window
				Console.WriteLine(line);
				array[i] = line;
				//Read the next line
				line = sr.ReadLine();
				i++;
			}

			//close the file
			sr.Close();

			hora1.Text = array[0];
			seg1.Text = array[1];
			hora2.Text = array[2];
			seg2.Text = array[3];
			textBox1.Text = array[4];
			textBox2.Text = array[5];
			



		}

		public void guardarDatos() {

			StreamWriter sw = new StreamWriter("C:\\Users\\mateo.ortiz\\Desktop\\datos.txt");

			//Write a line of text
			sw.WriteLine(hora1.Text);
			sw.WriteLine(seg1.Text);
			sw.WriteLine(hora2.Text);
			sw.WriteLine(seg2.Text);
			sw.WriteLine(textBox1.Text);
			sw.WriteLine(textBox2.Text);
			

			//Close the file
			sw.Close();
		}



		private void button2_Click(object sender, EventArgs e)
		{
			

			




		}

		
	}
}
