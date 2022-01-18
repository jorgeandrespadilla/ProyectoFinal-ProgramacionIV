﻿using ProyectoFinal.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoFinal.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsSubasta : ContentPage
    {
        public DetailsSubasta()
        {
            InitializeComponent();
            BindingContext = new DetailsSubastaViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((DetailsSubastaViewModel)BindingContext).Initialize();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ((DetailsSubastaViewModel)BindingContext).Dispose();
        }
    }
}