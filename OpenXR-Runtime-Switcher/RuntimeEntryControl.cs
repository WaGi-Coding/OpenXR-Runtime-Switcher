using Newtonsoft.Json;
using OpenXR_Runtime_Switcher.Runtimes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenXR_Runtime_Switcher
{
    public partial class RuntimeEntryControl : UserControl
    {
        public IOpenXRRuntime UCRuntime = null;
        private MainForm mainForm = null;
        private bool isCustom = false;

        public RuntimeEntryControl()
        {
            MessageBox.Show("This Component is not meant to be initialized without parameters");
            InitializeComponent();

            InitializeUC(null);
        }

        public RuntimeEntryControl(MainForm mainForm, IOpenXRRuntime runtime, bool isCustom)
        {
            InitializeComponent();

            this.mainForm = mainForm;

            UCRuntime = runtime;

            this.isCustom = isCustom;

            InitializeUC(UCRuntime);

            
        }

        private void InitializeUC(IOpenXRRuntime runtime)
        {
            if (runtime == null)
            {
                pictureBox_RuntimeLogo.Image = Properties.Resources.Logo_NoLogo;

                btnHandle.Text = "Error in determining the Status";
                btnHandle.BackColor = Color.Red;
                btnHandle.Enabled = false;

                btnCopyPath.Enabled = false;
                tbPath.Enabled = false;

                return;
            }

            switch (runtime.Status)
            {
                case ControlStatusType.NotInstalled:
                    pictureBox_RuntimeLogo.Image = runtime.Logo;
                    lblRuntimeName.Text = runtime.Name;
                    tbPath.Text = runtime.JsonPath;

                    btnHandle.Text = "Runtime not installed or found";
                    btnHandle.BackColor = Color.DarkRed;
                    btnHandle.Enabled = false;

                    if (isCustom)
                    {
                        btnCopyPath.Enabled = true;
                        tbPath.Enabled = true;
                    }
                    else
                    {
                        btnCopyPath.Enabled = false;
                        tbPath.Enabled = false;
                    }
                    break;
                case ControlStatusType.Installed:
                    pictureBox_RuntimeLogo.Image = runtime.Logo;
                    lblRuntimeName.Text = runtime.Name;
                    tbPath.Text = runtime.JsonPath;

                    btnHandle.Text = "Switch to this Runtime";
                    btnHandle.BackColor = Color.DarkOrange;
                    btnHandle.Enabled = true;

                    btnCopyPath.Enabled = true;
                    tbPath.Enabled = true;
                    break;
                case ControlStatusType.Active:
                    pictureBox_RuntimeLogo.Image = runtime.Logo;
                    lblRuntimeName.Text = runtime.Name;
                    tbPath.Text = runtime.JsonPath;

                    btnHandle.Text = "This is the ACTIVE Runtime";
                    btnHandle.BackColor = Color.Green;
                    btnHandle.Enabled = false;

                    btnCopyPath.Enabled = true;
                    tbPath.Enabled = true;
                    break;
                default:
                    pictureBox_RuntimeLogo.Image = runtime.Logo;
                    lblRuntimeName.Text = "No Name";
                    tbPath.Text = String.Empty;

                    btnHandle.Text = "Error in determining the Status";
                    btnHandle.BackColor = Color.DarkRed;
                    btnHandle.Enabled = false;

                    if (isCustom)
                    {
                        btnCopyPath.Enabled = true;
                        tbPath.Enabled = true;
                    }
                    else
                    {
                        btnCopyPath.Enabled = false;
                        tbPath.Enabled = false;
                    }
                    break;
            }
        }

        private void btnCopyPath_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tbPath.Text))
            {
                Clipboard.SetDataObject(tbPath.Text);
            }
        }

        private void btnHandle_Click(object sender, EventArgs e)
        {
            try
            {
                RuntimeManager.TrySetActiveRuntimeJsonPath(UCRuntime.JsonPath);
                this.mainForm.RefreshPanels();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You need to run this Program as Administrator, in order to set a Runtime!");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when attempting to edit the Registry:\n" + ex.Message);
            }
        }

        private void tbPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                tbPath.SelectAll();
            }
        }

        private void tbPath_DoubleClick(object sender, EventArgs e)
        {
            tbPath.SelectAll();
        }

        private void RuntimeEntryControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (isCustom && mainForm.RemoveCustomModeOn && UCRuntime.Status != ControlStatusType.Active)
            {
                this.BackColor = Color.Red;
                Cursor.Current = Cursors.Hand;
            }
            else
            {
                this.BackColor = Color.DarkGray;
                Cursor.Current = Cursors.Default;
            }
        }

        private void RuntimeEntryControl_MouseLeave(object sender, EventArgs e)
        {
            if (isCustom)
            {
                this.BackColor = Color.DarkGray;
                Cursor.Current = Cursors.Default;
            }
        }

        private void RuntimeEntryControl_Click(object sender, EventArgs e)
        {
            if (isCustom && mainForm.RemoveCustomModeOn && UCRuntime.Status != ControlStatusType.Active)
            {
                Properties.Settings.Default.Reload();
                mainForm.customRuntimeSaveListEntries = JsonConvert.DeserializeObject<List<CustomRuntimeSaveListEntry>>(Properties.Settings.Default.CustomRuntimes);

                var entriesToRemove = mainForm.customRuntimeSaveListEntries.Where(x => x.Name == UCRuntime.Name && x.JsonPath == UCRuntime.JsonPath).ToList();

                if (entriesToRemove != null && entriesToRemove.Count() == 1)
                {
                    mainForm.customRuntimeSaveListEntries.Remove(entriesToRemove[0]);

                    Properties.Settings.Default.CustomRuntimes = JsonConvert.SerializeObject(mainForm.customRuntimeSaveListEntries);
                    Properties.Settings.Default.Save();

                    Cursor.Current = Cursors.Default;

                    mainForm.RemoveCustomModeOn = false;
                    mainForm.btnRemoveCustom.Text = "Remove";
                    mainForm.btnRemoveCustom.BackColor = Color.DarkRed;

                    mainForm.RefreshPanels();
                    //mainForm.flowLayoutPanelCustoms.Controls.Remove(this);

                }
                else
                {
                    MessageBox.Show("Error:\nCannot Remove!");
                }


            }

        }
    }
}
