using System;
using System.Runtime.CompilerServices;
using System.Security;
using System.Threading;

namespace LocalDB.Document
{
    public class ObjectId : IComparable<ObjectId>, IEquatable<ObjectId>
    {
        #region Fields + Properties

        private static int _machine;
        private static short _pid;
        private static int _increment;

        public static ObjectId Empty => new ObjectId();
        public static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);


        public int Timestamp { get; private set; }
        public int Machine { get; private set; }
        public short Pid { get; private set; }
        public int Increment { get; private set; }
        public DateTime CreationTime
        {
            get { return UnixEpoch.AddSeconds(Timestamp); }
        }

        #endregion

        // Ctors

        public ObjectId()
        {
            Timestamp = 0;
            Machine = 0;
            Pid = 0;
            Increment = 0;
        }

        public ObjectId(int timestamp, int machine, short pid, int increment)
        {
            Timestamp = timestamp;
            Machine = machine;
            Pid = pid;
            Increment = increment;
        }

        public ObjectId(ObjectId from)
        {
            Timestamp = from.Timestamp;
            Machine = from.Machine;
            Pid = from.Pid;
            Increment = from.Increment;
        }

        public ObjectId(string value)
            : this(FromHex(value))
        {
        }

        public ObjectId(byte[] bytes)
        {
            if (bytes == null)
                throw new ArgumentNullException(nameof(bytes));

            if (bytes.Length != 12)
                throw new ArgumentException(nameof(bytes), "Byte array must be 12 bytes long");

            Timestamp = (bytes[0] << 24) + (bytes[1] << 16) + (bytes[2] << 8) + bytes[3];
            Machine = (bytes[4] << 16) + (bytes[5] << 8) + bytes[6];
            Pid = (short)((bytes[7] << 8) + bytes[8]);
            Increment = (bytes[9] << 16) + (bytes[10] << 8) + bytes[11];
        }

        // Public Methods

        public bool Equals(ObjectId other)
        {
            return other != null &&
                Timestamp == other.Timestamp &&
                Machine == other.Machine &&
                Pid == other.Pid &&
                Increment == other.Increment;
        }

        public override bool Equals(object other)
        {
            return Equals(other as ObjectId);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = 37 * hash + Timestamp.GetHashCode();
            hash = 37 * hash + Machine.GetHashCode();
            hash = 37 * hash + Pid.GetHashCode();
            hash = 37 * hash + Increment.GetHashCode();
            return hash;
        }

        public int CompareTo(ObjectId other)
        {
            var r = Timestamp.CompareTo(other.Timestamp);
            if (r != 0)
                return r;

            r = Machine.CompareTo(other.Machine);
            if (r != 0)
                return r;

            r = Pid.CompareTo(other.Pid);
            if (r != 0)
                return r < 0 ? -1 : 1;

            return Increment.CompareTo(other.Increment);
        }

        public byte[] ToByteArray()
        {
            var bytes = new byte[12];

            bytes[0] = (byte)(Timestamp >> 24);
            bytes[1] = (byte)(Timestamp >> 16);
            bytes[2] = (byte)(Timestamp >> 8);
            bytes[3] = (byte)(Timestamp);
            bytes[4] = (byte)(Machine >> 16);
            bytes[5] = (byte)(Machine >> 8);
            bytes[6] = (byte)(Machine);
            bytes[7] = (byte)(Pid >> 8);
            bytes[8] = (byte)(Pid);
            bytes[9] = (byte)(Increment >> 16);
            bytes[10] = (byte)(Increment >> 8);
            bytes[11] = (byte)(Increment);

            return bytes;
        }

        public override string ToString()
        {
            return BitConverter.ToString(ToByteArray()).Replace("-", "").ToLower();
        }

        // Operators

        public static bool operator ==(ObjectId lhs, ObjectId rhs)
        {
            if (lhs is null)
                return rhs is null;
            if (rhs is null)
                return false;

            return lhs.Equals(rhs);
        }

        public static bool operator !=(ObjectId lhs, ObjectId rhs)
        {
            return !(lhs == rhs);
        }

        public static bool operator >=(ObjectId lhs, ObjectId rhs)
        {
            return lhs.CompareTo(rhs) >= 0;
        }

        public static bool operator >(ObjectId lhs, ObjectId rhs)
        {
            return lhs.CompareTo(rhs) > 0;
        }

        public static bool operator <(ObjectId lhs, ObjectId rhs)
        {
            return lhs.CompareTo(rhs) < 0;
        }

        public static bool operator <=(ObjectId lhs, ObjectId rhs)
        {
            return lhs.CompareTo(rhs) <= 0;
        }

        // Static Methods

        private static byte[] FromHex(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            if (value.Length != 24)
                throw new ArgumentException(string.Format("ObjectId strings should be 24 hex characters, got {0} : \"{1}\"", value.Length, value));

            var bytes = new byte[12];

            for (var i = 0; i < 24; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(value.Substring(i, 2), 16);
            }

            return bytes;
        }

        static ObjectId()
        {
            _machine = (0x00ffffff & Environment.MachineName.GetHashCode() + AppDomain.CurrentDomain.Id) & 0x00ffffff;
            _increment = (new Random()).Next();

            try
            {
                _pid = (short)GetCurrentProcessId();
            }
            catch (SecurityException)
            {
                _pid = 0;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int GetCurrentProcessId()
        {
#if HAVE_PROCESS
            return Process.GetCurrentProcess().Id;
#else
            return (new Random()).Next(0, 5000); // Any same number for this process
#endif
        }

        public static ObjectId New()
        {
            var timestamp = (long)Math.Floor((DateTime.UtcNow - UnixEpoch).TotalSeconds);
            var inc = Interlocked.Increment(ref _increment) & 0x00ffffff;

            return new ObjectId((int)timestamp, _machine, _pid, inc);
        }
    }
}
