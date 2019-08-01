

namespace Organic.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using Models;
    using Services;
    using Xamarin.Forms;

    public class CatalogoViewModel:BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Vegetables> vegetable;
        #endregion

        #region Prperties
        public ObservableCollection<Vegetables> Vegetables
        {
            get { return this.vegetable; }
            set { SetValue(ref this.vegetable, value); }
        }
        #endregion

        #region Constructors
        public CatalogoViewModel()
        {
            this.LoadVegetables();
        }
        #endregion

        #region Methods
        private async void LoadVegetables()
        {
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                   "Error",
                   connection.Message,
                   "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<Vegetables>(
                "",
                "",
                "");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var list = (List<Vegetables>)response.Result;
            this.Vegetables = new ObservableCollection<Vegetables>(list);
        } 
        #endregion


    }
}
