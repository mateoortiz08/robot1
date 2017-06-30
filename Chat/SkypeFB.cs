using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Conversation;
using Microsoft.Lync.Model.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class SkypeFB
    {
        LyncClient lyncClient;
        Automation automation;
        ContactManager contactMgr;
        List<SearchProviders> activeSearchProviders;
        ContactSubscription searchResultSubscription;
        Conversation conversation;
        InstantMessageModality imModality;

        public SkypeFB()
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

        public bool iniciarChat()
        {
            bool retorno = false;
            if (lyncClient!=null) {
                try
                {
                    List<string> inviteeList = new List<string>();

                    inviteeList.Add("sip:alex.agudelo@accenture.com");
                    inviteeList.Add("sip:cristhian.sanchez@accenture.com");
                    //inviteeList.Add("manuela.restrepo@accenture.com");


                    conversation = lyncClient.ConversationManager.AddConversation();
                    conversation.AddParticipant(lyncClient.ContactManager.GetContactByUri("sip:mateo.ortiz@accenture.com"));
                    conversation.AddParticipant(lyncClient.ContactManager.GetContactByUri("sip:cristhian.sanchez@accenture.com"));

                    imModality = conversation.Modalities[ModalityTypes.InstantMessage] as InstantMessageModality;
                    //string message = "Funciono"; //use your existing notification logic here
                    //imModality.BeginSendMessage(message, null, null);  

                    retorno = true;
                }catch(Exception e)
                {
                    retorno = false;
                }
            }
            else
            {
                retorno = false;
            }
            return retorno;
        }

        public bool enviarMensaje(String mensaje)
        {
            bool retorno = false;
            try
            {
                imModality.BeginSendMessage(mensaje, null, null);
                retorno = true;
            }catch(Exception e)
            {
                retorno = false;
            }

            return retorno;
        }

        public void terminarChat()
        {
            try
            {
                conversation.End();
            }catch(Exception e)
            {

            }
            
        }
    }
}
