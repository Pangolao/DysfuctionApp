using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Dysfunction.Model;
using System.Globalization;
using Dysfunction.Logic;
using Dysfunction.GUI.Register;

namespace Dysfunction.GUI.Consult
{
    public partial class Calendar : Form
    {
        projectLogic projectLogic = new projectLogic();
        asignatureLogic asignatureLogic = new asignatureLogic();
        eventsLogic eventsLogic = new eventsLogic();

        periodLogic periodLogic = new periodLogic();
        private Dysfunction dysfunctionForm;

        public Calendar(Dysfunction dysfunction)
        {
            InitializeComponent();
            dysfunctionForm = dysfunction;
            dysfunction.cache = 0;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
            AddEventsWeekly();

            AddEventsDaily();

        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            AddEventsDaily();
        }

        private void AddEventsWeekly()
        {
            var cultureInfo = CultureInfo.CurrentCulture;
            List<projectModel> projectModels = projectLogic.Consult();
            List<eventsModel> eventsModels = eventsLogic.Consult();
            List<periodModel> periodModels = periodLogic.Consult();

            listBoxWeek.Items.Clear();

            // Collect all upcoming items with their relevant date and type
            var upcomingItems = new List<(DateTime date, string type, object item, string extra)>();

            foreach (var events in eventsModels)
            {
                if (events != null)
                {
                    if (events.StartDate.Date >= DateTime.Now.Date)
                        upcomingItems.Add((events.StartDate.Date, "event_start", events, null));
                    if (events.EndDate.HasValue && events.EndDate.Value.Date >= DateTime.Now.Date)
                        upcomingItems.Add((events.EndDate.Value.Date, "event_end", events, null));
                }
            }

            foreach (var project in projectModels)
            {
                if (project != null && project.LimitDate.Date >= DateTime.Now.Date)
                    upcomingItems.Add((project.LimitDate.Date, "project", project, asignatureLogic.ObtainName(project.Code)));
            }

            foreach (var period in periodModels)
            {
                if (period != null)
                {
                    if (period.StartDate.Date >= DateTime.Now.Date)
                        upcomingItems.Add((period.StartDate.Date, "period_start", period, null));
                    if (period.EndDate.Date >= DateTime.Now.Date)
                        upcomingItems.Add((period.EndDate.Date, "period_end", period, null));
                }
            }

            // Sort by date ascending
            upcomingItems.Sort((a, b) => a.date.CompareTo(b.date));

            if (upcomingItems.Count > 0)
            {
                listBoxWeek.Items.Add($"----------------------------------------------------------------------");
                listBoxWeek.Items.Add($" Upcoming events");
                listBoxWeek.Items.Add($"----------------------------------------------------------------------");

                foreach (var item in upcomingItems)
                {
                    switch (item.type)
                    {
                        case "event_start":
                            var evStart = (eventsModel)item.item;
                            listBoxWeek.Items.Add($" {evStart.StartDate.ToString("dddd, dd MMM", cultureInfo)} {evStart.Hour}");
                            listBoxWeek.Items.Add($" {evStart.Name}");
                            listBoxWeek.Items.Add(" ");
                            break;
                        case "event_end":
                            var evEnd = (eventsModel)item.item;
                            listBoxWeek.Items.Add($" {evEnd.EndDate.Value.ToString("dddd, dd MMM", cultureInfo)} {evEnd.Hour}");
                            listBoxWeek.Items.Add($" End of {evEnd.Name}");
                            listBoxWeek.Items.Add(" ");
                            break;
                        case "project":
                            var proj = (projectModel)item.item;
                            listBoxWeek.Items.Add($" {proj.LimitDate.ToString("dddd, dd MMM", cultureInfo)}");
                            listBoxWeek.Items.Add($" Limit date for:");
                            listBoxWeek.Items.Add($" {proj.Project} ({item.extra})");
                            listBoxWeek.Items.Add(" ");
                            break;
                        case "period_start":
                            var perStart = (periodModel)item.item;
                            listBoxWeek.Items.Add($" {perStart.StartDate.ToString("dddd, dd MMM", cultureInfo)}");
                            listBoxWeek.Items.Add($" Start of {perStart.Period} ");
                            listBoxWeek.Items.Add(" ");
                            break;
                        case "period_end":
                            var perEnd = (periodModel)item.item;
                            listBoxWeek.Items.Add($" {perEnd.EndDate.ToString("dddd, dd MMM", cultureInfo)}");
                            listBoxWeek.Items.Add($" End of {perEnd.Period} ");
                            listBoxWeek.Items.Add(" ");
                            break;
                    }
                }
            }
            else
            {
                listBoxWeek.Items.Add($"----------------------------------------------------------------------");
                listBoxWeek.Items.Add($" No upcoming events or projects");
                listBoxWeek.Items.Add($"----------------------------------------------------------------------");
            }
        }

