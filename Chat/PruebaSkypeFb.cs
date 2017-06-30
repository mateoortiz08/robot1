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
    public partial class PruebaSkypeFb : Form
    {
        SkypeFB skype;
        public PruebaSkypeFb()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            skype = new SkypeFB();
            skype.iniciarChat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            skype.terminarChat();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            skype.enviarMensaje(textBox1.Text);
        }
    }
}
