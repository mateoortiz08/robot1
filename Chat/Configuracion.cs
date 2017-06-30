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

namespace Chat
{
	public partial class Configuracion : Form
	{
		LyncClient lyncClient;
		Automation automation;
		ContactManager contactMgr;
		List<SearchProviders> activeSearchProviders;
		ContactSubscription searchResultSubscription;

		public Configuracion()
		{
			InitializeComponent();

			try
			{


				//Obtener instancias de Lync Client y Contact Manager.
				lyncClient = LyncClient.GetClient();
				automation = LyncClient.GetAutomation();
				contactMgr = lyncClient.ContactManager;

				activeSearchProviders = new List<SearchProviders>();
				searchResultSubscription = contactMgr.CreateSubscription();

				// Carga Proveedor de búsqueda experto si está configurado y habilita la casilla de verificación.
				if (contactMgr.GetSearchProviderStatus(SearchProviders.Expert)
							  == SearchProviderStatusType.SyncSucceeded || contactMgr.GetSearchProviderStatus(SearchProviders.Expert)
							  == SearchProviderStatusType.SyncSucceededForExternalOnly || contactMgr.GetSearchProviderStatus(SearchProviders.Expert)
							  == SearchProviderStatusType.SyncSucceededForInternalOnly)
				{
					activeSearchProviders.Add(SearchProviders.Expert);

				}

				// Registrarse para el evento SearchProviderStatusChanged
				// by ContactManager.
				//contactMgr.SearchProviderStateChanged += contactMgr_SearchProviderStateChanged;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error:    " + ex.Message);
			}
		}


		private System.Threading.Timer timer;
		public void SetUpTimer1(TimeSpan alertTime)
		{
			DateTime current = DateTime.Now;
			TimeSpan timeToGo = alertTime - current.TimeOfDay;
			if (timeToGo < TimeSpan.Zero)
			{
				return;//time already passed
			}
			this.timer = new System.Threading.Timer(x =>
			{
				this.EnviarMensajeBienvenida();
			}, null, timeToGo, Timeout.InfiniteTimeSpan);
		}

		public void SetUpTimer2(TimeSpan alertTime)
		{
			DateTime current = DateTime.Now;
			TimeSpan timeToGo = alertTime - current.TimeOfDay;
			if (timeToGo < TimeSpan.Zero)
			{
				return;//time already passed
			}
			this.timer = new System.Threading.Timer(x =>
			{
				this.EnviarMensajeDespedida();
			}, null, timeToGo, Timeout.InfiniteTimeSpan);
		}

		public void SetUpTimer3(TimeSpan alertTime)
		{
			DateTime current = DateTime.Now;
			TimeSpan timeToGo = alertTime - current.TimeOfDay;
			if (timeToGo < TimeSpan.Zero)
			{
				return;//time already passed
			}
			this.timer = new System.Threading.Timer(x =>
			{
				this.EnviarMensajeAviso();
			}, null, timeToGo, Timeout.InfiniteTimeSpan);
		}

		public void TiempoAvizo1(TimeSpan alertTime)
		{
			DateTime current = DateTime.Now;
			TimeSpan timeToGo = alertTime - current.TimeOfDay;
			if (timeToGo < TimeSpan.Zero)
			{
				return;//time already passed
			}
			this.timer = new System.Threading.Timer(x =>
			{
				this.AvizarComienzo();
			}, null, timeToGo, Timeout.InfiniteTimeSpan);
		}

