﻿using Calendar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Calendar
{
    /// <summary>
    /// Lógica interna para Delete_Competicao.xaml
    /// </summary>
    public partial class Delete_Competicao : Window
    {
        DataContext context = new DataContext();
        public Delete_Competicao()
        {
            InitializeComponent();
            LoadModalidade();
        }

        private void bt_return_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            MainWindow MainWindow = new MainWindow();
            MainWindow.Top = mainWindowTop;
            MainWindow.Left = mainWindowLeft;
            MainWindow.Width = mainWindowWidth;
            MainWindow.Height = mainWindowHeight;
            MainWindow.WindowState = mainWindowState;
            MainWindow.Show();
            Close();

        }
        public void LoadModalidade()
        {
            List<Modalidade> nome = context.Modalidade.ToList();
            cb_modalidade.ItemsSource = nome;
            cb_modalidade.DisplayMemberPath = "Nome";


        }

        private void cb_modalidade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_modalidade.SelectedItem != null)
            {


                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;

                var eventos = context.Evento.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                lb_eventos.ItemsSource = eventos;

                var competicoes = context.Competicao.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                cb_competicao.ItemsSource = competicoes;
                cb_competicao.DisplayMemberPath = "Nome";

                
            }

        }


        private void cb_evento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_competicao.SelectedItem != null)
            {
                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;

                Competicao selectedCompeticao = (Competicao)cb_competicao.SelectedItem;
                int selectedCompeticaoId = selectedCompeticao.Id;



                List<int> comp = context.JunctionTable.Select(c => c.Evento_Id).ToList();

                if (comp.Contains(selectedCompeticaoId))
                {
                    var result = from e1 in context.Competicao
                                 join junction in context.JunctionTable on e1.Id equals junction.Competicao_Id
                                 join e2 in context.Evento on junction.Evento_Id equals e2.Id
                                 where e1.Id == selectedCompeticaoId
                                 select e2;

                    lb_eventos.ItemsSource = result.ToList();



                }
                else
                {
                    lb_eventos.ItemsSource = null;
                }

            }
        }

        private void bt_delete_Click(object sender, RoutedEventArgs e)
        {
            if (cb_modalidade != null)
            {
                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;

                Competicao selectedCompeticao = (Competicao)cb_competicao.SelectedItem;
                int selectedCompeticaoId = selectedCompeticao.Id;

                var selectedIds = context.JunctionTable.Where(c => c.Competicao_Id == selectedCompeticaoId).ToList();

                if (selectedIds.Any())
                {
                    context.JunctionTable.RemoveRange(selectedIds);
                    context.SaveChanges();
                }

                if (cb_competicao.SelectedItem != null)
                {
                    var competicao = context.Competicao.Find(selectedCompeticaoId);

                    context.Competicao.Remove(competicao);
                    context.SaveChanges();
                    context.Entry(competicao).State = EntityState.Detached;
                }
            }
            else MessageBox.Show("Seleciona uma modalidade");

            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;
      
            Delete_Competicao eve = new Delete_Competicao();
            eve.Left = mainWindowLeft;
            eve.Top = mainWindowTop;
            eve.Width = mainWindowWidth;
            eve.Height = mainWindowHeight;
            eve.WindowState = mainWindowState;
            eve.Show();
            Close();
        }
    }
}
