using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1_Cell.Modelo;

namespace App1_Cell.Pagina
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageCellPage : ContentPage
    {
        public ImageCellPage()
        {
            InitializeComponent();

            List<Funcionario> Lista = new List<Funcionario>();
            Lista.Add(new Funcionario() { Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTrVkb0f-gohH2sj45WFUBlNPFjqYP7vTL0_2Y2WYxNJdIjDkmn&usqp=CAU", Nome = "José", Cargo = "Presidente da Empresa" });
            Lista.Add(new Funcionario() { Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTIPudUe2XbmXgPcbUTMM2qvmZ5w3yWUtTytslQdo1ji0guPGJo&usqp=CAU", Nome = "Maria", Cargo = "Gerente de Vendas" });
            Lista.Add(new Funcionario() { Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTGAghtau-MJwGM6XL8UpwW5tVxF8gVPhs6f7uSmmV6vWaExGBI&usqp=CAU", Nome = "Elaine", Cargo = "Gerente de Marketing" });
            Lista.Add(new Funcionario() { Foto = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcR4iE-zYNBqa2GjHenokRMUJiirdukfnL0OvSBy-S3_rP4tCqY4&usqp=CAU", Nome = "Felipe", Cargo = "Entregador" });
            Lista.Add(new Funcionario() { Foto = "https://sapl.boavista.rr.leg.br/media/sapl/public/parlamentar/48/48_foto_parlamentar.jpeg.256x256_q85_box-0%2C22%2C301%2C324_crop_detail.jpg", Nome = "João", Cargo = "Vendedor" });

            ListaFuncionario.ItemsSource = Lista;
        }
    }
}