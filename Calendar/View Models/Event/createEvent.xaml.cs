using Calendar.Database;
using Calendar.Models;
using System.Windows;
using System.Windows.Controls;



namespace Calendar
{

    public partial class CreateEvent : Window
    {
        DataContext context = new DataContext();
        public CreateEvent()
        {
            InitializeComponent();

            LoadModality();
        }

        public void LoadModality()
        {
            List<Modality> name = context.Modalities.ToList();
            cb_modality.ItemsSource = name;
            cb_modality.DisplayMemberPath = "Name";


        }

        private void cb_modality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_modality.SelectedItem != null)
            {
                Modality selectedModality = (Modality)cb_modality.SelectedItem;
                int selectedModalityId = selectedModality.id;

                var competitions = context.Competitions.Where(c => c.modalityId == selectedModalityId).ToList();
                lb_competitions.ItemsSource = competitions;
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
        private void bt_event_Click(object sender, RoutedEventArgs e)
        {
            if (cb_modality != null)
            {
                string aux = tb_event_name.Text.ToString();
                string result = aux.TrimStart();
                List<string> ev = context.Events.Select(c => c.name).ToList();

                Modality selectedModaltiy = (Modality)cb_modality.SelectedItem;
                int selectedModaltiyId = selectedModaltiy.id;


                    List<int> selectedIds = lb_competitions.SelectedItems.Cast<Competition>().Select(entity => entity.id).ToList();

                    if (!string.IsNullOrEmpty(result))
                    {
                        if (!ev.Contains(result))
                        {
                            if (dp_start_date.SelectedDate != null)
                            {
                                var evento = new Event()
                                {
                                    modalityId = selectedModaltiyId,
                                    name = result,
                                    startDate = (DateTime)dp_start_date.SelectedDate,
                                    endDate = dp_end_date.SelectedDate != null ? (DateTime)dp_end_date.SelectedDate : null
                                };

                                context.Add(evento);
                                context.SaveChanges();
                                foreach (int selectedId in selectedIds)
                                {
                                    var jt = new EventCompetition()
                                    {
                                        eventId = evento.id,
                                        competitionId= selectedId
                                    };

                                    context.EventsCompetitions.Add(jt);
                                }
                                context.SaveChanges();
                                cb_modality.SelectedItem = null;
                                tb_event_name.Text = null;
                                dp_start_date.Text = null;
                                dp_end_date.Text = null;
                            }
                            else MessageBox.Show("Select a start date");
                        }
                        else MessageBox.Show("Event already exists");
                    }
                    else MessageBox.Show("Insert an event name");

                }
            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            CreateEvent eve = new CreateEvent();
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
