//-----------------------------------------------------------------------
// <copyright file="HsvColor.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace System.Drawing
{
    /// <summary>
    /// Represent a color with HSV values.
    /// </summary>
    public struct HsvColor
    {
        /// <summary>
        /// Gets the alpha.
        /// </summary>
        /// <value>
        /// The alpha.
        /// </value>
        public float A { get; private set; }

        /// <summary>
        /// Gets the hue.
        /// </summary>
        /// <value>
        /// The hue.
        /// </value>
        public float H { get; private set; }

        /// <summary>
        /// Gets the saturation.
        /// </summary>
        /// <value>
        /// The saturation.
        /// </value>
        public float S { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public float V { get; private set; }

        /// <summary>
        /// Get a color from the given base color and alpha value.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="baseColor">Color of the base.</param>
        /// <returns>The HSV color.</returns>
        public static HsvColor FromAhsv(float alpha, HsvColor baseColor)
        {
            return FromAhsv(alpha, baseColor.H, baseColor.S, baseColor.V);
        }

        /// <summary>
        /// Get a color from the given HSV values.
        /// </summary>
        /// <param name="hue">The hue.</param>
        /// <param name="saturation">The saturation.</param>
        /// <param name="value">The value.</param>
        /// <returns>The HSV color</returns>
        public static HsvColor FromAhsv(float hue, float saturation, float value)
        {
            return FromAhsv(1, hue, saturation, value);
        }

        /// <summary>
        /// Get a color from the given AHSV values.
        /// </summary>
        /// <param name="alpha">The alpha.</param>
        /// <param name="hue">The hue.</param>
        /// <param name="saturation">The saturation.</param>
        /// <param name="value">The value.</param>
        /// <returns>The HSV color.</returns>
        public static HsvColor FromAhsv(float alpha, float hue, float saturation, float value)
        {
            return new HsvColor
            {
                A = alpha,
                H = hue,
                S = saturation,
                V = value
            };
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="HsvColor"/> to <see cref="Color"/>.
        /// </summary>
        /// <param name="hsvColor">Color of the HSV.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Color(HsvColor hsvColor)
        {
            return hsvColor.ToColor();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Color"/> to <see cref="HsvColor"/>.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator HsvColor(Color color)
        {
            return ColorExtension.ToHsvColor(color);
        }

        /// <summary>
        /// To the color.
        /// </summary>
        /// <returns>The color.</returns>
        public Color ToColor()
        {
            var hi = Convert.ToInt32(Math.Floor(this.H / 60)) % 6;
            var f = (this.H / 60) - Math.Floor(this.H / 60);

            var a = (int)(this.A * 255);
            this.V = this.V * 255;
            var v = (int)this.V;
            var p = (int)(this.V * (1 - this.S));
            var q = (int)(this.V * (1 - (f * this.S)));
            var t = (int)(this.V * (1 - ((1 - f) * this.S)));

            Color ret;
            if (hi == 0)
            {
                ret = Color.FromArgb(a, v, t, p);
            }
            else if (hi == 1)
            {
                ret = Color.FromArgb(a, q, v, p);
            }
            else if (hi == 2)
            {
                ret = Color.FromArgb(a, p, v, t);
            }
            else if (hi == 3)
            {
                ret = Color.FromArgb(a, p, q, v);
            }
            else if (hi == 4)
            {
                ret = Color.FromArgb(a, t, p, v);
            }
            else
            {
                ret = Color.FromArgb(a, v, p, q);
            }

            return ret;
        }
    }
}