using Calendar.Models;
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
    /// Lógica interna para Delete_Evento.xaml
    /// </summary>
    public partial class Delete_Evento : Window
    {
        DataContext context = new DataContext();
        public Delete_Evento()
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

                var competicoes = context.Competicao.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                lb_competicoes.ItemsSource = competicoes;

                var eventos = context.Evento.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                cb_evento.ItemsSource = eventos;
                cb_evento.DisplayMemberPath = "Nome";

                tb_data.Text = null;
            }

        }


        private void cb_evento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_evento.SelectedItem != null)
            {
                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;

                Evento selectedEvento = (Evento)cb_evento.SelectedItem;
                int selectedEventoId = selectedEvento.Id;


                Evento eventos = context.Evento.FirstOrDefault(c => c.Id == selectedEventoId);


                tb_data.Text = eventos.Data.ToString();

                List<int> comp = context.JunctionTable.Select(c => c.Evento_Id).ToList();

                if (comp.Contains(selectedEventoId))
                {
                    var result = from e1 in context.Evento
                                 join junction in context.JunctionTable on e1.Id equals junction.Evento_Id
                                 join e2 in context.Competicao on junction.Competicao_Id equals e2.Id
                                 where e1.Id == selectedEventoId
                                 select e2;

                    lb_competicoes.ItemsSource = result.ToList();



                }
                else
                {
                    lb_competicoes.ItemsSource = null;
                }

            }
        }

        private void bt_delete_Click(object sender, RoutedEventArgs e)
        {
            if (cb_modalidade != null)
            {
                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;

                Evento selectedEvento = (Evento)cb_evento.SelectedItem;
                int selectedEventoId = selectedEvento.Id;

                var selectedIds = context.JunctionTable.Where(c => c.Evento_Id == selectedEventoId).ToList();

                if (selectedIds.Any())
                {
                    context.JunctionTable.RemoveRange(selectedIds);
                    context.SaveChanges();
                }

                if (cb_evento.SelectedItem != null)
                {
                    var evento = context.Evento.Find(selectedEventoId);

                    context.Evento.Remove(evento);
                    context.SaveChanges();
                    context.Entry(evento).State = EntityState.Detached;
                }
            }
            else MessageBox.Show("Seleciona uma modalidade");


            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            Delete_Evento eve = new Delete_Evento();
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
