using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Controls;
using Fig.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Fig.WPFapp.Viewmodel
{
    public class MainViewModel : ViewModelBase
    {


        private Figuur CurrentFiguur;
        private RelayCommand _vierkantCommand;
        private RelayCommand _cirkelCommand;
        private RelayCommand _driehoekCommand;
        private RelayCommand _berekenAlles;


        private string _dim1Label;
        private string _dim2Label;
        private string _dim1TextboxValue;
        private string _dim2TextboxValue;

        private string _oppervlakte;
        private string _omtrek;
        private string _langezijde;
        private string _messageField;

        public RelayCommand VierkantCommand => _vierkantCommand ??= new RelayCommand(CalculateVierkant);

        public RelayCommand CirkelCommand => _cirkelCommand ??= new RelayCommand(CalculateCirkel);

        public RelayCommand DriehoekCommand => _driehoekCommand ??= new RelayCommand(CalculateDriehoek);

        public RelayCommand BerekenAlles => _berekenAlles ??= new RelayCommand(Berekenen);

        private void Berekenen()
        {
            if (CurrentFiguur is null)
            {
                MessageField = $"Selecteer een figuur";
            }
            else
            {
                if (double.TryParse(Dim1TextBoxValue, out double dim1))
                {
                    CurrentFiguur.dim1 = dim1;

                    if (CurrentFiguur is Driehoek)
                    {
                        if (double.TryParse(Dim2TextBoxValue, out double dim2))
                        {
                            ((Driehoek)CurrentFiguur).dim2 = dim2;
                            LangeZijde = Math.Round(((Driehoek)CurrentFiguur).BerekenLengteC(), 2).ToString();

                            Omtrek = Math.Round(CurrentFiguur.BerekenOmtrek(), 2).ToString();
                            Oppervlakte = Math.Round(CurrentFiguur.BerekenOppervlakte(), 2).ToString();
                        }
                        else
                        {
                            MessageField = $"Geen geldige waarde voor {Dim2Label}";

                        }

                    }
                    else
                    {
                        Omtrek = Math.Round(CurrentFiguur.BerekenOmtrek(), 2).ToString();
                        Oppervlakte = Math.Round(CurrentFiguur.BerekenOppervlakte(), 2).ToString();
                    }
                }
                else
                {
                    MessageField = $"Geen geldige waarde voor {Dim1Label}";
                }
            }
            

        }

        public string Dim1Label
        {
            get => _dim1Label;
            set
            {
                _dim1Label = value;
                RaisePropertyChanged();
            }
        }

        public string Dim2Label
        {
            get => _dim2Label;
            set
            {
                _dim2Label = value;
                RaisePropertyChanged();
            }
        }

        public string Dim1TextBoxValue
        {
            get => _dim1TextboxValue;
            set
            {
                _dim1TextboxValue = value;
                RaisePropertyChanged();
            }
        }
        public string Dim2TextBoxValue
        {
            get => _dim2TextboxValue;
            set
            {
                _dim2TextboxValue = value;
                RaisePropertyChanged();
            }
        }

        public string Oppervlakte
        {
            get => _oppervlakte;
            set
            {
                _oppervlakte = value;
                RaisePropertyChanged();
            }
        }

        public string Omtrek
        {
            get => _omtrek;
            set
            {
                _omtrek = value;
                RaisePropertyChanged();
            }
        }

        public string LangeZijde
        {
            get => _langezijde;
            set
            {
                _langezijde = value;
                RaisePropertyChanged();
            }
        }

        public string MessageField
        {
            get => _messageField;
            set
            {
                _messageField = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            Dim1Label = "Selecteer een figuur";
            Dim2Label = "Selecteer een figuur";
        }

        public void ClearForNewInput()
        {
            Dim2TextBoxValue = string.Empty;
            Dim1TextBoxValue = string.Empty;

            Oppervlakte = string.Empty;
            Omtrek = string.Empty;
            LangeZijde = string.Empty;

            MessageField = string.Empty;
        }

        public void CalculateVierkant()
        {
            Dim2Label = "Niet in gebruik";
            Dim1Label = "Zijde Vierkant: ";
            ClearForNewInput();

            CurrentFiguur = new Vierkant();
        }

        public void CalculateCirkel()
        {
            Dim1Label = "Straal: ";
            Dim2Label = "Niet in gebruik";
            ClearForNewInput();
            CurrentFiguur = new Cirkel();
        }

        public void CalculateDriehoek()
        {
            Dim1Label = "Lange zijde: ";
            Dim2Label = "Korte zijde: ";
            ClearForNewInput();
            CurrentFiguur = new Driehoek();
        }


    }
}
