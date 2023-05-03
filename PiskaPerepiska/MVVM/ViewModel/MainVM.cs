﻿using PiskaPerepiska.MVVM.Model;
using PiskaPerepiska.MVVM.View;
using PiskaPerepiska.View;
using PiskaPerepiska.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PiskaPerepiska
{
    internal class MainVM : BindingsHelper
    {
        #region Комманды
        public BindableCommand OpenUserUICommand { get; set; }
        public BindableCommand OpenHostUICommand { get; set; }
        #endregion

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged();
            }
        }

        public MainVM() 
        {
            OpenUserUICommand = new BindableCommand(_ => OpenUserUI(), o => !string.IsNullOrEmpty(Username));
            OpenHostUICommand = new BindableCommand(_ => OpenHostUI());
        }

        public void OpenUserUI()
        {
            new Chat(username).Show();
            //Application.Current.MainWindow.Close(); // Закрывает окно выбора
        }

        public void OpenHostUI()
        {
            new HostWindow().Show();
        }
    }
}
