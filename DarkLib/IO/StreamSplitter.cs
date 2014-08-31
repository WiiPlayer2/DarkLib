using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.IO
{
    /// <summary>
    /// Proxy stream which outputs its content to multiple streams.
    /// </summary>
    public class StreamSplitter : Stream
    {
        Stream[] streams;

        /// <summary>
        /// Initializes a new instance of the <see cref="StreamSplitter"/> class.
        /// </summary>
        /// <param name="outputStreams">The output streams.</param>
        public StreamSplitter(params Stream[] outputStreams)
        {
            streams = outputStreams;
        }

        /// <summary>
        /// Ruft beim Überschreiben in einer abgeleiteten Klasse einen Wert ab, der angibt, ob der aktuelle Stream Lesevorgänge unterstützt.
        /// </summary>
        /// <returns>true, wenn der Stream Lesevorgänge unterstützt, andernfalls false.</returns>
        public override bool CanRead
        {
            get { return false; }
        }

        /// <summary>
        /// Ruft beim Überschreiben in einer abgeleiteten Klasse einen Wert ab, der angibt, ob der aktuelle Stream Suchvorgänge unterstützt.
        /// </summary>
        /// <returns>true, wenn der Stream Suchvorgänge unterstützt, andernfalls false.</returns>
        public override bool CanSeek
        {
            get { return false; }
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
            foreach (var s in streams)
            {
                s.Flush();
            }
        }

        /// <summary>
        /// Ruft beim Überschreiben in einer abgeleiteten Klasse die Länge des Streams in Bytes ab.
        /// </summary>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <returns>Ein Long-Wert, der die Länge des Streams in Bytes darstellt.</returns>
        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Ruft beim Überschreiben in einer abgeleiteten Klasse die Position im aktuellen Stream ab oder legt diese fest.
        /// </summary>
        /// <exception cref="System.NotSupportedException">
        /// </exception>
        /// <returns>Die aktuelle Position innerhalb des Streams.</returns>
        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
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
        /// <exception cref="System.NotSupportedException"></exception>
        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Legt beim Überschreiben in einer abgeleiteten Klasse die Position im aktuellen Stream fest.
        /// </summary>
        /// <param name="offset">Ein Byteoffset relativ zum <paramref name="origin" />-Parameter.</param>
        /// <param name="origin">Ein Wert vom Typ <see cref="T:System.IO.SeekOrigin" />, der den Bezugspunkt angibt, von dem aus die neue Position ermittelt wird.</param>
        /// <returns>
        /// Die neue Position innerhalb des aktuellen Streams.
        /// </returns>
        /// <exception cref="System.NotSupportedException"></exception>
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Legt beim Überschreiben in einer abgeleiteten Klasse die Länge des aktuellen Streams fest.
        /// </summary>
        /// <param name="value">Die gewünschte Länge des aktuellen Streams in Bytes.</param>
        /// <exception cref="System.NotSupportedException"></exception>
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Schreibt beim Überschreiben in einer abgeleiteten Klasse eine Folge von Bytes in den aktuellen Stream und erhöht die aktuelle Position im Stream um die Anzahl der geschriebenen Bytes.
        /// </summary>
        /// <param name="buffer">Ein Bytearray.Diese Methode kopiert <paramref name="count" /> Bytes aus dem <paramref name="buffer" /> in den aktuellen Stream.</param>
        /// <param name="offset">Der nullbasierte Byteoffset im <paramref name="buffer" />, ab dem Bytes in den aktuellen Stream kopiert werden.</param>
        /// <param name="count">Die Anzahl an Bytes, die in den aktuellen Stream geschrieben werden sollen.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            foreach (var s in streams)
            {
                s.Write(buffer, offset, count);
            }
        }

        /// <summary>
        /// Schließt den aktuellen Stream und gibt alle dem aktuellen Stream zugeordneten Ressourcen frei (z. B. Sockets und Dateihandles).
        /// </summary>
        public override void Close()
        {
            foreach (var s in streams)
            {
                s.Close();
            }
        }
    }
}
