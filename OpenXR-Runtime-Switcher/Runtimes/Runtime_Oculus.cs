// Copyright 2021 KOGA Mitsuhiro Authors. All rights reserved.
// Use of this source code is governed by a MIT-style
// license that can be found in the LICENSE file.

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
    internal class Runtime_Oculus : IOpenXRRuntime
    {
        private string name = "Oculus";
        private string jsonPath = String.Empty;
        private ControlStatusType? status = ControlStatusType.NotInstalled;
        private Image logo = Properties.Resources.Logo_Oculus;


        private const string InstallLocKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Oculus";
        private const string InstallLocValue = "InstallLocation";
        private const string JsonName = @"Support\oculus-runtime\oculus_openxr_64.json";

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
            var oculusPathValue = Registry.GetValue(InstallLocKey, InstallLocValue, string.Empty);
            if (oculusPathValue is string oculusPath && !string.IsNullOrWhiteSpace(oculusPath))
            {
                var path = Path.Combine(oculusPath, JsonName);
                if (File.Exists(path))
                {
                    jsonPath = Path.GetFullPath(path);
                    JsonPath = jsonPath;
                    return true;
                }
            }

            jsonPath = String.Empty;
            JsonPath = jsonPath;
            return false;
        }
    }
}
