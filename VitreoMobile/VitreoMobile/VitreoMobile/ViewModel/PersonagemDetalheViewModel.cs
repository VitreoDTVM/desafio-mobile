using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using VitreoMobile.Model;
using Xamarin.Forms;

namespace VitreoMobile.ViewModel
{
    public class PersonagemDetalheViewModel
    {
        public  Personagem Personagem { get; set; }

        public PersonagemDetalheViewModel(Personagem p)
        {
            this.Personagem = p;

        }
        //MessagingCenter.Send(Personagem, "IncluirPersonagem");

        //   MessagingCenter.Subscribe<Personagem>(this, "IncluirPersonagem",
        //(msg) =>
        //       {

        //    listView.ItemsSource = msg.HQs;

        //    listView.EndRefresh();

        //    OnPropertyChanged();
        //       });


    }
}
