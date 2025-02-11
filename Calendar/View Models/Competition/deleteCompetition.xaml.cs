using Calendar.Database;
using Calendar.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;



namespace Calendar
{
    public partial class DeleteCompetition : Window
    {
        DataContext context = new DataContext();
        public DeleteCompetition()
        {
            InitializeComponent();
            LoadModality();
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
        public void LoadModality()
        {
            List<Modality> name = context.Modality.ToList();
            cb_modality.ItemsSource = name;
            cb_modality.DisplayMemberPath = "name";
        }

        //Handles what happens when the selected item in the combobox changes
        private void cb_modality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_modality.SelectedItem != null)
            {


                Modality selectedModality = (Modality)cb_modality.SelectedItem;
                int selectedModalityId = selectedModality.id;

                var events = context.Event.Where(c => c.modalityId == selectedModalityId).ToList();
                lb_events.ItemsSource = events;

                var competitions = context.Competition.Where(c => c.modalityId== selectedModalityId).ToList();
                cb_competition.ItemsSource = competitions;
                cb_competition.DisplayMemberPath = "name";

                
            }

        }

        //Handles what happens when the selected item in the combobox changes
        private void cb_event_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_competition.SelectedItem != null)
            {
   

                Competition selectedCompetition = (Competition)cb_competition.SelectedItem;
                int selectedCompetitionId = selectedCompetition.id;



                List<int> comp = context.EventCompetition.Select(c => c.eventId).ToList();

                if (comp.Contains(selectedCompetitionId))
                {
                    var result = from e1 in context.Competition
                                 join junction in context.EventCompetition on e1.id equals junction.competitionId
                                 join e2 in context.Event on junction.eventId equals e2.id
                                 where e1.id == selectedCompetitionId
                                 select e2;

                    lb_events.ItemsSource = result.ToList();



                }
                else
                {
                    lb_events.ItemsSource = null;
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

                DeleteCompetition eve = new DeleteCompetition();
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
            if (cb_modality!= null)
            {


                Competition selectedCompetition = (Competition)cb_competition.SelectedItem;
                int selectedCompetitionId = selectedCompetition.id;

                var selectedIds = context.EventCompetition.Where(c => c.competitionId == selectedCompetitionId).ToList();

                if (selectedIds.Any())
                {
                    context.EventCompetition.RemoveRange(selectedIds);
                    context.SaveChanges();
                }

                if (cb_competition.SelectedItem != null)
                {
                    var competition = context.Competition.Find(selectedCompetitionId);
                    if (competition != null)
                    {
                        context.Competition.Remove(competition);
                        context.SaveChanges();
                        context.Entry(competition).State = EntityState.Detached;
                    }

                }
            }
            else MessageBox.Show("Selecit a modality");

            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            DeleteCompetition eve = new DeleteCompetition();
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
