using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenXR_Runtime_Switcher.Runtimes
{
    internal class Runtime_Custom : IOpenXRRuntime
    {
        private string name = "Custom Runtime";
        private string jsonPath = String.Empty;
        private ControlStatusType? status = ControlStatusType.NotInstalled;
        private Image logo = Properties.Resources.Logo_NoLogo;

        public string Name
        {
            get => this.name;
            set
            {
                this.name = value;
            }
        }
        public string JsonPath
        {
            get => this.jsonPath;
            set
            {
                this.jsonPath = value;
            }
        }

        public ControlStatusType? Status
        {
            get => this.status;
            set
            {
                this.status = value;
            }
        }

        public Image Logo
        {
            get => this.logo;
            set
            {
                this.logo = value;
            }
        }

        public bool TryGetJsonPath(out string jsonPath)
        {
            string path = this.jsonPath;
            if (File.Exists(Path.Combine(path)))
            {
                jsonPath = Path.GetFullPath(path);
                JsonPath = jsonPath;
                return true;
            }

            jsonPath = Path.GetFullPath(path);
            return false;
        }
    }
}
