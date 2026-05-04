
using Dysfunction.GUI.Consult;
using Dysfunction.Logic;
using Dysfunction.Model;
using System.Globalization;
using System.Windows.Forms;
using Calendar = Dysfunction.GUI.Consult.Calendar;

namespace Dysfunction.GUI.Register
{
    public partial class EventsEdit : Form
    {
        eventsLogic eventsLogic = new eventsLogic();
        string nameSelection;
        private Dysfunction dysfunctionForm;
        int contador = 0;
        public EventsEdit(Dysfunction dysfunction)
        {
            InitializeComponent();
            dysfunctionForm = dysfunction;
            dysfunction.cache = 0;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
            hideLabels();
            FullComboName();
            panel3.Visible = false;
            panel4.Visible = false;
            dateTimePickerHour.ShowUpDown = true;
        }
        private void hideLabels()
        {
            labelName.Visible = false;

        }
        private void backDefault()
        {
            comboBoxName.SelectedIndex = -1;
            textBoxDescription.Text = "";
            checkBoxEndDate.Checked = false;
            checkBoxHour.Checked = false;
        }
        private void FullComboName()
        {
            comboBoxName.Items.Clear();
            List<eventsModel> eventsModels = eventsLogic.Consult();
            foreach (eventsModel events in eventsModels)
            {
                if (events != null)
                {
                    comboBoxName.Items.Add(events.Name);
                    comboBoxName.SelectedIndex = 0;
                }
                else
                {
                    labelName.Visible = true;
                }
            }
        }
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            if (nameSelection != null)
            {
                List<eventsModel> eventsModels = eventsLogic.Consult();
                var eventSelected = eventsModels.FirstOrDefault(events => events.Name == nameSelection);

                if (eventSelected != null)
                {
                    eventSelected.Description = textBoxDescription.Text;
                    eventSelected.StartDate = dateTimePickerStartDate.Value;

                    if (checkBoxEndDate.Checked)
                        eventSelected.EndDate = dateTimePickerEndDate.Value;

                    if (checkBoxHour.Checked)
                        eventSelected.Hour = dateTimePickerHour.Value.TimeOfDay;

                    eventsLogic.EditObject(eventSelected);
                    backDefault();
                    FullComboName();
                    buttonEdit.ForeColor = Color.LightGreen;
                    buttonEdit.Text = "Saved";
                    await Task.Delay(2000);
                    buttonEdit.ForeColor = Color.White;
                    buttonEdit.Text = "Save Edit";
                }
            }
            else
            {
                buttonEdit.ForeColor = Color.Red;
                await Task.Delay(2000);
                buttonEdit.ForeColor = Color.White;
            }

        }

        private async void buttonDelete_Click(object sender, EventArgs e)
        {
            List<eventsModel> eventsModels = eventsLogic.Consult();
            var eventSelected = eventsModels.FirstOrDefault(events => events.Name == nameSelection);
            if (eventSelected != null)
            {
                contador++;
                if (contador == 1)
                {
                    buttonDelete.ForeColor = Color.Yellow;
                    buttonDelete.FlatAppearance.MouseOverBackColor = Color.Black;
                    buttonDelete.Text = "Are you sure? Click again";
                    buttonDelete.FlatAppearance.BorderColor = Color.White;
                    await Task.Delay(2000);
                    buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                    await Task.Delay(2000);
                    buttonDelete.FlatAppearance.BorderColor = Color.White;
                    await Task.Delay(2000);
                    buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                    await Task.Delay(2000);
                    buttonDelete.FlatAppearance.BorderColor = Color.White;
                    await Task.Delay(2000);
                    buttonDelete.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                }
                if (contador == 2)
                { 
                    eventsLogic.DeleteObject(eventSelected);
                    backDefault();
                    FullComboName();
                    buttonDelete.ForeColor = Color.LightGreen;
                    buttonDelete.Text = "Deleted";
                    await Task.Delay(1000);
                    buttonDelete.ForeColor = Color.White;
                    buttonDelete.Text = "Delete";
                    buttonDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 20, 20);
                }
                

            }
            else
            {
                buttonDelete.ForeColor = Color.Red;
                await Task.Delay(2000);
                buttonDelete.ForeColor = Color.White;
            }

        }

        private void textBoxDescription_Click(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }

        private void dateTimePickerStarDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEndDate.Value < dateTimePickerStartDate.Value)
            {
                dateTimePickerEndDate.Value = dateTimePickerStartDate.Value;
            }
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
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
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
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
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }

        private void comboBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameSelection = comboBoxName.SelectedItem?.ToString();
            textBoxDescription.Enabled = true;
            dateTimePickerHour.Enabled = true;
            dateTimePickerStartDate.Enabled = true;
            dateTimePickerEndDate.Enabled = true;
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;

            List<eventsModel> eventsModels = eventsLogic.Consult();

            var eventSelected = eventsModels.FirstOrDefault(events => events.Name == nameSelection);

            if (eventSelected != null)
            {
                textBoxDescription.Text = eventSelected.Description;
                dateTimePickerStartDate.Value = eventSelected.StartDate;
                if (eventSelected.EndDate.HasValue)
                {
                    dateTimePickerEndDate.Value = eventSelected.EndDate.Value;
                }
                if (eventSelected.Hour.HasValue)
                {
                    DateTime dateTimeWithHour = DateTime.Today.Add(eventSelected.Hour.Value);
                    dateTimePickerHour.Value = dateTimeWithHour;
                }
            }

        }

        private void dateTimePickerEndDate_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerEndDate.Value < dateTimePickerStartDate.Value)
            {
                dateTimePickerEndDate.Value = dateTimePickerStartDate.Value;
            }
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
        }

        private void dateTimePickerHour_ValueChanged(object sender, EventArgs e)
        {
            buttonEdit.ForeColor = Color.White;
            buttonDelete.ForeColor = Color.White;
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

        private void EventsEdit_Resize(object sender, EventArgs e)
        {
            CenterControl(panel11);
        }
    }
}
  