using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using App1_NossoChat.Model;
using App1_NossoChat.Service;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class ChatsViewModel : INotifyPropertyChanged
    {
        private Chat _SelectedItemChat;
        public Chat SelectedItemChat
        {
            get { return _SelectedItemChat; }
            set
            {
                _SelectedItemChat = value;
                OnPropertyChanged("SelectedItemChat");
                GoPaginaMensagem(value);
            }
        }

        private void GoPaginaMensagem(Chat chat)
        {
            if (chat != null)
            {
                SelectedItemChat = null;
                ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.Mensagem(chat));
            }
        }


        private List<Chat> _chats;
        public List<Chat> Chats
        {
            get { return _chats; }
            set
            {
                _chats = value;
                OnPropertyChanged("Chats");
            }
        }

        public Command AdicionarCommand { get; set; }
        public Command OrdenarCommand { get; set; }
        public Command AtualizarCommand { get; set; }


        public ChatsViewModel()
        {
            Chats = ServiceWS.GetChats();

            AdicionarCommand = new Command(Adicionar);
            OrdenarCommand = new Command(Ordenar);
            AtualizarCommand = new Command(Atualizar);
        }

        private void Adicionar()
        {
            ((NavigationPage)App.Current.MainPage).Navigation.PushAsync(new View.CadastrarChat());
        }

        private void Ordenar()
        {
            Chats = Chats.OrderBy(a => a.nome).ToList();
        }

        private void Atualizar()
        {
            Chats = ServiceWS.GetChats();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
