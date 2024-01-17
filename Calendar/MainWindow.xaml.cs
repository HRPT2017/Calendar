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
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.Win32;

/*
 * Author: Hugo Teixeira
 */

namespace Calendar
{
    
    public partial class MainWindow : Window
    {
        DataContext context = new DataContext();

        public MainWindow()
        {
            InitializeComponent();

            LoadModalidade();

            LoadCompeticao();
        }

        public void LoadModalidade()
        {
            List<Modalidade> nome = context.Modalidade.ToList();
            cb_modalidade.ItemsSource = nome;
            cb_modalidade.DisplayMemberPath = "Nome";

        }

        public void LoadCompeticao()
        {
            List<Competicao> nome = context.Competicao.ToList();
            cb_competicao.ItemsSource = nome;
            cb_competicao.DisplayMemberPath = "Nome";

        }

        private void cb_modalidade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cb_modalidade.SelectedItem != null)
            {
                Modalidade selectedModalidade = (Modalidade)cb_modalidade.SelectedItem;
                int selectedModalidadeId = selectedModalidade.Id;

                var competicoes = context.Competicao.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                cb_competicao.ItemsSource = competicoes;
                cb_competicao.DisplayMemberPath = "Nome";


                var eventos = context.Evento.Where(c => c.Modalidade_Id == selectedModalidadeId).ToList();
                lb_eventos.ItemsSource = eventos;


            }

        }

        private void cb_competicao_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_competicao.SelectedItem != null)
            {
                Competicao selectedCompeticao = (Competicao)cb_competicao.SelectedItem;
                int selectedCompeticaoId = selectedCompeticao.Id;

                
                List<int> evento = context.JunctionTable.Select(c => c.Competicao_Id).ToList();


                if(evento.Contains(selectedCompeticaoId))
                {
                    var result = from e1 in context.Competicao
                                 join junction in context.JunctionTable on e1.Id equals junction.Competicao_Id
                                 join e2 in context.Evento on junction.Evento_Id equals e2.Id
                                 where e1.Id == selectedCompeticaoId
                                 select new
                                 { 
                                    Nome= e2.Nome,
                                     Data = e2.Data.ToString("dd/MM/yyyy")
                                 };

                    lb_eventos.ItemsSource = result.ToList();
                }
                else 
                {
                    lb_eventos.ItemsSource = null;
                }


            }

        }

        private void bt_create_competicao_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            Create_Competicao competicao = new Create_Competicao();
            competicao.Left = mainWindowLeft;
            competicao.Top = mainWindowTop;
            competicao.Width = mainWindowWidth;
            competicao.Height = mainWindowHeight;
            competicao.WindowState = mainWindowState;
            competicao.Show();
            Close();
        }

        private void bt_create_evento_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            Create_Evento evento = new Create_Evento();
            evento.Left = mainWindowLeft;
            evento.Top = mainWindowTop;
            evento.Width = mainWindowWidth;
            evento.Height = mainWindowHeight;
            evento.WindowState = mainWindowState;
            evento.Show();
            Close();
        }

        private void bt_edit_menu_evento_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            Edit_Evento evento = new Edit_Evento();
            evento.Left = mainWindowLeft;
            evento.Top = mainWindowTop;
            evento.Width = mainWindowWidth;
            evento.Height = mainWindowHeight;
            evento.WindowState = mainWindowState;
            evento.Show();
            Close();

        }

        private void bt_edit_menu_competicao_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            Edit_Competicao competicao = new Edit_Competicao();
            competicao.Left = mainWindowLeft;
            competicao.Top = mainWindowTop;
            competicao.Width = mainWindowWidth;
            competicao.Height = mainWindowHeight;
            competicao.WindowState = mainWindowState;
            competicao.Show();
            Close();
        }

        private void bt_remove_menu_evento_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            Delete_Evento evento = new Delete_Evento();
            evento.Left = mainWindowLeft;
            evento.Top = mainWindowTop;
            evento.Width = mainWindowWidth;
            evento.Height = mainWindowHeight;
            evento.WindowState= mainWindowState;
            evento.Show();
            Close();
        }

        private void bt_delete_competicao_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            Delete_Competicao competicao = new Delete_Competicao();
            competicao.Left = mainWindowLeft;
            competicao.Top = mainWindowTop;
            competicao.Width = mainWindowWidth;
            competicao.Height = mainWindowHeight;
            competicao.WindowState = mainWindowState;
            competicao.Show();
            Close();
        }

        //Handles the creation of the ICS file
        public void GenerateICalFile(string filePath)
        {
            //Gets nome from both Competicao and Evento through the junctiontable and also the data 
            var events = from e1 in context.Competicao
                         join junction in context.JunctionTable on e1.Id equals junction.Competicao_Id
                         join e2 in context.Evento on junction.Evento_Id equals e2.Id
                         select new
                         {
                             Nome = e2.Nome,
                             Nome2 = e1.Nome,
                             Data = e2.Data.ToString("yyyyMMdd")
                         };

            //Create the file using the previous values
            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(fs))
            {
                // Write iCalendar header
                writer.WriteLine("BEGIN:VCALENDAR");
                writer.WriteLine("VERSION:2.0");

                // Write events
                foreach (var calendarEvent in events)
                {
                    writer.WriteLine("BEGIN:VEVENT");
                    writer.WriteLine($"SUMMARY:{calendarEvent.Nome2} - {calendarEvent.Nome}");
                    writer.WriteLine($"DTSTART:{calendarEvent.Data:yyyyMMdd}");

                    writer.WriteLine("END:VEVENT");
                }

                // Write iCalendar footer
                writer.WriteLine("END:VCALENDAR");
            }

        }

        private void bt_ical_Click(object sender, RoutedEventArgs e)
        {
            // Create a SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.ics)|*.ics|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save File";

            // Show the SaveFileDialog
            if (saveFileDialog.ShowDialog() == true)
            {
                // Get the selected file name and path
                string filePath = saveFileDialog.FileName;

                try
                {
                    // Generate the content you want to save
                    GenerateICalFile(filePath);

                    // Write the content to the selected file
                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        //handles the change of size
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                lb_eventos.Margin = new Thickness(35, 169, 1105, 80);
            }
            else
            {
                lb_eventos.Margin = new Thickness(35, 169, 439, 80);
            }
        }
    }
}