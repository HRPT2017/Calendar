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
    /// <summary>
    /// Lógica interna para Edit_Evento.xaml
    /// </summary>
    public partial class Edit_Evento : Window
    {
        DataContext context = new DataContext();
        public Edit_Evento()
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

                var competicoes = context.Competicao.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                lb_competicoes.ItemsSource = competicoes;

                var eventos = context.Evento.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                cb_edit_evento.ItemsSource = eventos;
                cb_edit_evento.DisplayMemberPath = "Nome";

                tb_edit_evento.Text = null;
                dp_data_edit.Text = null;
                lb_competicoes_edit.ItemsSource = null;
            }

        }

        //Handles the logic behind the edit
        private void bt_edit_evento_Click(object sender, RoutedEventArgs e)
        {
            if (cb_modalidade != null)
            {
                // Gets the Id from the selected Modalidade
                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;

                // Gets the Id from the selected Evento
                Evento selectedEvento = (Evento)cb_edit_evento.SelectedItem;
                int selectedEventoId = selectedEvento.Id;

                string aux = tb_edit_evento.Text.ToString();
                //Starts reading after the first character
                string result = aux.TrimStart();
                List<string> ev = context.Evento.Select(c => c.Nome).ToList();
                
                //Checks if Nome is not null
                if (!string.IsNullOrEmpty(aux))
                {
                    //check if the Data is not null
                    if (dp_data_edit.SelectedDate != null || dp_data_edit.Text != null)
                    {
                        Evento eventos = context.Evento.FirstOrDefault(c => c.Id == selectedEventoId);

                        eventos.Nome = result;
                        eventos.Data = (DateTime)dp_data_edit.SelectedDate;

                        context.Update(eventos);
                        context.SaveChanges();
                    }
                    else MessageBox.Show("Selecione uma data");

                }
                else MessageBox.Show("Escreva um nome de um evento");
                //Remove the selected items and the evento from the junction table
                if (lb_competicoes.ItemsSource != null)
                {
                    List<int> selectedIds = lb_competicoes.SelectedItems.Cast<Competicao>().Select(entity => entity.Id).ToList();

                    foreach (int selectedId in selectedIds)
                    {
                        var jt = new JunctionTable()
                        {
                            Evento_Id = selectedEventoId,
                            Competicao_Id = selectedId
                        };

                        context.JunctionTable.Remove(jt);
                        context.SaveChanges();
                        context.Entry(jt).State = EntityState.Detached;
                    }

                }
                //Add the selected items and the evento to the junction table
                if (lb_competicoes_edit.SelectedItem != null)
                {
                    List<int> selectedIds = lb_competicoes_edit.SelectedItems.Cast<Competicao>().Select(entity => entity.Id).ToList();

                    foreach (int selectedId in selectedIds)
                    {
                        var jt = new JunctionTable()
                        {
                            Evento_Id = selectedEventoId,
                            Competicao_Id = selectedId
                        };

                        context.JunctionTable.Add(jt);

                        context.SaveChanges();
                        context.Entry(jt).State = EntityState.Detached;
                    }


                }

            }
            else MessageBox.Show("Seleciona uma modalidade");

            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            Edit_Evento eve = new Edit_Evento();
            eve.Left = mainWindowLeft;
            eve.Top = mainWindowTop;
            eve.Width = mainWindowWidth;
            eve.Height = mainWindowHeight;
            eve.WindowState = mainWindowState;
            eve.Show();
            Close();

        }

        private void cb_edit_evento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_edit_evento.SelectedValue != null)
            {
                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;

                Evento selectedEvento = (Evento)cb_edit_evento.SelectedItem;
                int selectedEventoId = selectedEvento.Id;


                Evento eventos = context.Evento.FirstOrDefault(c => c.Id == selectedEventoId);

                tb_edit_evento.Text = eventos.Nome;

                dp_data_edit.Text = eventos.Data.ToString();

                List<int> comp = context.JunctionTable.Select(c => c.Evento_Id).ToList();

                //Gets the Competicao data through the junction table using the Evento Id
                if (comp.Contains(selectedEventoId))
                {
                    var result = from e1 in context.Evento
                                 join junction in context.JunctionTable on e1.Id equals junction.Evento_Id
                                 join e2 in context.Competicao on junction.Competicao_Id equals e2.Id
                                 where e1.Id == selectedEventoId
                                 select e2;

                    lb_competicoes.ItemsSource = result.ToList();


                    var remainingCompeticoes = context.Competicao.Where(c => c.Modalidade_Id == selectedModalidadeId).Except(result);

                    // Display the remaining items in another ListBox (lb_remaining_competicoes)
                    lb_competicoes_edit.ItemsSource = remainingCompeticoes.ToList();
                }
                else
                {
                    lb_competicoes.ItemsSource = null;
                    var ev = context.Competicao.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                    lb_competicoes_edit.ItemsSource = ev; ;
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(WindowState == WindowState.Maximized)
            {
                lb_competicoes.Margin = new Thickness(266, 42, 228, 480);
                l_competicoes_edit.Margin = new Thickness(266,370,0,0);
                lb_competicoes_edit.Margin = new Thickness(266, 400, 228, 45);

            }
            else 
            {
                lb_competicoes.Margin = new Thickness(266, 42, 228, 241);
                l_competicoes_edit.Margin = new Thickness(266, 196, 0, 0);
                lb_competicoes_edit.Margin = new Thickness(266, 222, 228, 45);
            }
        }
    }
}
