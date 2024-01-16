using Calendar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calendar.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;



namespace Calendar
{
    public partial class Create_Competicao : Window
    {
        DataContext context = new DataContext();
        public Create_Competicao()
        {
            

            InitializeComponent();

            LoadModalidade();
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
            }

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

        //Handles the create logic
        private void bt_competicao_create_Click(object sender, RoutedEventArgs e)
        {
            if (cb_modalidade != null)
            {
                string aux = tb_competicao.Text.ToString();
                string result = aux.TrimStart();
                List<string> ev = context.Competicao.Select(c => c.Nome).ToList();

                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;

                List<int> selectedIds = lb_eventos.SelectedItems.Cast<Evento>().Select(entity => entity.Id).ToList();

                if (!string.IsNullOrEmpty(result))
                {
                    if (!ev.Contains(result))
                    {

                        var evento = new Competicao()
                        {
                            Modalidade_Id = selectedModalidadeId,
                            Nome = result
                        };

                        context.Add(evento);
                        context.SaveChanges();
                        foreach (int selectedId in selectedIds)
                        {
                            var jt = new JunctionTable()
                            {
                                Evento_Id = selectedId,
                                Competicao_Id = evento.Id
                            };

                            context.JunctionTable.Add(jt);
                        }
                        context.SaveChanges();
                        cb_modalidade.SelectedItem = null;
                        tb_competicao.Text = null;
                        lb_eventos.ItemsSource = null;

                    }
                    else
                    {
                        MessageBox.Show("Competicao já existe");
                    }
                }
                else MessageBox.Show("Insira o nome de um Competicao");

            }
            else MessageBox.Show("Seleciona uma modalidade");
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            Create_Competicao eve = new Create_Competicao();
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
