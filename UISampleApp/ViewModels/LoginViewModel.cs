using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UISampleApp.Helpers;
using UISampleApp.Models;
using UISampleApp.Services;
using UISampleApp.Views.Home;
using Xamarin.Forms;

namespace UISampleApp.ViewModels
{
    public class LoginViewModel: NotificationObject 
    {

        #region Propiedades
        private RestServiceConsumer proc;

        private Login userLogin;

        public Login UserLoguin
        {
            get { return userLogin; }
            set
            {
                userLogin = value;
                onPropertyChanged();
            }
        }
        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get { return _loginCommand; }
            set
            {
                _loginCommand = value;
                onPropertyChanged();
            }
        }

        private Boolean _rememberMe;

        public Boolean RememberMe
        {
            get { return _rememberMe; }
            set { _rememberMe = value;
                onPropertyChanged();
            }
        }


        #endregion


        #region Constructores
        public LoginViewModel()
        {
            this.UserLoguin = new Login();
            LoginCommand = new Command(LoginCommandExecute);
        }
        #endregion

        #region Metodos  y eventos
        public async void LoginCommandExecute()
        {

            /*Logueandome y obteniendo un token*/
            if (userLogin.password != string.Empty && userLogin.userName != string.Empty)
            {
                proc = new RestServiceConsumer();
                var controllerString = $"{Constantes.LOGINAUTH}{Constantes.LOGINAUTHUSERPAR}={userLogin.userName}&{Constantes.LOGINAUTHPASSPAR}={userLogin.password}";
                var response = await proc.Get<string>(Constantes.BASEURL, Constantes.LOGINPREFIX, controllerString);

                if (!response.IsSuccesFull)
                {
                    //Errores en la respuesta
                    if (response.Result == null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error!", "Credenciales incorrectas", "OK");
                        return;
                    }
                    //Manejo de otros errores
                    await Application.Current.MainPage.DisplayAlert("Error!", response.Message, "OK");
                    return;
                }

                Settings.SerializedToken = Convert.ToString(response.Result);
                Settings.IsRemembered = RememberMe;
                //Navegacion a la pagina Root bloqueando el regreso al Login
                Application.Current.MainPage = new RootHomePage();

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error!", "Todos los datos son obligatorios", "OK");
            }

        }
        #endregion

    }
}
