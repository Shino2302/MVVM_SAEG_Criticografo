using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MVVM_SAEG_Criticografo.ViewModel
{
    public class VMMainPage : BaseViewModel
    {
        #region VARIABLES
        private string _resultado;
        private string _nombre;
        private bool _alto;
        private bool _raro;
        private bool _grande;
        private bool _extravagante;
        private bool _listo;
        private bool _feo;
        private bool _genero = true;
        protected int contador = 0;
        public string[] arrayDeCriticas = {"Alt","List","Rar","Fe","Extravagante","Grande"}; 
        #endregion
       
        #region CONSTRUCTOR
        public VMMainPage(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJECTS
        public string Resultado
        {
            get { return _resultado; }
            set { SetValue(ref _resultado, value); }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { SetValue(ref _nombre, value); }
        }
        public bool Alto
        {
            get { return _alto; }
            set { SetValue(ref _alto, value);}
        }
        public bool Grande
        {
            get { return _grande; }
            set { SetValue(ref _grande, value); }
        }
        public bool Genero
        {
            get { return _genero; }
            set { SetValue(ref _genero, value); }
        }

        public bool Raro
        {
            get { return _raro; }
            set { SetValue(ref _raro, value); }
        }

        public bool Extravagante
        {
            get { return _extravagante; }
            set { SetValue(ref _extravagante, value); }
        }

        public bool Listo
        {
            get { return _listo; }
            set { SetValue(ref _listo, value); }
        }

        public bool Feo
        {
            get { return _feo; }
            set { SetValue(ref _feo, value); }
        }
        #endregion

        #region PROCESS
        public void SeleccionPorGenero()
        {
            string[] reiniciarArray = arrayDeCriticas;
            if (arrayDeCriticas[0].Count() > 3)
            {
                arrayDeCriticas = reiniciarArray;
                SeleccionPorGenero();
            }
            else if(Genero)
            {
                for(int i = 0; i < 4; i++)
                {
                    arrayDeCriticas[i].Concat("a");
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    arrayDeCriticas[i].Concat("o");
                }
            }
        }
        public string FormarCadenaDeResultado()
        {
            SeleccionPorGenero();
            contador = 0;
            string cadenaResultante = "";
            if (Alto)
            {
                cadenaResultante += arrayDeCriticas[0]+", ";
                contador++;
            }
            if(Listo)
            {
                cadenaResultante += arrayDeCriticas[1] + ", ";
                contador++;
            }
            if (Raro)
            {
                cadenaResultante += arrayDeCriticas[2] + ", ";
                contador++;
            }
            if (Feo)
            {
                cadenaResultante += arrayDeCriticas[3] + ", ";
                contador++;
            }
            if (Extravagante)
            {
                cadenaResultante += arrayDeCriticas[4] + ", ";
                contador++;
            }
            if(Grande)
            {
                cadenaResultante += arrayDeCriticas[5] + ", ";
                contador++;
            }
            return cadenaResultante;
        }
        public async Task Criticar()
        {
            Resultado = "";
            string cadena = FormarCadenaDeResultado();
            if(contador == 0)
            {
                await DisplayAlert("Ingresa Todos Los Datos", "Te Hace Falta Ingresar Más Datos", "OK");
            }
            else if(contador == 1)
            {
                Resultado = $"{Nombre} es: {cadena}.";
            }
            else
            {
                Resultado = "Holas";
            }
        }
        #endregion

        #region COMMADS
        public ICommand CriticarCommand => new Command(async () => await Criticar());
        #endregion
    }
}
