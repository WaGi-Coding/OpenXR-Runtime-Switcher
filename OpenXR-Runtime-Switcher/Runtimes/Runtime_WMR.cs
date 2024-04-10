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
    internal class Runtime_WMR : IOpenXRRuntime
    {
        private string name = "Windows Mixed Reality";
        private string jsonPath = String.Empty;
        private ControlStatusType? status = ControlStatusType.NotInstalled;
        private Image logo = Properties.Resources.Logo_WMR;


        private const string JsonName = "MixedRealityRuntime.json";


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
            var systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            var path = Path.Combine(systemPath, JsonName);
            if (File.Exists(path))
            {
                jsonPath = Path.GetFullPath(path);
                this.jsonPath = jsonPath;
                return true;
            }

            jsonPath = String.Empty;
            this.jsonPath = jsonPath;
            return false;
        }
    }
}
