using System;

namespace System.Windows.Media
{
    public static class ColorExtension
    {
        public static Color FadeTo(this Color @Color, Color toColor, float percent)
        {
            return Color.FromArgb(
                (byte)Lerp(@Color.A, toColor.A, percent),
                (byte)Lerp(@Color.R, toColor.R, percent),
                (byte)Lerp(@Color.G, toColor.G, percent),
                (byte)Lerp(@Color.B, toColor.B, percent));
        }

        private static float Lerp(float v0, float v1, float t)
        {
            return v0 + (v1 - v0) * t;
        }
    }
}