		public void TiempoAvizo2(TimeSpan alertTime)
		{
			DateTime current = DateTime.Now;
			TimeSpan timeToGo = alertTime - current.TimeOfDay;
			if (timeToGo < TimeSpan.Zero)
			{
				return;//time already passed
			}
			this.timer = new System.Threading.Timer(x =>
			{
				this.AvizarCierre();
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




		private void EnviarMensajeBienvenida()
		{
			List<string> inviteeList = new List<string>();

			inviteeList.Add("sip:alex.agudelo@accenture.com");



			// Create a generic Dictionary object to contain
			// conversation setting objects.
			Dictionary<AutomationModalitySettings, object> modalitySettings = new
				Dictionary<AutomationModalitySettings, object>();
			AutomationModalities chosenMode = AutomationModalities.InstantMessage;
			string firstIMMessageText = textBox1.Text;

			IAsyncResult ar = automation.BeginStartConversation(
		  chosenMode
		  , inviteeList
		  , modalitySettings
		  , null
		  , null);

			modalitySettings.Add(AutomationModalitySettings.FirstInstantMessage, firstIMMessageText);
			modalitySettings.Add(AutomationModalitySettings.SendFirstInstantMessageImmediately,
				true);
			IAsyncResult er = automation.BeginStartConversation(
		  chosenMode
		  , inviteeList
		  , modalitySettings
		  , null
		  , null);


		}

		private void EnviarMensajeDespedida()
		{
			List<string> inviteeList = new List<string>();

			inviteeList.Add("sip:alex.agudelo@accenture.com");



			// Create a generic Dictionary object to contain
			// conversation setting objects.
			Dictionary<AutomationModalitySettings, object> modalitySettings = new
				Dictionary<AutomationModalitySettings, object>();
			AutomationModalities chosenMode = AutomationModalities.InstantMessage;
			string firstIMMessageText = textBox2.Text;

			IAsyncResult ar = automation.BeginStartConversation(
		  chosenMode
		  , inviteeList
		  , modalitySettings
		  , null
		  , null);

			modalitySettings.Add(AutomationModalitySettings.FirstInstantMessage, firstIMMessageText);
			modalitySettings.Add(AutomationModalitySettings.SendFirstInstantMessageImmediately,
				true);
			IAsyncResult er = automation.BeginStartConversation(
		  chosenMode
		  , inviteeList
		  , modalitySettings
		  , null
		  , null);
		}

		private void EnviarMensajeAviso()
		{
			List<string> inviteeList = new List<string>();

			inviteeList.Add("sip:alex.agudelo@accenture.com");



			// Create a generic Dictionary object to contain
			// conversation setting objects.
			Dictionary<AutomationModalitySettings, object> modalitySettings = new
				Dictionary<AutomationModalitySettings, object>();
			AutomationModalities chosenMode = AutomationModalities.InstantMessage;
			string firstIMMessageText = "En 5 minutos se cerrara el chat";

			IAsyncResult ar = automation.BeginStartConversation(
		  chosenMode
		  , inviteeList
		  , modalitySettings
		  , null
		  , null);

			modalitySettings.Add(AutomationModalitySettings.FirstInstantMessage, firstIMMessageText);
			modalitySettings.Add(AutomationModalitySettings.SendFirstInstantMessageImmediately,
				true);
			IAsyncResult er = automation.BeginStartConversation(
		  chosenMode
		  , inviteeList
		  , modalitySettings
		  , null
		  , null);
		}


		private void button1_Click(object sender, EventArgs e)
		{

			List<string> inviteeList = new List<string>();

			inviteeList.Add("sip:david.penagos@accenture.com");

			inviteeList.Add("sip:alex.agudelo@accenture.com");
			inviteeList.Add("sip:cristhian.sanchez@accenture.com");



			// Create a generic Dictionary object to contain
			// conversation setting objects.
			Dictionary<AutomationModalitySettings, object> modalitySettings = new
				Dictionary<AutomationModalitySettings, object>();
			AutomationModalities chosenMode = AutomationModalities.InstantMessage;
			string firstIMMessageText = textBox1.Text;

			IAsyncResult ar = automation.BeginStartConversation(
		  chosenMode
		  , inviteeList
		  , modalitySettings
		  , null
		  , null);

			modalitySettings.Add(AutomationModalitySettings.FirstInstantMessage, firstIMMessageText);
			modalitySettings.Add(AutomationModalitySettings.SendFirstInstantMessageImmediately,
				true);
			IAsyncResult er = automation.BeginStartConversation(
		  chosenMode
		  , inviteeList
		  , modalitySettings
		  , null
		  , null);



		}


		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void Obtener()
		{
		    int hora1 = Convert.ToInt32(this.hora1.Text);
			int seg1= Convert.ToInt32(this.seg1.Text);
			int hora2 = Convert.ToInt32(this.hora2.Text);
			int seg2 = Convert.ToInt32(this.seg2.Text);

			if (seg1 == 0 && seg2 ==0) {
				hora1 = hora1 - 1;
				hora2 = hora2 - 1;
				seg1 = 58;
				seg2 = 58;

				TiempoAvizo1(new TimeSpan(hora1, seg1, 00));

			}

			SetUpTimer3(new TimeSpan(hora1, seg1, 00));

			TiempoAvizo1(new TimeSpan(10, 07, 00));

		}



		private void button2_Click(object sender, EventArgs e)
		{
			string[] arr1 = new string[] {"cristhian.sanchez@accenture.com","alex.agudelo@accenture.com", "manuela.restrepo@accenture.com" };

			for (int i = 0; i < 3; i++)
			{


				List<string> inviteeList = new List<string>();

				inviteeList.Add(arr1[i]);
				// Create a generic Dictionary object to contain
				// conversation setting objects.
				Dictionary<AutomationModalitySettings, object> modalitySettings = new
					Dictionary<AutomationModalitySettings, object>();
				AutomationModalities chosenMode = AutomationModalities.InstantMessage;
				string firstIMMessageText = textBox1.Text;

				IAsyncResult ap = automation.BeginStartConversation(
			  chosenMode
			  , inviteeList
			  , modalitySettings
			  , null
			  , null);

				modalitySettings.Add(AutomationModalitySettings.FirstInstantMessage, firstIMMessageText);
				modalitySettings.Add(AutomationModalitySettings.SendFirstInstantMessageImmediately,
					true);
				IAsyncResult ep = automation.BeginStartConversation(
			  chosenMode
			  , inviteeList
			  , modalitySettings
			  , null
			  , null);


			}




		}

		private void numericUpDown2_ValueChanged(object sender, EventArgs e)
		{

		}
	}
}
