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
    internal class Runtime_Varjo : IOpenXRRuntime
    {
        private string name = "Varjo";
        private string jsonPath = String.Empty;
        private ControlStatusType? status = ControlStatusType.NotInstalled;
        private Image logo = Properties.Resources.Logo_Varjo;

        private const string VarjoRuntimeKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Varjo\Runtime";
        private const string InstallDirKey = "InstallDir";
        private const string JsonName = @"varjo-openxr/VarjoOpenXR.json";


        public string Name
        {
            get => name;
            set
            {
                this.name = value;
            }
        }
        public string JsonPath
        {
            get => jsonPath;
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
            jsonPath = String.Empty;
            this.jsonPath = jsonPath;
            var varjoPathValue = Registry.GetValue(VarjoRuntimeKey, InstallDirKey, string.Empty);
            if (!(varjoPathValue is string vivePath))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(vivePath))
            {
                return false;
            }

            var path = Path.Combine(vivePath, JsonName);

            if (File.Exists(path))
            {
                jsonPath = Path.GetFullPath(path);
                this.jsonPath = jsonPath;
                return true;
            }

            return false;
        }
    }
}
