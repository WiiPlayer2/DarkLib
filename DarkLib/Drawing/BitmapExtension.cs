//-----------------------------------------------------------------------
// <copyright file="BitmapExtension.cs" company="DarkInc">
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
    /// Contains extension methods for <see cref="System.Drawing.Bitmap"/>.
    /// </summary>
    public static class BitmapExtension
    {
        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="toBitmap">To bitmap.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public static void CopyTo(this Bitmap bitmap, Bitmap toBitmap, int x, int y)
        {
            for (var xs = 0; xs < bitmap.Width; xs++)
            {
                for (var ys = 0; ys < bitmap.Height; ys++)
                {
                    if (xs + x < toBitmap.Width
                        && xs + x >= 0
                        && ys + y < toBitmap.Height
                        && ys + y >= 0)
                    {
                        toBitmap.SetPixel(xs + x, ys + y, bitmap.GetPixel(xs, ys));
                    }
                }
            }
        }
    }
}
