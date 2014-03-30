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
            CopyTo(bitmap, toBitmap, 0, 0, bitmap.Width, bitmap.Height, x, y);
        }

        /// <summary>
        /// Copies to.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <param name="toBitmap">To bitmap.</param>
        /// <param name="sourceX">The x source.</param>
        /// <param name="sourceY">The y source.</param>
        /// <param name="sourceWidth">The width source.</param>
        /// <param name="sourceHeight">The height source.</param>
        /// <param name="destinationX">The x destination.</param>
        /// <param name="destinationY">The y destination.</param>
        public static void CopyTo(this Bitmap bitmap, Bitmap toBitmap, int sourceX, int sourceY, int sourceWidth, int sourceHeight, int destinationX, int destinationY)
        {
            for (var xs = sourceX; xs < sourceWidth + sourceX; xs++)
            {
                for (var ys = sourceY; ys < sourceHeight + sourceY; ys++)
                {
                    if (xs + destinationX < toBitmap.Width
                        && xs + destinationX >= 0
                        && ys + destinationY < toBitmap.Height
                        && ys + destinationY >= 0)
                    {
                        toBitmap.SetPixel(xs + destinationX, ys + destinationY, bitmap.GetPixel(xs, ys));
                    }
                }
            }
        }

        /// <summary>
        /// Mirrors the vertical.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns>The mirrored bitmap.</returns>
        public static Bitmap MirrorVertical(this Bitmap bitmap)
        {
            var ret = new Bitmap(bitmap.Width, bitmap.Height);
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    ret.SetPixel(x, bitmap.Height - 1 - y, bitmap.GetPixel(x, y));
                }
            }

            return ret;
        }

        /// <summary>
        /// Mirrors the horizontal.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns>The mirrored bitmap.</returns>
        public static Bitmap MirrorHorizontal(this Bitmap bitmap)
        {
            var ret = new Bitmap(bitmap.Width, bitmap.Height);
            for (var x = 0; x < bitmap.Width; x++)
            {
                for (var y = 0; y < bitmap.Height; y++)
                {
                    ret.SetPixel(bitmap.Width - x - 1, y, bitmap.GetPixel(x, y));
                }
            }

            return ret;
        }
    }
}
