//-----------------------------------------------------------------------
// <copyright file="BinaryReaderEx.cs" company="DarkInc">
//     Copyright (c) DarkInc, WiiPlayer2 (Waldemar Tomme). All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Linq;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// BinaryReader with Little- and BigEndian support.
    /// </summary>
    public class BinaryReaderEx : BinaryReader
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
        /// Initializes a new instance of the <see cref="BinaryReaderEx"/> class.
        /// </summary>
        /// <param name="input">Ein Stream.</param>
        public BinaryReaderEx(Stream input)
            : base(input)
        {
            this.UseLittleEndian = BitConverter.IsLittleEndian;
            this.enc = Encoding.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryReaderEx"/> class.
        /// </summary>
        /// <param name="input">Der bereitgestellte Stream.</param>
        /// <param name="encoding">Die Zeichencodierung.</param>
        public BinaryReaderEx(Stream input, Encoding encoding)
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

        /// <summary>
        /// Liest einen Dezimalwert aus dem aktuellen Stream und erhöht die aktuelle Position im Stream um 16 Bytes.
        /// </summary>
        /// <returns>
        /// Ein aus dem aktuellen Stream gelesener Dezimalwert.
        /// </returns>
        public override decimal ReadDecimal()
        {
            if (this.c)
            {
                throw new NotImplementedException();
            }

            return base.ReadDecimal();
        }

        /// <summary>
        /// Liest einen 8-Byte-Gleitkomthis.mawert aus dem aktuellen Stream und erhöht die aktuelle Position im Stream um 8 Bytes.
        /// </summary>
        /// <returns>
        /// Ein aus dem aktuellen Stream gelesener 8-Byte-Gleitkommawert.
        /// </returns>
        public override double ReadDouble()
        {
            if (this.c)
            {
                return BitConverter.ToDouble(this.ReadReverse(8), 0);
            }

            return base.ReadDouble();
        }

        /// <summary>
        /// Liest eine 2-Byte-Ganzzahl mit Vorzeichen aus dem aktuellen Stream und erhöht die aktuelle Position im Stream um 2 Bytes.
        /// </summary>
        /// <returns>
        /// Eine aus dem aktuellen Stream gelesene 2-Byte-Ganzzahl mit Vorzeichen.
        /// </returns>
        public override short ReadInt16()
        {
            if (this.c)
            {
                return BitConverter.ToInt16(this.ReadReverse(2), 0);
            }

            return base.ReadInt16();
        }

        /// <summary>
        /// Liest eine 4-Byte-Ganzzahl mit Vorzeichen aus dem aktuellen Stream und erhöht die aktuelle Position im Stream um 4 Bytes.
        /// </summary>
        /// <returns>
        /// Eine aus dem aktuellen Stream gelesene 4-Byte-Ganzzahl mit Vorzeichen.
        /// </returns>
        public override int ReadInt32()
        {
            if (this.c)
            {
                return BitConverter.ToInt32(this.ReadReverse(4), 0);
            }

            return base.ReadInt32();
        }

        /// <summary>
        /// Liest eine 8-Byte-Ganzzahl mit Vorzeichen aus dem aktuellen Stream und erhöht die aktuelle Position im Stream um 8 Bytes.
        /// </summary>
        /// <returns>
        /// Eine aus dem aktuellen Stream gelesene 8-Byte-Ganzzahl mit Vorzeichen.
        /// </returns>
        public override long ReadInt64()
        {
            if (this.c)
            {
                return BitConverter.ToInt64(this.ReadReverse(8), 0);
            }

            return base.ReadInt64();
        }

        /// <summary>
        /// Liest einen 4-Byte-Gleitkommawert aus dem aktuellen Stream und erhöht die aktuelle Position im Stream um 4 Bytes.
        /// </summary>
        /// <returns>
        /// Ein aus dem aktuellen Stream gelesener 4-Byte-Gleitkommawert.
        /// </returns>
        public override float ReadSingle()
        {
            if (this.c)
            {
                return BitConverter.ToSingle(this.ReadReverse(4), 0);
            }

            return base.ReadSingle();
        }

        /// <summary>
        /// Liest eine 2-Byte-Ganzzahl ohne Vorzeichen mithilfe einer Little-Endian-Codierung aus dem aktuellen Stream und erhöht die aktuelle Position im Stream um 2 Bytes.
        /// </summary>
        /// <returns>
        /// Eine aus diesem Stream gelesene 2-Byte-Ganzzahl ohne Vorzeichen.
        /// </returns>
        public override ushort ReadUInt16()
        {
            if (this.c)
            {
                return BitConverter.ToUInt16(this.ReadReverse(2), 0);
            }

            return base.ReadUInt16();
        }

        /// <summary>
        /// Liest eine 4-Byte-Ganzzahl ohne Vorzeichen aus dem aktuellen Stream und erhöht die aktuelle Position im Stream um 4 Bytes.
        /// </summary>
        /// <returns>
        /// Eine aus diesem Stream gelesene 4-Byte-Ganzzahl ohne Vorzeichen.
        /// </returns>
        public override uint ReadUInt32()
        {
            if (this.c)
            {
                return BitConverter.ToUInt32(this.ReadReverse(4), 0);
            }

            return base.ReadUInt32();
        }

        /// <summary>
        /// Liest eine 8-Byte-Ganzzahl ohne Vorzeichen aus dem aktuellen Stream und erhöht die aktuelle Position im Stream um 8 Bytes.
        /// </summary>
        /// <returns>
        /// Eine aus diesem Stream gelesene 8-Byte-Ganzzahl ohne Vorzeichen.
        /// </returns>
        public override ulong ReadUInt64()
        {
            if (this.c)
            {
                return BitConverter.ToUInt64(this.ReadReverse(8), 0);
            }

            return base.ReadUInt64();
        }

        /// <summary>
        /// Reads the reverse.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>Reversed bytes.</returns>
        private byte[] ReadReverse(int count)
        {
            return ReadBytes(count).Reverse().ToArray();
        }
    }
}