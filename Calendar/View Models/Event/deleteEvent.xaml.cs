using Calendar.Database;
using Calendar.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;


namespace Calendar
{

    public partial class DeleteEvent : Window
    {
        DataContext context = new DataContext();
        public DeleteEvent()
        {
            InitializeComponent();
            LoadModality();
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

        public void LoadModality()
        {
            List<Modality> name = context.Modality.ToList();
            cb_modality.ItemsSource = name;
            cb_modality.DisplayMemberPath = "name";
                

        }

        private void cb_modality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_modality.SelectedItem != null)
            {
                Modality selectedModality = (Modality)cb_modality.SelectedItem;
                int selectedModalityId = selectedModality.id;

                var competitions = context.Competition.Where(c => c.modalityId == selectedModalityId).ToList();
                lb_competitions.ItemsSource = competitions;

                var events = context.Competition.Where(c => c.modalityId == selectedModalityId).ToList();
                cb_event.ItemsSource = events;
                cb_event.DisplayMemberPath = "Name";

                tb_start_date.Text = null;
                tb_end_date.Text = null;
            }

        }

        private DataContext GetContext()
        {
            return context;
        }

        private void cb_event_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var context = (DataContext)DataContext;  // Defina o contexto de dados aqui, se necessário

            if (cb_event.SelectedItem != null)
            {
                //Modality selectedModality= (Modality)cb_modality.SelectedItem;
                //int selectedModalityId = selectedModality.id;

                Event selectedEvent = (Event)cb_event.SelectedItem;
                int selectedEventId = selectedEvent.id;

                Event events = context.Event.First(c => c.id == selectedEventId);

                tb_start_date.Text = events.startDate.ToString();
                tb_end_date.Text= events.endDate.ToString();

                List<int> comp = context.EventCompetition.Select(c => c.eventId).ToList();

                if (comp.Contains(selectedEventId))
                {
                    var result = from e1 in context.Event
                                 join junction in context.EventCompetition on e1.id equals junction.eventId
                                 join e2 in context.Competition on junction.competitionId equals e2.id
                                 where e1.id == selectedEventId
                                 select e2;

                    lb_competitions.ItemsSource = result.ToList();
                }
                else
                {
                    lb_competitions.ItemsSource = null;
                }
            }
        }
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

                DeleteEvent eve = new DeleteEvent();
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
            if (cb_modality != null)
            {
                //Modality selectedModality= (Modality)cb_modality.SelectedItem;
                //int selectedModalityId = selectedModality.id;

                Event selectedEvent = (Event)cb_event.SelectedItem;
                int selectedEventId = selectedEvent.id;

                var selectedIds = context.EventCompetition.Where(c => c.eventId == selectedEventId).ToList();

                if (selectedIds.Any())
                {
                    context.EventCompetition.RemoveRange(selectedIds);
                    context.SaveChanges();
                }

                if (cb_event.SelectedItem != null)
                {
                    var event_ = context.Event.Find(selectedEventId);
                    if (event_ != null)
                    {
                        context.Event.Remove(event_);
                        context.SaveChanges();
                        context.Entry(event_).State = EntityState.Detached;
                    }
                }
            }
            else MessageBox.Show("Select a modality");


            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            DeleteEvent eve = new DeleteEvent();
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
