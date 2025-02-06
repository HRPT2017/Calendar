using Calendar.Database;
using Calendar.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;



namespace Calendar
{
    public partial class EditCompetition : Window
    {
        DataContext context = new DataContext();
        public EditCompetition()
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

                var eventos = context.Events.Where(c => c.modalityId == selectedModalityId).ToList();
                lb_events_edit.ItemsSource = eventos;

                var competitions = context.Competitions.Where(c => c.modalityId== selectedModalityId).ToList();
                cb_edit_competition.ItemsSource = competitions;
                cb_edit_competition.DisplayMemberPath = "Name";

                tb_edit_competition.Text = null;
                lb_event_edit.ItemsSource = null;
              


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
        private void bt_edit_competition_Click(object sender, RoutedEventArgs e)
        {
            if (cb_modality != null)
            {
                // Modality selectedModalidade = (Modality)cb_modality.SelectedItem;
               // int selectedModalidadeId = selectedModalidade.id;

                Competition selectedcompetition = (Competition)cb_edit_competition.SelectedItem;
                int selectedcompetitionId = selectedcompetition.id;

                string aux = tb_edit_competition.Text.ToString();
                string result = aux.TrimStart();
                List<string> ev = context.Competitions.Select(c => c.name).ToList();
                if (!string.IsNullOrEmpty(aux))
                {

                    Competition events = context.Competitions.First(c => c.id == selectedcompetitionId);

                    events.name = result;

                    context.Update(events);
                    context.SaveChanges();

                }
                else MessageBox.Show("Write the name of the event");


                if (lb_events_edit.ItemsSource != null)
                {
                    List<int> selectedIds = lb_events_edit.SelectedItems.Cast<Event>().Select(entity => entity.id).ToList();

                    foreach (int selectedId in selectedIds)
                    {
                        var jt = new EventCompetition()
                        {
                            eventId = selectedId,
                            competitionId= selectedcompetitionId
                        };

                        context.EventsCompetitions.Remove(jt);
                        context.SaveChanges();
                        context.Entry(jt).State = EntityState.Detached;
                    }


                }

                if (lb_event_edit.SelectedItem != null)
                {
                    List<int> selectedIds = lb_event_edit.SelectedItems.Cast<Event>().Select(entity => entity.id).ToList();

                    foreach (int selectedId in selectedIds)
                    {
                        var jt = new EventCompetition()
                        {
                            eventId = selectedId,
                            competitionId = selectedcompetitionId
                        };

                        context.EventsCompetitions.Add(jt);
                        context.SaveChanges();
                        context.Entry(jt).State = EntityState.Detached;
                    }



                }

            }
            else MessageBox.Show("Select a modality");

            double mainWindowLeft = Left;
            double mainWindowTop = Top;
            double mainWindowWidth = Width;
            double mainWindowHeight = Height;
            WindowState mainWindowState = WindowState;

            EditCompetition eve = new EditCompetition();
            eve.Left = mainWindowLeft;
            eve.Top = mainWindowTop;
            eve.Width = mainWindowWidth;
            eve.Height = mainWindowHeight;
            eve.WindowState = mainWindowState;
            eve.Show();
            Close();
        }

        private void cb_edit_competition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_edit_competition.SelectedValue != null)
            {
                Competition selectedcompetition = (Competition)cb_edit_competition.SelectedItem;
                int selectedcompetitionId = selectedcompetition.id;

                Modality selectedModality= (Modality)cb_modality.SelectedItem;
                int selectedModalityId = selectedModality.id;


                Competition comp = context.Competitions.First(c => c.id == selectedcompetitionId);

                tb_edit_competition.Text = comp.name;


                List<int> ev = context.EventsCompetitions.Select(c => c.competitionId).ToList();

                if (ev.Contains(selectedcompetitionId))
                {
                    var result = from e1 in context.Competitions
                                 join junction in context.EventsCompetitions on e1.id equals junction.competitionId
                                 join e2 in context.Events on junction.eventId equals e2.id
                                 where e1.id == selectedcompetitionId
                                 select e2;

                    lb_events_edit.ItemsSource = result.ToList();

                    var remainingEvents = context.Events.Where(c => c.modalityId == selectedModalityId).Except(result);

                    // Display the remaining items in another ListBox (lb_remaining_competicoes)
                    lb_event_edit.ItemsSource = remainingEvents.ToList();
                }
                else
                {
                    lb_events_edit.ItemsSource = null;
                    var events = context.Events.Where(c => c.modalityId == selectedModalityId).ToList();
                    lb_event_edit.ItemsSource = events;
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                lb_events_edit.Margin = new Thickness(266, 42, 228, 480);
                l_event_edit.Margin = new Thickness(266, 370, 0, 0);
                lb_event_edit.Margin = new Thickness(266, 400, 228, 45);

            }
            else
            {
                lb_events_edit.Margin = new Thickness(266, 42, 228, 241);
                l_event_edit.Margin = new Thickness(266, 196, 0, 0);
                lb_event_edit.Margin = new Thickness(266, 222, 228, 45);
            }
        }
    }
}
