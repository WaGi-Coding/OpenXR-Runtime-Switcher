using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXR_Runtime_Switcher
{
    [Serializable]
    public struct CustomRuntimeSaveListEntry
    {
        public string Name { get; set; }
        public string JsonPath { get; set; }
        public string ImagePath { get; set; }

        public CustomRuntimeSaveListEntry(string name, string jsonPath, string imagePath)
        {
            Name = name;
            JsonPath = jsonPath;
            ImagePath = imagePath;
        }
    }
}
