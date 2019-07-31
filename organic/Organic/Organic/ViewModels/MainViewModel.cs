using System;
using System.Collections.Generic;
using System.Text;

namespace Organic.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public CatalogoViewModel Catalogo { get; set; }
        #endregion


        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null) 
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
