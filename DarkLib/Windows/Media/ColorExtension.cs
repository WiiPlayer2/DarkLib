//-----------------------------------------------------------------------
// <copyright file="ColorExtension.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace System.Windows.Media
{
    /// <summary>
    /// Contains extension methods for <see cref="System.Windows.Media.Color"/>.
    /// </summary>
    public static class ColorExtension
    {
        /// <summary>
        /// Fades to the given color.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="toColor">The given color.</param>
        /// <param name="percent">The percent.</param>
        /// <returns>Faded color.</returns>
        public static Color FadeTo(this Color color, Color toColor, float percent)
        {
            return Color.FromArgb(
                (byte)Lerp(color.A, toColor.A, percent),
                (byte)Lerp(color.R, toColor.R, percent),
                (byte)Lerp(color.G, toColor.G, percent),
                (byte)Lerp(color.B, toColor.B, percent));
        }

        /// <summary>
        /// Interpolates the specified values.
        /// </summary>
        /// <param name="v0">The first value.</param>
        /// <param name="v1">The second value.</param>
        /// <param name="t">The percentage.</param>
        /// <returns>Interpolated value</returns>
        private static float Lerp(float v0, float v1, float t)
        {
            return v0 + ((v1 - v0) * t);
        }
    }
}