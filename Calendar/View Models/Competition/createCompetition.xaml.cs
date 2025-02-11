using Calendar.Database;
using Calendar.Models;
using System.Windows;
using System.Windows.Controls;



namespace Calendar
{
    public partial class CreateCompetition : Window
    {
        DataContext context = new DataContext();
        public CreateCompetition()
        {
            

            InitializeComponent();

            LoadModality();
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
                int selectedModalityeId = selectedModality.id;

                var events = context.Event.Where(c => c.modalityId == selectedModalityeId).ToList();
                lb_events.ItemsSource = events;
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
        private void bt_create_competition_Click(object sender, RoutedEventArgs e)
        {
            if (cb_modality != null)
            {
                string aux = tb_competition.Text.ToString();
                string result = aux.TrimStart();
                List<string> ev = context.Competition.Select(c => c.name).ToList();

                Modality selectedModality = (Modality)cb_modality.SelectedItem;
                int selectedModalityId = selectedModality.id;

                List<int> selectedIds = lb_events.SelectedItems.Cast<Event>().Select(entity => entity.id).ToList();

                if (!string.IsNullOrEmpty(result))
                {
                    if (!ev.Contains(result))
                    {

                        var event_ = new Competition()
                        {
                            modalityId = selectedModalityId,
                            name = result,
                            badge = ""
                        };

                        context.Add(event_);
                        context.SaveChanges();
                        foreach (int selectedId in selectedIds)
                        {
                            var jt = new EventCompetition()
                            {
                                eventId = selectedId,
                                competitionId = event_.id
                            };

                            context.EventCompetition.Add(jt);
                        }
                        context.SaveChanges();
                        cb_modality.SelectedItem = null;
                        tb_competition.Text = null;
                        lb_events.ItemsSource = null;

                    }
                    else
                    {
                        MessageBox.Show("Competition already exists");
                    }
                }
                else MessageBox.Show("Insert the name of a competition");

            }
            else MessageBox.Show("Select a modality");
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            CreateCompetition eve = new CreateCompetition();
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
