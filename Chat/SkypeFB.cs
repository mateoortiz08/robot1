﻿using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Conversation;
using Microsoft.Lync.Model.Extensibility;
using Microsoft.Lync.Model.Group;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chat
{
    /*
     *  Esta clase se encarga de conectarse con skype for business, y tiene las funciones de 
     *  iniciar el chat, enviar un mensaje al chat y finalizar el chat
     *  
     * */
    class SkypeFB
    {
        LyncClient lyncClient;
        Automation automation;
        ContactManager contactMgr;
        List<SearchProviders> activeSearchProviders;
        ContactSubscription searchResultSubscription;
        Conversation conversation;
        InstantMessageModality imModality;
        String mensajes = "";
        List<String> msg;
        bool eliminar = true;

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


            msg = new List<String>();

        }

        /*
         * Retorna True si se puede iniciar el chat, de lo contrario false
         * */
        public bool iniciarChat()
        {
            bool retorno = false;
            if (lyncClient != null) {
                try
                {
                    eliminar = false;
                    //Obtener lista de invitados
                    List<string> inviteeList = new List<string>();
                    List<String> gruposList;
                    Datos datos = new Datos("C:\\Users\\Administrator\\Desktop\\datos.xlsx");
                    inviteeList = datos.getUsuarios();
                    gruposList = datos.getGrupos();
                    //Se crea la conversación
                    conversation = lyncClient.ConversationManager.AddConversation();

                    conversation.ParticipantAdded += ParticipantAdded;

                    //Se añaden los contactos a la conversación
                    inviteeList.ForEach(delegate (String usuario)
                    {
                        conversation.AddParticipant(lyncClient.ContactManager.GetContactByUri("sip:" + usuario));
                        ///conversation.RemoveParticipant(conversation.)
                    });
                    //conversation.AddParticipant(lyncClient.ContactManager.GetContactByUri("sip:david.penagos@accenture.com"));
                    //conversation.AddParticipant(lyncClient.ContactManager.BeginAddGroup("sip:404",null,null));


                    GroupCollection grupos = lyncClient.ContactManager.Groups;
                    gruposList.ForEach(delegate (String strGrupo)
                    {
                        for (int i = 0; i < grupos.Count; i++)
                        {
                            Console.WriteLine(grupos[i].Name);
                            if (grupos[i].Name.Equals(strGrupo))
                            {
                                for (int j = 0; j < grupos[i].Count; j++)
                                {
                                    String contacto = grupos[i].ElementAt(j).Uri;
                                    conversation.AddParticipant(lyncClient.ContactManager.GetContactByUri(contacto));
                                }
                            }
                        }
                    });


                    //Objeto encargado de enviar los mensajes
                    imModality = conversation.Modalities[ModalityTypes.InstantMessage] as InstantMessageModality;
                    // imModality.InstantMessageReceived += InstantMessageReceived;

                    retorno = true;

                } catch (Exception e)
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

        /*
         * Retorna true si el mensaje es enviado con exito, de lo contrario false
         * */
        public bool enviarMensaje(String mensaje)
        {
            bool retorno = false;
            try
            {
                //Enviar el mensaje
                imModality.BeginSendMessage(mensaje, null, null);
                retorno = true;

            } catch (Exception e)
            {
                retorno = false;
            }

            return retorno;
        }

        public void terminarChat()
        {
            for (int i = 1; i < conversation.Participants.Count; i++)
            {

                conversation.RemoveParticipant(conversation.Participants.ElementAt(i));

            }

            conversation.BeginSetProperty(
             ConversationProperty.ConferencingLocked,
             true, (ar) =>
             {
                 conversation.EndSetProperty(ar);
             },
             null);


            Thread.Sleep(5000);

            conversation.End();

            Datos.guardar(msg);



        }


        private void InstantMessageReceived(object sender, MessageSentEventArgs e)
        {
            string user = (string)((InstantMessageModality)sender).Participant.Contact.GetContactInformation(ContactInformationType.DisplayName);
            //Console.WriteLine(user);
            //Console.WriteLine(e.Text);

            mensajes = user + " : " + e.Text + "\n";
            msg.Add(mensajes);

        }

        private void ParticipantAdded(object sender, ParticipantCollectionChangedEventArgs e)
        {


            var instantMessageModality =
                e.Participant.Modalities[ModalityTypes.InstantMessage] as InstantMessageModality;
            instantMessageModality.InstantMessageReceived += InstantMessageReceived;

            if (eliminar)
            {
                eliminarContactos();
            }
        }

        public String getMensajes()
        {
            return mensajes;
        }

        public void eliminarContactos()
        {
            for (int i = 1; i < conversation.Participants.Count; i++)
            {

                conversation.RemoveParticipant(conversation.Participants.ElementAt(i));

            }
        }
        
    }
}
