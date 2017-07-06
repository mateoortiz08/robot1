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
        Configuracion conf = new Configuracion();
        static String[] datos = Datos.CargarDatos();
        bool activo = false;
        bool mostrar = true;
        SkypeFB skype;
        public Form1()
        {
            InitializeComponent();
            notificacion();

            skype = new SkypeFB();
            conf.CargarDatos();


            //conf.EjecutarDiario(new TimeSpan(00, 00, 00));



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

            Configuracion conf1 = new Configuracion();
            conf1.Show();
            conf1.Activate();
            conf1.BringToFront();
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            this.Refresh();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Console.WriteLine("minuto");
            bool verificar = this.verificarDia();

            DateTime time = Convert.ToDateTime(DateTime.Now);
            Console.WriteLine(time);
            string day = DateTime.Now.DayOfWeek.ToString();
            DateTime timeInicio = Convert.ToDateTime(datos[0] + ":" + datos[1]);
            DateTime timeFinal = Convert.ToDateTime(datos[2] + ":" + datos[3]);

            //Alertas
            int hora1 = Convert.ToInt32(datos[0]);
            int seg1 = Convert.ToInt32(datos[1]);
            int hora2 = Convert.ToInt32(datos[2]);
            int seg2 = Convert.ToInt32(datos[3]);
            int[] inicial = Convertir(hora1, hora2, seg1, seg2);
            // DateTime notificacion1 = Convert.ToDateTime(datos[0]+":"+)

            DateTime timeAlerta1 = Convert.ToDateTime(inicial[0] + ":" + inicial[2]);
            DateTime timerAlerta2 = Convert.ToDateTime(inicial[1] + ":" + inicial[3]);

            //Console.WriteLine(timeAlerta1.ToString());
            if (verificar && time.TimeOfDay.Ticks >= timeInicio.TimeOfDay.Ticks && !activo && time.TimeOfDay.Ticks < timeFinal.TimeOfDay.Ticks)
            {
                activo = true;
                skype.iniciarChat();
                skype.enviarMensaje(datos[9]);
            }

            if (verificar && time.TimeOfDay.Ticks >= timeFinal.TimeOfDay.Ticks && activo)
            {
                activo = false;
                Console.WriteLine(datos[10]);
                skype.enviarMensaje(datos[10]);
                skype.terminarChat();
            }


            if (verificar && time.TimeOfDay.Ticks >= timeAlerta1.TimeOfDay.Ticks && !activo && time.TimeOfDay.Ticks < timerAlerta2.TimeOfDay.Ticks && mostrar)
            {
                mostrar = false;
                conf.AvizarComienzo();
            }

            if (verificar && time.TimeOfDay.Ticks >= timerAlerta2.TimeOfDay.Ticks && activo && !mostrar)
            {
                mostrar = true;
                skype.enviarMensaje("En dos minutos se cerrará el chat");
                conf.AvizarCierre();
                
            }



           // Console.WriteLine(timeFinal.ToString());

        }

        public static void recargarDatos()
        {
            datos = Datos.CargarDatos();
        }

        public int[] Convertir(int hora1, int hora2, int seg1, int seg2)
        {
            int[] array = new int[4];
            if (seg1 < 2)
            {
                hora1 -= 1;
                if (seg1 == 0)
                {
                    seg1 = 58;
                }
                else
                {
                    seg1 = 59;
                }
            }
            else
            {
                seg1 -= 2; 
            }
            if (seg2 < 2)
            {
                hora2 -= 1;
                if (seg2 == 0)
                {
                    seg2 = 58;
                }
                else
                {
                    seg2 = 59;
                }
            }
            else
            {
                seg2 -= 2;
            }
            
            array[0] = hora1;
            array[1] = hora2;
            array[2] = seg1;
            array[3] = seg2;

            //Console.WriteLine("****");
            return (array);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Hide();
        }

        public void notificacion()
        {
            notificaciondeinicio.Text = "Chat Skype for Business";
            notificaciondeinicio.BalloonTipTitle = "Acaba De Iniciar";
            notificaciondeinicio.BalloonTipText = "Skype for Business";
            notificaciondeinicio.BalloonTipIcon = ToolTipIcon.Info;

            notificaciondeinicio.Visible = true;

            notificaciondeinicio.ShowBalloonTip(3000);

        }

        private void notificaciondeinicio_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        

        private void mostrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool verificarDia()
        {

            string day = DateTime.Now.DayOfWeek.ToString();
            switch (day)
            {
                case "Monday":
                    if ("true".Equals(datos[4])) { return true; }
                    break;
                case "Tuesday":
                    if ("true".Equals(datos[5])) { return true; }
                    break;

                case "Wednesday":
                    if("true".Equals(datos[6])) { return true; }

                    break;
                case "Thursday":
                    if("true".Equals(datos[7])) { return true; }

                    break;
                case "Friday":
                    if ("true".Equals(datos[8])) { return true; }

                    break;
                default:
                    return false;
                    
            }
            return false;
        }
    }
}
   

