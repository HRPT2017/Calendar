using Calendar.Database;
using Calendar.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Controls;



namespace Calendar
{

    public partial class EditEvent : Window
    {
        DataContext context = new DataContext();
        public EditEvent()
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
            List<Modality> nome = context.Modality.ToList();
            cb_modality.ItemsSource = nome;
            cb_modality.DisplayMemberPath = "name";


        }


        //Handles what happens when the selected item in the combobox changes
        private void cb_modality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_modality.SelectedItem != null)
            {
                Modality selectedModality= (Modality)cb_modality.SelectedItem;
                int selectedModalityId = selectedModality.id;

                var competitions = context.Event.Where(c => c.modalityId == selectedModalityId).ToList();
                lb_competitions.ItemsSource = competitions;

                var events = context.Event.Where(c => c.modalityId == selectedModalityId).ToList();
                cb_edit_event.ItemsSource = events;
                cb_edit_event.DisplayMemberPath = "Name";

                tb_edit_event.Text = null;
                dp_start_date_edit.Text = null;
                dp_end_date_edit.Text = null;
                lb_competitions_edit.ItemsSource = null;
            }

        }

        //Handles the logic behind the edit
        private void bt_edit_event_Click(object sender, RoutedEventArgs e)
        {
            if (cb_modality != null)
            {
                // Gets the Id from the selected Modalidade
                //Modality selectedModality = (Modality)cb_modality.SelectedItem;
                //int selectedModalityId = selectedModality.id;

                // Gets the Id from the selected Evento
                Event selectedEvent = (Event)cb_edit_event.SelectedItem;
                int selectedEventId = selectedEvent.id;

                string aux = tb_edit_event.Text.ToString();
                //Starts reading after the first character
                string result = aux.TrimStart();
                List<string> ev = context.Event.Select(c => c.name).ToList();
                
                //Checks if Nome is not null
                if (!string.IsNullOrEmpty(aux))
                {
                    //check if the Data is not null
                    if (dp_start_date_edit.SelectedDate != null || dp_start_date_edit.Text != null)
                    {
                        Event events = context.Event.First(c => c.id == selectedEventId);

                        events.name = result;
                        events.startDate = (DateTime)dp_start_date_edit.SelectedDate.GetValueOrDefault( );

                        context.Update(events);
                        context.SaveChanges();
                    } else MessageBox.Show("Select a start date");

                    if (dp_end_date_edit.SelectedDate != null || dp_end_date_edit.Text != null)
                    {
                        Event events = context.Event.First(c => c.id == selectedEventId);

                        events.name = result;
                        events.startDate = (DateTime)dp_end_date_edit.SelectedDate.GetValueOrDefault();

                        context.Update(events);
                        context.SaveChanges();
                    }
                  

                }
                else MessageBox.Show("Write the name of an event");

                //Remove the selected items and the evento from the junction table
                if (lb_competitions.ItemsSource != null)
                {
                    List<int> selectedIds = lb_competitions.SelectedItems.Cast<Competition>().Select(entity => entity.id).ToList();

                    foreach (int selectedId in selectedIds)
                    {
                        var jt = new EventCompetition()
                        {
                            eventId = selectedEventId,
                            competitionId = selectedId
                        };

                        context.EventCompetition.Remove(jt);
                        context.SaveChanges();
                        context.Entry(jt).State = EntityState.Detached;
                    }

                }

                //Add the selected items and the evento to the junction table
                if (lb_competitions_edit.SelectedItem != null)
                {
                    List<int> selectedIds = lb_competitions_edit.SelectedItems.Cast<Competition>().Select(entity => entity.id).ToList();

                    foreach (int selectedId in selectedIds)
                    {
                        var jt = new EventCompetition()
                        {
                            eventId = selectedEventId,
                            competitionId = selectedId

                        };

                        context.EventCompetition.Add(jt);

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

            EditEvent eve = new EditEvent();
            eve.Left = mainWindowLeft;
            eve.Top = mainWindowTop;
            eve.Width = mainWindowWidth;
            eve.Height = mainWindowHeight;
            eve.WindowState = mainWindowState;
            eve.Show();
            Close();

        }

        private void cb_edit_event_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_edit_event.SelectedValue != null)
            {
                Modality selectedModality = (Modality)cb_modality.SelectedItem;
                int selectedModalityId = selectedModality.id;

                Event selectedEvent = (Event)cb_edit_event.SelectedItem;
                int selectedEventId = selectedEvent.id;


                Event events = context.Event.First(c => c.id == selectedEventId);

                tb_edit_event.Text = events.name;

                dp_start_date_edit.Text = events.startDate.ToString();

                dp_end_date_edit.Text = events.endDate.ToString();

                List<int> comp = context.EventCompetition.Select(c => c.eventId).ToList();

                //Gets the Competicao data through the junction table using the Evento Id
                if (comp.Contains(selectedEventId))
                {
                    var result = from e1 in context.Event
                                 join junction in context.EventCompetition on e1.id equals junction.eventId
                                 join e2 in context.Competition on junction.competitionId equals e2.id
                                 where e1.id == selectedEventId
                                 select e2;

                    lb_competitions.ItemsSource = result.ToList();


                    var remainingCompeticoes = context.Competition.Where(c => c.modalityId == selectedModalityId).Except(result);

                    // Display the remaining items in another ListBox (lb_remaining_competicoes)
                    lb_competitions_edit.ItemsSource = remainingCompeticoes.ToList();
                }
                else
                {
                    lb_competitions.ItemsSource = null;
                    var ev = context.Competition.Where(c => c.modalityId == selectedModalityId).ToList();
                    lb_competitions_edit.ItemsSource = ev; ;
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(WindowState == WindowState.Maximized)
            {
                lb_competitions.Margin = new Thickness(266, 42, 228, 480);
                l_competitions_edit.Margin = new Thickness(266,370,0,0);
                lb_competitions_edit.Margin = new Thickness(266, 400, 228, 45);

            }
            else 
            {
                lb_competitions.Margin = new Thickness(266, 42, 228, 241);
                l_competitions_edit.Margin = new Thickness(266, 196, 0, 0);
                lb_competitions_edit.Margin = new Thickness(266, 222, 228, 45);
            }
        }
    }
}
