using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XF.ControlesBasicosCorreto.ViewModel
{
    public class ControlesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnAlterarPropriedade([CallerMemberName] string propriedade = null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propriedade));
        }

        private bool ativo { get; set; }

        public bool Ativo
        {
            get { return ativo; }
            set
            {
                ativo = value;
                if (!ativo) Email = string.Empty;
            }
        }

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnAlterarPropriedade();
            }
        }
        public ICommand OnEnviar { get; set; }
        public ICommand OnConfiguracao { get; set; }

        public ControlesViewModel()
        {
            OnEnviar = new Command(Enviar);
            OnConfiguracao = new Command(IrConfiguracao);
        }

        

        public void Enviar()
        {
            if ((App.ControlesVM.Ativo) &&
                (!string.IsNullOrWhiteSpace(App.ControlesVM.Email)))
                App.Current.MainPage
                    .DisplayAlert("Atenção",
                    $"Email enviado para {App.ControlesVM.email}", "OK");
            else

                App.Current.MainPage.
                        DisplayAlert("Atenção", "Email não autorizado", "OK");
        }

        public void IrConfiguracao()
        {
            App.Current.MainPage.Navigation
                .PushAsync(new View.ConfigView() { BindingContext = App.ControlesVM });
        }
    }
}
