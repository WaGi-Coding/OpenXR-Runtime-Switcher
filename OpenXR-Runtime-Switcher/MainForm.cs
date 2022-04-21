using Microsoft.Win32;
using OpenXR_Runtime_Switcher.Runtimes;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Diagnostics;
using System.Net.Http;

namespace OpenXR_Runtime_Switcher
{
    public partial class MainForm : Form
    {
        private List<RuntimeEntryControl> PresetUCControls = new List<RuntimeEntryControl>();
        private List<RuntimeEntryControl> CustomUCControls = new List<RuntimeEntryControl>();

        public RuntimeManager rtm;

        public List<CustomRuntimeSaveListEntry> customRuntimeSaveListEntries = new List<CustomRuntimeSaveListEntry>();

        public bool RemoveCustomModeOn = false;

        public MainForm()
        {
            InitializeComponent();

            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.Text = "OpenXR Runtime-Switcher | v" + TrimTheEnd(version, ".0");

            Application.EnableVisualStyles();

            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }




            // ########### Desirialize Settings ###########

            // Custom Runtimes
            customRuntimeSaveListEntries = JsonConvert.DeserializeObject<List<CustomRuntimeSaveListEntry>>(Properties.Settings.Default.CustomRuntimes);

            // ############################################




            rtm = new RuntimeManager(this);
            RefreshPanels();


            // Fake Label Focus to get rid of initially focusing the first entries path textbox
            //this.ActiveControl = label1;
            //label1.Focus();
        }

        public static string FirstLetterToUpperCaseOrConvertNullToEmptyString(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public void RefreshPanels()
        {
            Properties.Settings.Default.Reload();
            customRuntimeSaveListEntries = JsonConvert.DeserializeObject<List<CustomRuntimeSaveListEntry>>(Properties.Settings.Default.CustomRuntimes);

            if (rtm != null)
            {
                rtm.Refresh();

                // Presets
                flowLayoutPanelPresets.Controls.Clear();
                PresetUCControls = new List<RuntimeEntryControl>();

                foreach (RuntimeEntryControl REC in rtm.GetEntryListPresets())
                {
                    PresetUCControls.Add(REC);
                }

                foreach (RuntimeEntryControl REC in PresetUCControls)
                {
                    flowLayoutPanelPresets.Controls.Add(REC);
                }



                // Customs
                flowLayoutPanelCustoms.Controls.Clear();
                CustomUCControls = new List<RuntimeEntryControl>();

                foreach (RuntimeEntryControl REC in rtm.GetEntryListCustoms())
                {
                    CustomUCControls.Add(REC);
                }

                foreach (RuntimeEntryControl REC in CustomUCControls)
                {
                    flowLayoutPanelCustoms.Controls.Add(REC);
                }

                // Fake Label Focus to get rid of initially focusing the first entries path textbox
                this.ActiveControl = label1;
                label1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            var xxx = JsonConvert.DeserializeObject<List<CustomRuntimeSaveListEntry>>(Properties.Settings.Default.CustomRuntimes); ;

            var yyy = new CustomRuntimeSaveListEntry($"Test {customRuntimeSaveListEntries.Count + 1}", @"C:\TestPath\test.json", @"C:\Users\Taki\Pictures\crowlchling.png");

            xxx.Add(yyy);

            Properties.Settings.Default.CustomRuntimes = JsonConvert.SerializeObject(xxx);
            Properties.Settings.Default.Save();

            RefreshPanels();

        }

        public bool SamePaths(string p1, string p2)
        {
            string path1 = p1;
            string path2 = p2;
            if (Path.IsPathRooted(path1) && Path.IsPathRooted(path2))
            {
                path1 = FirstLetterToUpperCaseOrConvertNullToEmptyString(p1);
                path2 = FirstLetterToUpperCaseOrConvertNullToEmptyString(p2);
            }

            if (path1 == path2)
            {
                return true;
            }

            return false;
        }

        public string TrimTheEnd(string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString)) return target;

            string result = target;
            if (result.EndsWith(trimString))
            {
                result = result.Substring(0, result.Length - trimString.Length);
            }

            return result;
        }

