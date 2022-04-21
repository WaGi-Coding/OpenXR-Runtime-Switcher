using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenXR_Runtime_Switcher
{
    public partial class Form_AddCustomRuntime : Form
    {
        MainForm mainForm;

        public CustomRuntimeSaveListEntry EntryToAdd = new CustomRuntimeSaveListEntry("", "", "");


        public Form_AddCustomRuntime(MainForm mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
        }

        private void pictureBoxLogo_Click(object sender, EventArgs e)
        {
            this.openFileDialogLogo.Filter = "Image Files (*.PNG;*.JPG;*.JPEG)|*PNG;*.JPG;*.JPEG";
            this.openFileDialogLogo.RestoreDirectory = true;
            this.openFileDialogLogo.Title = "Open an existing Image";
            var result = openFileDialogLogo.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBoxLogo.Image = Image.FromFile(openFileDialogLogo.FileName);
            }
        }

        private void btnSearchPath_Click(object sender, EventArgs e)
        {
            this.openFileDialogJsonPath.Filter = "OpenXR Runtime JSON File (*.JSON;)|*JSON;";
            this.openFileDialogJsonPath.RestoreDirectory = true;
            this.openFileDialogJsonPath.Title = "Open an existing Runtime JSON";
            var result = openFileDialogJsonPath.ShowDialog();
            if (result == DialogResult.OK)
            {
                tbPath.Text = openFileDialogJsonPath.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> errorMessages = new List<string>();

            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                errorMessages.Add("-| The Name cannot be empty.");
            }
            if (mainForm.rtm.CustomRuntimes.Select(x => x.Name).Contains(tbName.Text.ToLower(), StringComparer.OrdinalIgnoreCase))
            {
                errorMessages.Add("-| This Name is already in use by a custom Runtime.");
            }
            if (!string.IsNullOrWhiteSpace(tbPath.Text))
            {
                if (mainForm.rtm.PresetRuntimes.Select(x => x.JsonPath).Contains(tbPath.Text.ToLower(), StringComparer.OrdinalIgnoreCase))
                {
                    errorMessages.Add("-| This Json Path is already in use by a Preset.");
                }
            }
            else
            {
                errorMessages.Add("-| Json Path cannot be empty.");
            }
            if (mainForm.rtm.CustomRuntimes.Select(x => x.JsonPath).Contains(tbPath.Text.ToLower(), StringComparer.OrdinalIgnoreCase))
            {
                errorMessages.Add("-| This Json Path is already in use by a custom Runtime.");
            }
            if (!tbPath.Text.ToLower().EndsWith(".json"))
            {
                errorMessages.Add("-| This Json path has no \".json\" Extension.");
            }





            



            if (!File.Exists(tbImagePath.Text))
            {
                if (errorMessages.Count != 0)
                {
                    errorMessages.Add("-| Invalid Logo/Logo-Path!");
                }
                else
                {
                    if (MessageBox.Show("Invalid Logo/Logo-Path!" + "\n" + "Use default Logo instead?", "Add Custom Runtime", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        EntryToAdd.ImagePath = string.Empty;
                    }

                    else
                    {
                        return;
                    }
                }
            }


            FileInfo fi = null;

            if (File.Exists(tbImagePath.Text))
            {
                fi = new FileInfo(tbImagePath.Text);
                string ext = fi.Extension.ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg")
                {
                    if (errorMessages.Count != 0)
                    {
                        errorMessages.Add("-| Invalid Logo Extension!");
                    }
                    else
                    {
                        if (MessageBox.Show("Invalid Logo Extension!" + "\n" + "Use default Logo instead?", "Add Custom Runtime", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            EntryToAdd.ImagePath = string.Empty;
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    EntryToAdd.ImagePath = tbImagePath.Text;
                }
            }



            if (errorMessages.Count > 0)
            {
                MessageBox.Show("Cannot Add Runtime!\n\n\n" + string.Join("\n\n", errorMessages));
                return;
            }


            EntryToAdd.Name = tbName.Text;
            EntryToAdd.JsonPath = tbPath.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void openFileDialogLogo_FileOk(object sender, CancelEventArgs e)
        {
            tbImagePath.Text = openFileDialogLogo.FileName;
        }

        private void openFileDialogJsonPath_FileOk(object sender, CancelEventArgs e)
        {
            tbPath.Text = openFileDialogJsonPath.FileName;
        }
    }
}
