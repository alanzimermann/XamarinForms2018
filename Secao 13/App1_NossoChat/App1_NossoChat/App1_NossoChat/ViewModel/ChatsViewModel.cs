using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1_NossoChat.Model;
using App1_NossoChat.Service;
using Xamarin.Forms;

namespace App1_NossoChat.ViewModel
{
    public class ChatsViewModel : INotifyPropertyChanged
    {
        private bool _mensagemErro;
        public bool MensagemErro
        {
            get { return _mensagemErro; }
            set
            {
                _mensagemErro = value;
                OnPropertyChanged("MensagemErro");
            }
        }

        private bool _carregando;
        public bool Carregando
        {
            get { return _carregando; }
            set
            {
                _carregando = value;
                OnPropertyChanged("Carregando");
            }
        }

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
            Task.Run(() => CarregarChats());

            AdicionarCommand = new Command(Adicionar);
            OrdenarCommand = new Command(Ordenar);
            AtualizarCommand = new Command(Atualizar);
        }

        private async Task CarregarChats()
        {
            try
            {
                MensagemErro = false;
                Carregando = true;
                Chats = await ServiceWS.GetChats();
                Carregando = false;
            }
            catch (Exception e)
            {
                Carregando = false;
                MensagemErro = true;                
            }
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
            Task.Run(() => CarregarChats());
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
