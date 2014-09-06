using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// Creates a virtual filestream for non blocking access.
    /// </summary>
    public class NotBlockingFileStream : Stream
    {
        private FileStream stream;
        private long length;
        private long position;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotBlockingFileStream"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public NotBlockingFileStream(string filename)
        {
            Filename = filename;
        }

        /// <summary>
        /// Gets the filename.
        /// </summary>
        /// <value>
        /// The filename.
        /// </value>
        public string Filename { get; private set; }

        /// <summary>
        /// Ruft beim Überschreiben in einer abgeleiteten Klasse einen Wert ab, der angibt, ob der aktuelle Stream Lesevorgänge unterstützt.
        /// </summary>
        /// <returns>true, wenn der Stream Lesevorgänge unterstützt, andernfalls false.</returns>
        public override bool CanRead
        {
            get { return true; }
        }

        /// <summary>
        /// Ruft beim Überschreiben in einer abgeleiteten Klasse einen Wert ab, der angibt, ob der aktuelle Stream Suchvorgänge unterstützt.
        /// </summary>
        /// <returns>true, wenn der Stream Suchvorgänge unterstützt, andernfalls false.</returns>
        public override bool CanSeek
        {
            get { return true; }
        }

        /// <summary>
        /// Ruft beim Überschreiben in einer abgeleiteten Klasse einen Wert ab, der angibt, ob der aktuelle Stream Schreibvorgänge unterstützt.
        /// </summary>
        /// <returns>true, wenn der Stream Schreibvorgänge unterstützt, andernfalls false.</returns>
        public override bool CanWrite
        {
            get { return true; }
        }

        /// <summary>
        /// Löscht beim Überschreiben in einer abgeleiteten Klasse alle Puffer für diesen Stream und veranlasst die Ausgabe aller gepufferten Daten an das zugrunde liegende Gerät.
        /// </summary>
        public override void Flush()
        {
            if (stream != null)
            {
                stream.Flush();
                stream.Close();
                stream = null;
            }
            else
            {
                Debug.WriteLine("WARNING: Flush without open stream");
            }
        }

        /// <summary>
        /// Ruft beim Überschreiben in einer abgeleiteten Klasse die Länge des Streams in Bytes ab.
        /// </summary>
        /// <returns>Ein Long-Wert, der die Länge des Streams in Bytes darstellt.</returns>
        public override long Length
        {
            get
            {
                if (stream != null)
                {
                    Refresh();
                }
                return length;
            }
        }

        /// <summary>
        /// Ruft beim Überschreiben in einer abgeleiteten Klasse die Position im aktuellen Stream ab oder legt diese fest.
        /// </summary>
        /// <returns>Die aktuelle Position innerhalb des Streams.</returns>
        public override long Position
        {
            get
            {
                if (stream != null)
                {
                    Refresh();
                }
                return position;
            }
            set
            {
                if (stream != null)
                {
                    stream.Position = value;
                }
                position = value;
            }
        }

        /// <summary>
        /// Liest beim Überschreiben in einer abgeleiteten Klasse eine Folge von Bytes aus dem aktuellen Stream und erhöht die Position im Stream um die Anzahl der gelesenen Bytes.
        /// </summary>
        /// <param name="buffer">Ein Bytearray.Nach dem Beenden dieser Methode enthält der Puffer das angegebene Bytearray mit den Werten zwischen <paramref name="offset" /> und (<paramref name="offset" /> + <paramref name="count" /> - 1), die durch aus der aktuellen Quelle gelesene Bytes ersetzt wurden.</param>
        /// <param name="offset">Der nullbasierte Byteoffset im <paramref name="buffer" />, ab dem die aus dem aktuellen Stream gelesenen Daten gespeichert werden.</param>
        /// <param name="count">Die maximale Anzahl an Bytes, die aus dem aktuellen Stream gelesen werden sollen.</param>
        /// <returns>
        /// Die Gesamtanzahl der in den Puffer gelesenen Bytes.Dies kann weniger als die Anzahl der angeforderten Bytes sein, wenn diese Anzahl an Bytes derzeit nicht verfügbar ist, oder 0, wenn das Ende des Streams erreicht ist.
        /// </returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            var wasOpen = stream != null;
            if (!wasOpen)
            {
                stream = File.Open(Filename, FileMode.OpenOrCreate);
                stream.Position = position;
            }

            var ret = stream.Read(buffer, offset, count);
            Refresh();

            if (!wasOpen)
            {
                stream.Close();
                stream = null;
            }

            return ret;
        }

        /// <summary>
        /// Legt beim Überschreiben in einer abgeleiteten Klasse die Position im aktuellen Stream fest.
        /// </summary>
        /// <param name="offset">Ein Byteoffset relativ zum <paramref name="origin" />-Parameter.</param>
        /// <param name="origin">Ein Wert vom Typ <see cref="T:System.IO.SeekOrigin" />, der den Bezugspunkt angibt, von dem aus die neue Position ermittelt wird.</param>
        /// <returns>
        /// Die neue Position innerhalb des aktuellen Streams.
        /// </returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            if (stream != null)
            {
                stream.Seek(offset, origin);
                Refresh();
            }
            else
            {
                switch (origin)
                {
                    case SeekOrigin.Begin:
                        position = offset;
                        break;
                    case SeekOrigin.Current:
                        position += offset;
                        break;
                    case SeekOrigin.End:
                        position = length + offset;
                        break;
                }
            }
            return position;
        }

        /// <summary>
        /// Legt beim Überschreiben in einer abgeleiteten Klasse die Länge des aktuellen Streams fest.
        /// </summary>
        /// <param name="value">Die gewünschte Länge des aktuellen Streams in Bytes.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Schreibt beim Überschreiben in einer abgeleiteten Klasse eine Folge von Bytes in den aktuellen Stream und erhöht die aktuelle Position im Stream um die Anzahl der geschriebenen Bytes.
        /// </summary>
        /// <param name="buffer">Ein Bytearray.Diese Methode kopiert <paramref name="count" /> Bytes aus dem <paramref name="buffer" /> in den aktuellen Stream.</param>
        /// <param name="offset">Der nullbasierte Byteoffset im <paramref name="buffer" />, ab dem Bytes in den aktuellen Stream kopiert werden.</param>
        /// <param name="count">Die Anzahl an Bytes, die in den aktuellen Stream geschrieben werden sollen.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (stream == null)
            {
                stream = File.Open(Filename, FileMode.OpenOrCreate);
                stream.Position = position;
            }

            stream.Write(buffer, offset, count);
            Refresh();
        }

        private void Refresh()
        {
            position = stream.Position;
            length = stream.Length;
        }
    }
}
