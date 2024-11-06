using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte prefixByte;
        byte[] bytes;

        switch (reading)
        {
            case >= ushort.MinValue and <= ushort.MaxValue:
                prefixByte = 2;
                bytes = BitConverter.GetBytes((ushort)reading);
                break;
            case >= short.MinValue and <= short.MaxValue:
                prefixByte = 256 - 2;
                bytes = BitConverter.GetBytes((short)reading);
                break;
            case >= int.MinValue and <= int.MaxValue:
                prefixByte = 256 - 4;
                bytes = BitConverter.GetBytes((int)reading);
                break;
            case >= uint.MinValue and <= uint.MaxValue:
                prefixByte = 4;
                bytes = BitConverter.GetBytes((uint)reading);
                break;
            default:
                prefixByte = 256 - 8;
                bytes = BitConverter.GetBytes((long)reading);
                break;
        }

        var buffer = new byte[9];
        buffer[0] = prefixByte;
        Array.Copy(bytes, 0, buffer, 1, bytes.Length);

        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        return buffer[0] switch
        {
            256 - 8 => BitConverter.ToInt64(buffer[1..]),
            256 - 4 => BitConverter.ToInt32(buffer[1..]),
            256 - 2 => BitConverter.ToInt16(buffer[1..]),
            2 => BitConverter.ToUInt16(buffer[1..]),
            4 => BitConverter.ToUInt32(buffer[1..]),
            _ => 0
        };
    }
}