        private void AddEventsDaily()
        {
            List<projectModel> projectModels = projectLogic.Consult();
            List<eventsModel> eventsModels = eventsLogic.Consult();
            List<periodModel> periodModels = periodLogic.Consult();
            listBoxDay.Items.Clear();

            bool hasEvents = false;
            bool hasProjects = false;
            bool hasPeriods = false;
            var cultureInfo = CultureInfo.CurrentCulture;

            foreach (var events in eventsModels)
            {
                if (events != null && (events.StartDate.Date == monthCalendar.SelectionStart.Date || events.EndDate?.Date == monthCalendar.SelectionStart.Date
                    || events.StartDate.Date == monthCalendar.TodayDate || events.EndDate?.Date == monthCalendar.TodayDate))
                {
                    hasEvents = true;
                    break;
                }
            }

            foreach (var project in projectModels)
            {
                if (project != null && project.LimitDate.Date == monthCalendar.SelectionStart.Date)
                {
                    hasProjects = true;
                    break;
                }
            }

            foreach (var period in periodModels)
            {
                if (period != null && (period.StartDate.Date == monthCalendar.SelectionStart.Date || period.EndDate.Date == monthCalendar.SelectionStart.Date
                    || period.StartDate.Date == monthCalendar.TodayDate || period.EndDate.Date == monthCalendar.TodayDate))
                {
                    hasPeriods = true;
                    break;
                }
            }

            //if (hasEvents || hasProjects || hasPeriods) 
            //{ 
            listBoxDay.Items.Add($"----------------------------------------------------------------------"); ;
            listBoxDay.Items.Add($" {monthCalendar.SelectionStart.Date.ToString("dddd, dd MMM", cultureInfo)}");
            listBoxDay.Items.Add($"----------------------------------------------------------------------");
            // }

            foreach (var events in eventsModels)
            {
                if (events != null && events.StartDate.Date == monthCalendar.SelectionStart.Date)
                {
                    if (events.Hour != null)
                    {
                        listBoxDay.Items.Add($" {events.Hour}");
                        listBoxDay.Items.Add($" {events.Name}");
                        listBoxDay.Items.Add(" ");
                    }
                    else
                    {
                        listBoxDay.Items.Add($" {events.Name}"); ;
                        listBoxDay.Items.Add(" ");
                    }
                }
                if (events.EndDate?.Date == monthCalendar.SelectionStart.Date)
                {
                    listBoxDay.Items.Add($" End of {events.Name}");
                    listBoxDay.Items.Add(" ");
                }
            }


            foreach (var project in projectModels)
            {
                if (project != null && project.LimitDate.Date == monthCalendar.SelectionStart.Date)
                {
                    listBoxDay.Items.Add($" Limit date for:");
                    listBoxDay.Items.Add($" {project.Project} ({asignatureLogic.ObtainName(project.Code)})");
                    listBoxDay.Items.Add(" ");
                }
            }

            foreach (var period in periodModels)
            {
                if (period != null && (period.StartDate.Date == monthCalendar.SelectionStart.Date))
                {
                    listBoxDay.Items.Add($" Start of {period.Period}");
                    listBoxDay.Items.Add(" ");
                }
            }
            foreach (var period in periodModels)
            {
                if (period != null && (period.EndDate.Date == monthCalendar.SelectionStart.Date))
                {
                    listBoxDay.Items.Add($" End of {period.Period}");
                    listBoxDay.Items.Add(" ");
                }
            }


            //listBoxDay.Visible = hasEvents || hasProjects || hasPeriods;
        }

        private async void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new EventsRegister(dysfunctionForm));
            panel3.BorderStyle = BorderStyle.FixedSingle;
            await Task.Delay(100);
            panel3.BorderStyle = BorderStyle.None;
        }


        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(20, 20, 20);

        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(0, 0, 0);
        }


        private void ProjectConsult_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.FromArgb(0, 0, 0);
            panel2.BackColor = Color.FromArgb(0, 0, 0);
        }

        private async void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new EventsEdit(dysfunctionForm));
            panel2.BorderStyle = BorderStyle.FixedSingle;
            await Task.Delay(100);
            panel2.BorderStyle = BorderStyle.None;
        }

        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void Calendar_MouseDown(object sender, MouseEventArgs e)
        {
            listBoxDay.ClearSelected();
            listBoxWeek.ClearSelected();
        }
    }
}
