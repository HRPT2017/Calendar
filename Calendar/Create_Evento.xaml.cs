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
    /// Lógica interna para Create_Evento.xaml
    /// </summary>
    /// 
   
    public partial class Create_Evento : Window
    {
        DataContext context = new DataContext();
        public Create_Evento()
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

                var competicoes = context.Competicao.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                lb_competicoes.ItemsSource = competicoes;
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

        //Handles the creation logic
        private void bt_evento_Click(object sender, RoutedEventArgs e)
        {
            if (cb_modalidade != null)
            {
                string aux = tb_nome_evento.Text.ToString();
                string result = aux.TrimStart();
                List<string> ev = context.Evento.Select(c => c.Nome).ToList();

                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;


                    List<int> selectedIds = lb_competicoes.SelectedItems.Cast<Competicao>().Select(entity => entity.Id).ToList();

                    if (!string.IsNullOrEmpty(result))
                    {
                        if (!ev.Contains(result))
                        {
                            if (dp_data.SelectedDate != null)
                            {
                                var evento = new Evento()
                                {
                                    Modalidade_Id = selectedModalidadeId,
                                    Nome = result,
                                    Data = (DateTime)dp_data.SelectedDate
                                };

                                context.Add(evento);
                                context.SaveChanges();
                                foreach (int selectedId in selectedIds)
                                {
                                    var jt = new JunctionTable()
                                    {
                                        Evento_Id = evento.Id,
                                        Competicao_Id = selectedId
                                    };

                                    context.JunctionTable.Add(jt);
                                }
                                context.SaveChanges();
                                cb_modalidade.SelectedItem = null;
                                tb_nome_evento.Text = null;
                                dp_data.Text = null;
                            }
                            else MessageBox.Show("Selecione uma Data");
                        }
                        else MessageBox.Show("Evento já existe");
                    }
                    else MessageBox.Show("Insira o nome de um Evento");

                }
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            Create_Evento eve = new Create_Evento();
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
