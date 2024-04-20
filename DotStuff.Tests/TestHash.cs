namespace DotStuff;

internal readonly struct TestHash
{
    // A quite bad hash function for testing purposes only.

    public uint Value { get; }

    public static TestHash Zero
        => default;

    private TestHash(uint value)
        => Value = value;

    public static implicit operator uint(TestHash hash)
        => hash.Value;

    public static TestHash operator +(TestHash hash, char c)
        => new(uint.RotateLeft(hash.Value, 3) + c);

    public static TestHash operator +(TestHash hash, string s)
        => s.Aggregate(hash, (h, c) => h + c);
}
