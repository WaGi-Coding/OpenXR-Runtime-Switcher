// Copyright 2021 KOGA Mitsuhiro Authors. All rights reserved.
// Use of this source code is governed by a MIT-style
// license that can be found in the LICENSE file.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXR_Runtime_Switcher.Runtimes
{
    public interface IOpenXRRuntime
    {
        string Name { get; set; }
        string JsonPath { get; set; }
        ControlStatusType? Status { get; set; }
        Image Logo { get; set; }
        bool TryGetJsonPath(out string jsonPath);
    }
}
