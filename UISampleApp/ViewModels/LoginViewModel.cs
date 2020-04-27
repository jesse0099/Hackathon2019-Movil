using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UISampleApp.Models;
using UISampleApp.Services;
using UISampleApp.Views.Home;
using Xamarin.Forms;

namespace UISampleApp.ViewModels
{
    public class LoginViewModel: NotificationObject 
    {
        private RestServiceConsumer proc;

        private Login userLogin;

        public Login UserLoguin
        {
            get { return userLogin; }
            set { userLogin = value;
                onPropertyChanged();
            }
        }



        private ICommand _loginCommand;

        public ICommand LoginCommand
        {
            get { return _loginCommand; }
            set { _loginCommand = value;
                onPropertyChanged();
            }
        }




        public LoginViewModel() {
            this.UserLoguin = new Login();
            LoginCommand = new Command(LoginCommandExecute);
        }

        public async void LoginCommandExecute()
        {

            /*Logueandome y obteniendo un token*/
            if (userLogin.password != string.Empty && userLogin.userName != string.Empty)
            {
                proc = new RestServiceConsumer();
                var response = await proc.PostToken("https://eecommerapi.conveyor.cloud/api/login/authenticateclient", new LoginClientRequest()
                {
                    Password = userLogin.password
                ,
                    User = userLogin.userName
                }, typeof(LoginClientRequest));

                /*Informacion del perfil del cliente,de momento no hago nada con eso*/
                //ClientProfileResponse profileResponse = await proc.GetAuth<ClientProfileResponse>(
                //    string.Format("https://eecommerapi.conveyor.cloud/api/clients/profileInfo?uniquename={0}", txtUser.Text), response);

                /*navegando a la pagina raiz*/
                if (response != string.Empty)
                    await Xamarin.Forms.Application.Current.MainPage.Navigation.PushModalAsync(new RootHomePage());
                else
                    await Application.Current.MainPage.DisplayAlert("Error!", "Credenciales incorrectas", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error!", "Todos los datos son obligatorios", "OK");
            }

        }
    }
}
