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
    public partial class Edit_Competicao : Window
    {
        DataContext context = new DataContext();
        public Edit_Competicao()
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
                lb_eventos_edit.ItemsSource = eventos;

                var competicoes = context.Competicao.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                cb_edit_competicao.ItemsSource = competicoes;
                cb_edit_competicao.DisplayMemberPath = "Nome";

                tb_edit_competicao.Text = null;
                lb_evento_edit.ItemsSource = null;
              


            }

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
        private void bt_edit_competicao_Click(object sender, RoutedEventArgs e)
        {
            if (cb_modalidade != null)
            {
                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;

                Competicao selectedCompeticao = (Competicao)cb_edit_competicao.SelectedItem;
                int selectedCompeticaoId = selectedCompeticao.Id;

                string aux = tb_edit_competicao.Text.ToString();
                string result = aux.TrimStart();
                List<string> ev = context.Competicao.Select(c => c.Nome).ToList();
                if (!string.IsNullOrEmpty(aux))
                {

                    Competicao eventos = context.Competicao.FirstOrDefault(c => c.Id == selectedCompeticaoId);

                    eventos.Nome = result;

                    context.Update(eventos);
                    context.SaveChanges();

                }
                else MessageBox.Show("Escreva um nome de um evento");


                if (lb_eventos_edit.ItemsSource != null)
                {
                    List<int> selectedIds = lb_eventos_edit.SelectedItems.Cast<Evento>().Select(entity => entity.Id).ToList();

                    foreach (int selectedId in selectedIds)
                    {
                        var jt = new JunctionTable()
                        {
                            Evento_Id = selectedId,
                            Competicao_Id = selectedCompeticaoId
                        };

                        context.JunctionTable.Remove(jt);
                        context.SaveChanges();
                        context.Entry(jt).State = EntityState.Detached;
                    }


                }

                if (lb_evento_edit.SelectedItem != null)
                {
                    List<int> selectedIds = lb_evento_edit.SelectedItems.Cast<Evento>().Select(entity => entity.Id).ToList();

                    foreach (int selectedId in selectedIds)
                    {
                        var jt = new JunctionTable()
                        {
                            Evento_Id = selectedId,
                            Competicao_Id = selectedCompeticaoId
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

            Edit_Competicao eve = new Edit_Competicao();
            eve.Left = mainWindowLeft;
            eve.Top = mainWindowTop;
            eve.Width = mainWindowWidth;
            eve.Height = mainWindowHeight;
            eve.WindowState = mainWindowState;
            eve.Show();
            Close();
        }

        private void cb_edit_competicao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_edit_competicao.SelectedValue != null)
            {
                Competicao selectedCompeticao = (Competicao)cb_edit_competicao.SelectedItem;
                int selectedCompeticaoId = selectedCompeticao.Id;

                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;


                Competicao comp = context.Competicao.FirstOrDefault(c => c.Id == selectedCompeticaoId);

                tb_edit_competicao.Text = comp.Nome;


                List<int> ev = context.JunctionTable.Select(c => c.Competicao_Id).ToList();

                if (ev.Contains(selectedCompeticaoId))
                {
                    var result = from e1 in context.Competicao
                                 join junction in context.JunctionTable on e1.Id equals junction.Competicao_Id
                                 join e2 in context.Evento on junction.Evento_Id equals e2.Id
                                 where e1.Id == selectedCompeticaoId
                                 select e2;

                    lb_eventos_edit.ItemsSource = result.ToList();

                    var remainingEventos = context.Evento.Where(c => c.Modalidade_Id == selectedModalidadeId).Except(result);

                    // Display the remaining items in another ListBox (lb_remaining_competicoes)
                    lb_evento_edit.ItemsSource = remainingEventos.ToList();
                }
                else
                {
                    lb_eventos_edit.ItemsSource = null;
                    var eventos = context.Evento.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                    lb_evento_edit.ItemsSource = eventos;
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                lb_eventos_edit.Margin = new Thickness(266, 42, 228, 480);
                l_evento_edit.Margin = new Thickness(266, 370, 0, 0);
                lb_evento_edit.Margin = new Thickness(266, 400, 228, 45);

            }
            else
            {
                lb_eventos_edit.Margin = new Thickness(266, 42, 228, 241);
                l_evento_edit.Margin = new Thickness(266, 196, 0, 0);
                lb_evento_edit.Margin = new Thickness(266, 222, 228, 45);
            }
        }
    }
}
