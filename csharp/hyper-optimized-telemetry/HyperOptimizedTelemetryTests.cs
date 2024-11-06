using Exercism.Tests;
using Xunit;

public class HyperOptimizedTelemetryTests
{
    [Fact]
    [Task(1)]
    public void ToBuffer_upper_long()
    {
        var bytes = TelemetryBuffer.ToBuffer(long.MaxValue);
        Assert.Equal(new byte[] { 0xf8, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_long()
    {
        var bytes = TelemetryBuffer.ToBuffer((long)uint.MaxValue + 1);
        Assert.Equal(new byte[] { 0xf8, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_uint()
    {
        var bytes = TelemetryBuffer.ToBuffer(uint.MaxValue);
        Assert.Equal(new byte[] { 0x4, 0xff, 0xff, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_uint()
    {
        var bytes = TelemetryBuffer.ToBuffer((long)int.MaxValue + 1);
        Assert.Equal(new byte[] { 0x4, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_int()
    {
        var bytes = TelemetryBuffer.ToBuffer(int.MaxValue);
        Assert.Equal(new byte[] { 0xfc, 0xff, 0xff, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_int()
    {
        var bytes = TelemetryBuffer.ToBuffer((long)ushort.MaxValue + 1);
        Assert.Equal(new byte[] { 0xfc, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_ushort()
    {
        var bytes = TelemetryBuffer.ToBuffer(ushort.MaxValue);
        Assert.Equal(new byte[] { 0x2, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_ushort()
    {
        var bytes = TelemetryBuffer.ToBuffer((long)short.MaxValue + 1);
        Assert.Equal(new byte[] { 0x2, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_short()
    {
        var bytes = TelemetryBuffer.ToBuffer(short.MaxValue);
        Assert.Equal(new byte[] { 0x2, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_Zero()
    {
        var bytes = TelemetryBuffer.ToBuffer(0);
        Assert.Equal(new byte[] { 0x2, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_neg_short()
    {
        var bytes = TelemetryBuffer.ToBuffer(-1);
        Assert.Equal(new byte[] { 0xfe, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_neg_short()
    {
        var bytes = TelemetryBuffer.ToBuffer(short.MinValue);
        Assert.Equal(new byte[] { 0xfe, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_neg_int()
    {
        var n = short.MinValue - 1;
        var bytes = TelemetryBuffer.ToBuffer(n);
        Assert.Equal(new byte[] { 0xfc, 0xff, 0x7f, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_neg_int()
    {
        var bytes = TelemetryBuffer.ToBuffer(int.MinValue);
        Assert.Equal(new byte[] { 0xfc, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0 }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_upper_neg_long()
    {
        var bytes = TelemetryBuffer.ToBuffer((long)int.MinValue - 1);
        Assert.Equal(new byte[] { 0xf8, 0xff, 0xff, 0xff, 0x7f, 0xff, 0xff, 0xff, 0xff }, bytes);
    }

    [Fact]
    [Task(1)]
    public void ToBuffer_lower_neg_long()
    {
        var bytes = TelemetryBuffer.ToBuffer(long.MinValue);
        Assert.Equal(new byte[] { 0xf8, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x80 }, bytes);
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_Invalid()
    {
        Assert.Equal(0,
            TelemetryBuffer.FromBuffer(new byte[] { 22, 0xff, 0xff, 0xff, 0x7f, 0, 0, 0, 0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_long()
    {
        Assert.Equal(long.MaxValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xf8, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0x7f }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_long()
    {
        Assert.Equal((long)uint.MaxValue + 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0xf8, 0x0, 0x0, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_uint()
    {
        Assert.Equal(uint.MaxValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0x4, 0xff, 0xff, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_uint()
    {
        Assert.Equal((long)int.MaxValue + 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0x4, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_int()
    {
        Assert.Equal(int.MaxValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfc, 0xff, 0xff, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_int()
    {
        Assert.Equal(ushort.MaxValue + 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfc, 0x0, 0x0, 0x1, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_ushort()
    {
        Assert.Equal(ushort.MaxValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0x2, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_ushort()
    {
        Assert.Equal(short.MaxValue + 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0x2, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_short()
    {
        Assert.Equal(short.MaxValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfe, 0xff, 0x7f, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_Zero()
    {
        Assert.Equal(0,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfe, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_neg_short()
    {
        Assert.Equal(-1,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfe, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_neg_short()
    {
        Assert.Equal(short.MinValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfe, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_neg_int()
    {
        Assert.Equal(short.MinValue - 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfc, 0xff, 0x7f, 0xff, 0xff, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_neg_int()
    {
        Assert.Equal(int.MinValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xfc, 0x0, 0x0, 0x0, 0x80, 0x0, 0x0, 0x0, 0x0 }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_upper_neg_long()
    {
        Assert.Equal((long)int.MinValue - 1,
            TelemetryBuffer.FromBuffer(new byte[] { 0xf8, 0xff, 0xff, 0xff, 0x7f, 0xff, 0xff, 0xff, 0xff }));
    }

    [Fact]
    [Task(2)]
    public void FromBuffer_lower_neg_long()
    {
        Assert.Equal(long.MinValue,
            TelemetryBuffer.FromBuffer(new byte[] { 0xf8, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x80 }));
    }
}