        private void ToolStripMenuItem_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnRefreshAll_Click(object sender, EventArgs e)
        {
            RefreshPanels();
        }

        private void btnRemoveCustom_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelCustoms.Controls.Count < 1)
            {
                MessageBox.Show("There are no Custom Runtimes in the List to delete one of them.");
                return;
            }

            RemoveCustomModeOn = !RemoveCustomModeOn;
            if (RemoveCustomModeOn)
            {
                this.KeyPreview = true;
                btnRemoveCustom.Text = "Cancel";
                btnRemoveCustom.BackColor = Color.DarkOrange;
            }
            else
            {
                this.KeyPreview = false;
                btnRemoveCustom.Text = "Remove";
                btnRemoveCustom.BackColor = Color.DarkRed;
            }
        }

        private void btnAddCustom_Click(object sender, EventArgs e)
        {
            using (Form_AddCustomRuntime addCustomFrm = new Form_AddCustomRuntime(this))
            {
                var result = addCustomFrm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    customRuntimeSaveListEntries.Add(addCustomFrm.EntryToAdd);
                    Properties.Settings.Default.CustomRuntimes = JsonConvert.SerializeObject(customRuntimeSaveListEntries);
                    Properties.Settings.Default.Save();
                    RefreshPanels();
                }
            }
        }

        private void WebsiteStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/WaGi-Coding/OpenXR-Runtime-Switcher/releases");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            customRuntimeSaveListEntries = JsonConvert.DeserializeObject<List<CustomRuntimeSaveListEntry>>(Properties.Settings.Default.CustomRuntimes);

            foreach (var item in customRuntimeSaveListEntries)
            {
                MessageBox.Show($"Name: {item.Name}\nJsonPath: {item.JsonPath}\nImagePath: {item.ImagePath}");
            }
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (RemoveCustomModeOn && e.KeyCode == Keys.Escape)
            {
                RemoveCustomModeOn = false;
                btnRemoveCustom.Text = "Remove";
                btnRemoveCustom.BackColor = Color.DarkRed;
            }
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            if (RemoveCustomModeOn)
            {
                RemoveCustomModeOn = false;
                btnRemoveCustom.Text = "Remove";
                btnRemoveCustom.BackColor = Color.DarkRed;
            }

            this.ActiveControl = label1;
            label1.Focus();
        }

        private void timerSplash_Tick(object sender, EventArgs e)
        {
            timerSplash.Enabled = false;
            this.Controls.Remove(panelSplash);
            CheckForUpdate(false);
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdate(true);
        }
        public async void CheckForUpdate(bool showInfoMessages)
        {
            try
            {
                long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");//Set the User Agent to "request"

                    using (HttpResponseMessage response = client.GetAsync("https://api.github.com/repos/WaGi-Coding/OpenXR-Runtime-Switcher/releases/latest?ts=" + timestamp.ToString()).Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        
                        string verStr = JObject.Parse(responseBody)["tag_name"].ToString();
                        Version ver = new Version(verStr);
                        
                        string appVerStr = Application.ProductVersion;
                        Version appVer = new Version(appVerStr);

                        bool needUpdate = ver.CompareTo(appVer) > 0;

                        if (needUpdate)
                        {
                            if (MessageBox.Show($"There is an Update available!\n\n\nNew Version: {ver}\n\nYour Version: {appVer}\n\n\nDo you want to visit the Download Page?", "Update available!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                Process.Start("https://github.com/WaGi-Coding/OpenXR-Runtime-Switcher/releases/latest");
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (showInfoMessages)
                            {
                                MessageBox.Show("You are using the newest Version!\n\nNo Update needed...");
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                if (showInfoMessages)
                {
                    MessageBox.Show("Error when checking for Update!");
                }
                // Ignore any errors on update check for the "on start update check"
            }

        }
    }
}
