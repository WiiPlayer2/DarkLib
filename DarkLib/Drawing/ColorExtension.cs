﻿//-----------------------------------------------------------------------
// <copyright file="ColorExtension.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Drawing
{
    /// <summary>
    /// Contains extension methods for <see cref="System.Drawing.Color"/>.
    /// </summary>
    public static class ColorExtension
    {
        /// <summary>
        /// To the HSV color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>The HSV color.</returns>
        public static HsvColor ToHsvColor(this Color color)
        {
            var max = Math.Max(color.R, Math.Max(color.G, color.B));
            var min = Math.Min(color.R, Math.Min(color.G, color.B));

            var alpha = color.A / 255f;
            var hue = color.GetHue();
            var saturation = (max == 0) ? 0 : 1f - (1f * min / max);
            var value = max / 255f;

            return HsvColor.FromAhsv(alpha, hue, saturation, value);
        }
    }
}
