
using Dysfunction.GUI.Consult;
using Dysfunction.Logic;
using System.Globalization;
using System.Windows.Forms;
using Calendar = Dysfunction.GUI.Consult.Calendar;

namespace Dysfunction.GUI.Register
{
    public partial class EventsRegister : Form
    {
        eventsLogic eventsLogic = new eventsLogic();
        private Dysfunction dysfunctionForm;

        public EventsRegister(Dysfunction dysfunction)
        {
            InitializeComponent();
            dysfunctionForm = dysfunction;
            dysfunction.cache = 0;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
            hideLabels();
            panel3.Visible = false;
            panel4.Visible = false;
            dateTimePickerHour.ShowUpDown = true;

        }
        private void hideLabels()
        {
            labelName.Visible = false;

        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {

            if (eventsLogic.ValidNotNull(textBoxName.Text) && eventsLogic.ValidUniqueEvent(textBoxName.Text, dateTimePickerStartDate.Value))
            {
                
                if (checkBoxEndDate.Checked)
                {
                    if (checkBoxHour.Checked)
                    {
                        TimeSpan time = new TimeSpan(dateTimePickerHour.Value.TimeOfDay.Hours, dateTimePickerHour.Value.TimeOfDay.Minutes, 0);
                        eventsLogic.NewObject(eventsLogic.MakeAnID(), textBoxName.Text, textBoxDescription.Text, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, time);
                    }
                    else
                    {
                        eventsLogic.NewObject(eventsLogic.MakeAnID(), textBoxName.Text, textBoxDescription.Text, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, null);
                    }

                }
                else
                {
                    if (checkBoxHour.Checked)
                    {
                        TimeSpan time = new TimeSpan(dateTimePickerHour.Value.TimeOfDay.Hours, dateTimePickerHour.Value.TimeOfDay.Minutes, 0);
                        eventsLogic.NewObject(eventsLogic.MakeAnID(), textBoxName.Text, textBoxDescription.Text, dateTimePickerStartDate.Value, null, time);
                    }
                    else
                    {
                        eventsLogic.NewObject(eventsLogic.MakeAnID(), textBoxName.Text, textBoxDescription.Text, dateTimePickerStartDate.Value, null, null);
                    }
                }
                textBoxDescription.Text = "";
                textBoxName.Text = "";
                checkBoxHour.Checked = false;
                checkBoxEndDate.Checked = false;
                dateTimePickerStartDate.Value = DateTime.Now;
                dateTimePickerEndDate.Value = DateTime.Now;
                hideLabels();
                buttonSave.ForeColor = Color.LightGreen;
                buttonSave.Text = "Saved";
                await Task.Delay(2000);
                buttonSave.ForeColor = Color.White;
                buttonSave.Text = "Save";

            }
            else
            {
               
                if (!eventsLogic.ValidNotNull(textBoxName.Text))
                {
                    labelName.Visible = true;
                } 
                buttonSave.ForeColor = Color.Red;
                await Task.Delay(2000);
                buttonSave.ForeColor = Color.White;

            }
        }
        private void textBoxDescription_Click(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
        }


        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            if (!eventsLogic.ValidNotNull(textBoxName.Text) || !eventsLogic.ValidUniqueEvent(textBoxName.Text, dateTimePickerStartDate.Value))
            {
                labelName.Visible = true;
            }
            else
            {
                buttonSave.ForeColor = Color.White;
                labelName.Visible = false;
            }
        }
        private void textBoxName_Click(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
            labelName.Visible = false;
        }

        private void dateTimePickerStarDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEndDate.Value < dateTimePickerStartDate.Value)
            {
                dateTimePickerEndDate.Value = dateTimePickerStartDate.Value;
            }
            buttonSave.ForeColor = Color.White;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxEndDate.Checked)
            {
                panel3.Visible = true;
            }
            else
            {
                panel3.Visible = false;
            }
            buttonSave.ForeColor = Color.White;
        }

        private void checkBoxHour_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxHour.Checked)
            {
                panel4.Visible = true;
            }
            else
            {
                panel4.Visible = false;
            }
            buttonSave.ForeColor = Color.White;
        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEndDate.Value < dateTimePickerStartDate.Value)
            {
                dateTimePickerEndDate.Value = dateTimePickerStartDate.Value;
            }
            buttonSave.ForeColor = Color.White;
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
        }

        private void dateTimePickerHour_ValueChanged(object sender, EventArgs e)
        {
            buttonSave.ForeColor = Color.White;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dysfunctionForm.OpenNewForm(new Calendar(dysfunctionForm));
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(20, 20, 20);

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void ProjectRegister_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
        }

        private void CenterControl(Control ctrl)
        {
            ctrl.Left = (this.ClientSize.Width - ctrl.Width) / 2;
            ctrl.Top = (this.ClientSize.Height - ctrl.Height) / 2 - 20;
        }

        private void EventsRegister_Resize(object sender, EventArgs e)
        {
            CenterControl(panel8);
        }
    }
}
  