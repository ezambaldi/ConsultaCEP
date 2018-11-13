using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultaCEP.Servico.Modelo;
using ConsultaCEP.Servico;

namespace ConsultaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;



        }

        private void BuscarCEP(object sender, EventArgs args){

            //TODO - lógica do programa

            //TODO - validações


            // usar serviço viacep (busca e retorna dados para label)
            string cep = CEP.Text.Trim();

            // valida a digitação do cep
            if (isValidCEP(cep)){

                try {

                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);


                    if(end != null){

                        RESULTADO.Text = string.Format("Endereço: {0},{1},{2}", end.localidade, end.uf, end.logradouro);

                    }
                    else {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado: "+cep, "OK");
                    }



                }
                catch (Exception e){
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }








            } else {
                //TODO - mensagem
            }


        }


        private bool isValidCEP(string cep){

            bool valido = true;

            if(cep.Length != 8){
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caracteres", "OK");
                valido = false;
            }

            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP)){
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter apenas números", "OK");
                valido = false;
            }

            return valido;

        }


    }
}
