﻿using MarketPlaceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MarketPlaceGrif.Pages
{
    /// <summary>
    /// Логика взаимодействия для MessagePage.xaml
    /// </summary>
    public partial class MessagePage : Page
    {
        Entities _context = new Entities();
        StateMessage selMessage;
        public MessagePage()
        {
            InitializeComponent();
            selMessage = null;
            Refresh();
        }


        private void Refresh()
        {
            List<Message> listMessages = _context.Message.ToList();
            if (selMessage != null)
            {
                listMessages = listMessages.Where(x => x.StateMessageId == selMessage.Id).ToList();
            }
            if (CbSort.SelectedItem != null)
            {
                switch ((CbSort.SelectedItem as ComboBoxItem).Tag)
                {
                    case "1":

                        listMessages = _context.Message.ToList();
                        break;
                    case "2":

                        listMessages = listMessages.OrderBy(x => x.Name).ToList();
                        break;
                    case "3":

                        listMessages = listMessages.OrderByDescending(x => x.Name).ToList();

                        break;
                    case "4":

                        listMessages = listMessages.OrderBy(x => x.DateMessage).ToList();
                        break;
                    case "5":
                            
                        listMessages = listMessages.OrderByDescending(x => x.DateMessage).ToList();
                        break;

                }

            }
            var searchString = SearchTb.Text;
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                listMessages = listMessages.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }

            HistoryList.ItemsSource = listMessages;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            selMessage = App.db.StateMessage.FirstOrDefault(x => x.Id == 1);
            Refresh();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            selMessage = App.db.StateMessage.FirstOrDefault(x => x.Id == 2);
            Refresh();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selMess = (sender as Button).DataContext as Message;
            MessageEditWindow shipmentEditWindow = new MessageEditWindow(selMess);
            shipmentEditWindow.ShowDialog();
        }

        

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                App.db.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                HistoryList.ItemsSource = App.db.Message.ToList();
            }
        }
    }
}
