﻿using Calendar.Models;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using Calendar.Database;

/*
 * Author: Hugo Teixeira
 */

namespace Calendar
{

    public partial class MainWindow : Window
    {
        DataContext context = new DataContext();

        private readonly ScraperService scraperService;
        private string? calendarData;
        private string? mcData;

        public string CalendarData
        {
            get => calendarData ?? "";
            set { calendarData = value; OnPropertyChanged(); }
        }

        public string MCData
        {
            get => mcData ?? "";
            set { mcData = value; OnPropertyChanged(); }
        }

        public IRelayCommand ScrapeCommand { get; }

        public MainWindow()
        {
            InitializeComponent();

            LoadModality();

            LoadCompetition();

            scraperService = new ScraperService();

            ScrapeCommand = new RelayCommand(async () => await ScrapeCalendar());



        }

        public void LoadModality()
        {
            List<Modality> name = context.Modality.ToList();
            cb_modality.ItemsSource = name;
            cb_modality.DisplayMemberPath = "name";

        }

        public void LoadCompetition()
        {
            List<Competition> name = context.Competition.ToList();
            cb_competition.ItemsSource = name;
            cb_competition.DisplayMemberPath = "name";

        }

        private void cb_modality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_modality.SelectedItem != null)
            {
                Modality selectedModality = (Modality)cb_modality.SelectedItem;
                int selectedModalityId = selectedModality.id;

                var competitions = context.Competition.Where(c => c.modalityId == selectedModalityId).ToList();
                cb_competition.ItemsSource = competitions;
                cb_competition.DisplayMemberPath = "name";


                var events = context.Event.Where(c => c.modalityId == selectedModalityId).ToList();
                List<dynamic> result = new List<dynamic>();
                foreach (var item in events)
                {
                    result.Add(new
                    {
                        name = item.name,
                        dateRange = item.endDate.HasValue
                        ? item.startDate.ToString("dd/MM/yyyy") + " - " + item.endDate.Value.ToString("dd/MM/yyyy")
                        : item.startDate.ToString("dd/MM/yyyy")
                    });
                }
                lb_events.ItemsSource = result;


            }

        }

        private void cb_competition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_competition.SelectedItem != null)
            {
                Competition selectedCompetition = (Competition)cb_competition.SelectedItem;
                int selectedCompetitionId = selectedCompetition.id;


                List<int> event_ = context.EventCompetition.Select(c => c.competitionId).ToList();


                if (event_.Contains(selectedCompetitionId))
                {
                    var result = from e1 in context.Competition
                                 join junction in context.EventCompetition on e1.id equals junction.competitionId
                                 join e2 in context.Event on junction.eventId equals e2.id
                                 where e1.id == selectedCompetitionId
                                 select new
                                 {
                                     name = e2.name,
                                     dateRange = e2.endDate.HasValue 
                                     ? e2.startDate.ToString("dd/MM/yyyy") + " - "+ e2.endDate.Value.ToString("dd/MM/yyyy") 
                                     : e2.startDate.ToString("dd/MM/yyyy")
                                 };

                    lb_events.ItemsSource = result.ToList();
                }
                else
                {
                    lb_events.ItemsSource = null;
                }


            }

        }

        private void bt_create_competition_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            CreateCompetition competicao = new CreateCompetition();
            competicao.Left = mainWindowLeft;
            competicao.Top = mainWindowTop;
            competicao.Width = mainWindowWidth;
            competicao.Height = mainWindowHeight;
            competicao.WindowState = mainWindowState;
            competicao.Show();
            Close();
        }

        private void bt_create_event_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            CreateEvent evento = new CreateEvent();
            evento.Left = mainWindowLeft;
            evento.Top = mainWindowTop;
            evento.Width = mainWindowWidth;
            evento.Height = mainWindowHeight;
            evento.WindowState = mainWindowState;
            evento.Show();
            Close();
        }

        private void bt_edit_menu_event_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            EditEvent evento = new EditEvent();
            evento.Left = mainWindowLeft;
            evento.Top = mainWindowTop;
            evento.Width = mainWindowWidth;
            evento.Height = mainWindowHeight;
            evento.WindowState = mainWindowState;
            evento.Show();
            Close();

        }

        private void bt_edit_menu_competition_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            EditCompetition competicao = new EditCompetition();
            competicao.Left = mainWindowLeft;
            competicao.Top = mainWindowTop;
            competicao.Width = mainWindowWidth;
            competicao.Height = mainWindowHeight;
            competicao.WindowState = mainWindowState;
            competicao.Show();
            Close();
        }

        private void bt_remove_menu_event_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            DeleteEvent evento = new DeleteEvent();
            evento.Left = mainWindowLeft;
            evento.Top = mainWindowTop;
            evento.Width = mainWindowWidth;
            evento.Height = mainWindowHeight;
            evento.WindowState = mainWindowState;
            evento.Show();
            Close();
        }

        private void bt_delete_competition_Click(object sender, RoutedEventArgs e)
        {
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            DeleteCompetition competicao = new DeleteCompetition();
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
            var events = from e1 in context.Competition
                         join junction in context.EventCompetition on e1.id equals junction.competitionId
                         join e2 in context.Event on junction.eventId equals e2.id
                         join modality in context.Modality on e1.modalityId equals modality.id
                         select new
                         {
                             eventName = e2.name,
                             competitionName = e1.name,
                             badge = e1.badge,
                             startDate = e2.startDate.ToString("yyyyMMdd"),
                             endDate = e2.endDate.HasValue ? e2.endDate.Value.ToString("yyyyMMdd") : e2.startDate.ToString("yyyyMMdd"),
                             modalityName = modality.name
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
                    writer.WriteLine($"SUMMARY:{calendarEvent.competitionName} ({calendarEvent.badge}) - {calendarEvent.eventName}");
                    writer.WriteLine($"DTSTART:{calendarEvent.startDate:yyyyMMdd}");
                    writer.WriteLine($"DTEND:{calendarEvent.endDate:yyyyMMdd}");
                    writer.WriteLine($"DESCRIPTION:{calendarEvent.modalityName}");
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
                lb_events.Margin = new Thickness(35, 169, 1105, 80);
            }
            else
            {
                lb_events.Margin = new Thickness(35, 169, 439, 80);
            }
        }

        private void btScrapeCalendar(object sender, RoutedEventArgs e) => ScrapeCalendar();

        private async Task ScrapeCalendar()
        {
            CalendarData = "Loading...";
            CalendarData = await scraperService.ScrapeCalendarData();
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            MainWindow eve = new MainWindow();
            eve.Left = mainWindowLeft;
            eve.Top = mainWindowTop;
            eve.Width = mainWindowWidth;
            eve.Height = mainWindowHeight;
            eve.WindowState = mainWindowState;
            eve.Show();
            Close();
        }

        private void btScrapeMC(object sender, RoutedEventArgs e) => ScrapeMC();

        private async Task ScrapeMC()
        {
            MCData = "Loading...";
            MCData= await scraperService.ScrapeMCData();
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            MainWindow eve = new MainWindow();
            eve.Left = mainWindowLeft;
            eve.Top = mainWindowTop;
            eve.Width = mainWindowWidth;
            eve.Height = mainWindowHeight;
            eve.WindowState = mainWindowState;
            eve.Show();
            Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}