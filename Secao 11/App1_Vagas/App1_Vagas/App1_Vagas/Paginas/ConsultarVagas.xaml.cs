using App1_Vagas.Banco;
using App1_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultarVagas : ContentPage
    {
        List<Vaga> Lista { get; set; }

        public ConsultarVagas()
        {
            InitializeComponent();

            Database database = new Database();
            Lista = database.Consultar();
            ListaVagas.ItemsSource = Lista;

            LblCount.Text = Lista.Count.ToString();
        }

        private void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastrarVaga());
        }

        private void GoMinhasVagas(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MinhasVagasCadastradas());
        }

        private void MaisDetalheAction(object sender, EventArgs args)
        {
            Label lblDetalhe = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lblDetalhe.GestureRecognizers[0];
            Vaga vaga = (Vaga)tapGest.CommandParameter;

            Navigation.PushAsync(new DetalharVaga(vaga));
        }

        private void PesquisarAction(object sender, TextChangedEventArgs args)
        {
            ListaVagas.ItemsSource = Lista.Where(a => a.NomeVaga.Contains(args.NewTextValue));
        }
    }
}