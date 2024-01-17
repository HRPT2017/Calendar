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
    public partial class Delete_Competicao : Window
    {
        DataContext context = new DataContext();
        public Delete_Competicao()
        {
            InitializeComponent();
            LoadModalidade();
        }
        //Returns to main window
        private void bt_return_Click(object sender, RoutedEventArgs e)
        {
            // Gets the position of the open window
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            // Gets the size of the open window
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            // Gets the state(Maximized,Minimized) of the open window
            WindowState mainWindowState = WindowState;

            MainWindow MainWindow = new MainWindow();
            //Apply the previous values to the new window
            MainWindow.Top = mainWindowTop;
            MainWindow.Left = mainWindowLeft;
            MainWindow.Width = mainWindowWidth;
            MainWindow.Height = mainWindowHeight;
            MainWindow.WindowState = mainWindowState;
            MainWindow.Show();
            Close();

        }
        //Load the values from the databse into the Combobox
        public void LoadModalidade()
        {
            List<Modalidade> nome = context.Modalidade.ToList();
            cb_modalidade.ItemsSource = nome;
            cb_modalidade.DisplayMemberPath = "Nome";
        }

        //Handles what happens when the selected item in the combobox changes
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

        //Handles what happens when the selected item in the combobox changes
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

        //Handles the delete logic
        private void bt_delete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Confirm Deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);

            // Process the user's response
            if (result == MessageBoxResult.Yes)
            {
                // User clicked Yes, perform deletion logic
                DeleteItem();
            }
            else
            {
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
        public void DeleteItem() 
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
