using Microsoft.Win32;
using OpenXR_Runtime_Switcher.Runtimes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenXR_Runtime_Switcher
{
    public class RuntimeManager
    {
        private const string OpenXRMajorApiVersion = "1";
        private const string OpenXRKey = @"HKEY_LOCAL_MACHINE\SOFTWARE\Khronos\OpenXR\" + OpenXRMajorApiVersion;
        private const string OpenXRValue = "ActiveRuntime";
        private MainForm MainForm_Ref;


        // Presets
        public List<IOpenXRRuntime> PresetRuntimes;
        public List<IOpenXRRuntime> FoundRuntimes;

        // Customs
        public List<IOpenXRRuntime> CustomRuntimes;
        public List<IOpenXRRuntime> FoundCustomRuntimes;


        public IOpenXRRuntime ActiveRuntime = null;

        private string activeRuntimePath = String.Empty;

        public RuntimeManager(MainForm mainForm)
        {
            MainForm_Ref = mainForm;

            Refresh();
        }

        public List<RuntimeEntryControl> GetEntryListPresets()
        {
            List<RuntimeEntryControl> PresetControlsList = new List<RuntimeEntryControl>();

            foreach (IOpenXRRuntime runtime in PresetRuntimes)
            {
                PresetControlsList.Add(new RuntimeEntryControl(MainForm_Ref, runtime, false));
            }

            PresetControlsList = PresetControlsList.OrderBy(x => x.UCRuntime.Status).ThenBy(x => x.UCRuntime.Name).ToList();

            return PresetControlsList;
        }

        public List<RuntimeEntryControl> GetEntryListCustoms()
        {
            List<RuntimeEntryControl> CustomControlsList = new List<RuntimeEntryControl>();

            foreach (IOpenXRRuntime runtime in CustomRuntimes)
            {
                CustomControlsList.Add(new RuntimeEntryControl(MainForm_Ref, runtime, true));
            }

            CustomControlsList = CustomControlsList.OrderBy(x => x.UCRuntime.Status).ThenBy(x => x.UCRuntime.Name).ToList();

            return CustomControlsList;
        }

        public void Refresh()
        {

            activeRuntimePath = GetActiveRuntimeJsonPath();
            
            
            // ############### Presets ###############
            
            PresetRuntimes = new List<IOpenXRRuntime>
            {
                new Runtime_WMR(),
                new Runtime_SteamVR(),
                new Runtime_Oculus(),
                new Runtime_ViveVR(),
                new Runtime_Varjo(),
            };
            
            FoundRuntimes = PresetRuntimes
                .Select(FindRuntime)
                .Where(e => e.result)
                .Select(e => e.runtime)
                .ToList();

            // Update UC for all Preset Runtimes
            foreach (IOpenXRRuntime runtime in PresetRuntimes)
            {
                // Update Status
                if (FoundRuntimes.Contains(runtime))
                {
                    if (runtime.JsonPath.ToLower() == activeRuntimePath.ToLower())
                    {
                        runtime.Status = ControlStatusType.Active;
                    }
                    else
                    {
                        runtime.Status = ControlStatusType.Installed;
                    }
                }
                else
                {
                    runtime.Status = ControlStatusType.NotInstalled;
                }
            }


            // ############### Customs ###############
            CustomRuntimes = new List<IOpenXRRuntime>();

            foreach (CustomRuntimeSaveListEntry entry in MainForm_Ref.customRuntimeSaveListEntries)
            {
                Image img;
                if (String.IsNullOrWhiteSpace(entry.ImagePath))
                {
                    img = Properties.Resources.Logo_NoLogo;
                }
                else
                {
                    try
                    {
                        img = Image.FromFile(entry.ImagePath);
                    }
                    catch (Exception)
                    {
                        img = Properties.Resources.Logo_NoLogo;
                    }
                }
                Runtime_Custom cstmRuntime = new Runtime_Custom() { Name=entry.Name, JsonPath=entry.JsonPath, Logo=img, Status=ControlStatusType.NotInstalled };
                CustomRuntimes.Add(cstmRuntime);
            }

            FoundCustomRuntimes = CustomRuntimes
                .Select(FindRuntime)
                .Where(e => e.result)
                .Select(e => e.runtime)
                .ToList();

            // Update UC for all Custom Runtimes
            foreach (IOpenXRRuntime runtime in CustomRuntimes)
            {
                // Update Status
                if (FoundCustomRuntimes.Contains(runtime))
                {
                    if (runtime.JsonPath.ToLower() == activeRuntimePath.ToLower())
                    {
                        runtime.Status = ControlStatusType.Active;
                    }
                    else
                    {
                        runtime.Status = ControlStatusType.Installed;
                    }
                }
                else
                {
                    runtime.Status = ControlStatusType.NotInstalled;
                }
            }
        }

        private static (bool result, string path, IOpenXRRuntime runtime) FindRuntime(IOpenXRRuntime e)
        {
            bool result = e.TryGetJsonPath(out var path);
            
            return (result, path, e);
        }

        public string GetActiveRuntimeJsonPath()
        {
            var pathValue = Registry.GetValue(OpenXRKey, OpenXRValue, string.Empty);
            if (pathValue is string path && !string.IsNullOrWhiteSpace(path))
            {
                if (File.Exists(path))
                {
                    return Path.GetFullPath(path);
                }
            }

            return String.Empty;
        }


        // Needs Administrator rights!
        public static void TrySetActiveRuntimeJsonPath(string jsonPath)
        {
            Registry.SetValue(OpenXRKey, OpenXRValue, jsonPath, RegistryValueKind.ExpandString);
        }

    }
}
