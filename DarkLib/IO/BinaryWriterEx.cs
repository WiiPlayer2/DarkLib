//-----------------------------------------------------------------------
// <copyright file="BinaryWriterEx.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// BinaryWriter with Little- and BigEndian support.
    /// </summary>
    public class BinaryWriterEx : BinaryWriter
    {
        /// <summary>
        /// The c
        /// </summary>
        private bool c;

        /// <summary>
        /// The enc
        /// </summary>
        private Encoding enc;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryWriterEx"/> class.
        /// </summary>
        /// <param name="input">Ein Stream.</param>
        public BinaryWriterEx(Stream input)
            : base(input)
        {
            this.UseLittleEndian = BitConverter.IsLittleEndian;
            this.enc = Encoding.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryWriterEx"/> class.
        /// </summary>
        /// <param name="input">Der bereitgestellte Stream.</param>
        /// <param name="encoding">Die Zeichencodierung.</param>
        public BinaryWriterEx(Stream input, Encoding encoding)
            : base(input, encoding)
        {
            this.UseLittleEndian = BitConverter.IsLittleEndian;
            this.enc = encoding;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use little endian].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use little endian]; otherwise, <c>false</c>.
        /// </value>
        public bool UseLittleEndian
        {
            get
            {
                return !this.c && BitConverter.IsLittleEndian;
            }

            set
            {
                this.c = !(BitConverter.IsLittleEndian && value);
            }
        }

        public override void Write(int value)
        {
            if (this.c)
            {
                WriteReverse(BitConverter.GetBytes(value));
            }
            else
            {
                base.Write(value);
            }
        }

        /// <summary>
        /// Writes the reverse.
        /// </summary>
        /// <param name="data">The data.</param>
        private void WriteReverse(byte[] data)
        {
            Write(data.Reverse().ToArray());
        }
    }
}
