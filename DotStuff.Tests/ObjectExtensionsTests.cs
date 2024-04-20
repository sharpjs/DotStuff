// Copyright 2024 Jeffrey Sharp
// SPDX-License-Identifier: ISC

namespace DotStuff;

using static TestHash;

[TestFixture]
public class ObjectExtensionsTests
{
    [Test]
    public void Tap0()
    {
        var (value, hash) = ("a", 0u);

        void F(string a)
            => hash = Zero + a;

        value.Tap(F).Should().BeSameAs(value);

        hash.Should().Be(97u);
    }

    [Test]
    public void Tap1()
    {
        var (value, hash) = ("a", 0u);

        void F(string a, string b)
            => hash = Zero + a + b;

        value.Tap("b", F).Should().BeSameAs(value);

        hash.Should().Be(874u);
    }

    [Test]
    public void Tap2()
    {
        var (value, hash) = ("a", 0u);

        void F(string a, string b, string c)
            => hash = Zero + a + b + c;

        value.Tap("b", "c", F).Should().BeSameAs(value);

        hash.Should().Be(7091u);
    }

    [Test]
    public void Tap3()
    {
        var (value, hash) = ("a", 0u);

        void F(string a, string b, string c, string d)
            => hash = Zero + a + b + c + d;

        value.Tap("b", "c", "d", F).Should().BeSameAs(value);

        hash.Should().Be(56828u);
    }

    [Test]
    public void Apply0()
    {
        static uint F(string a)
            => Zero + a;

        "a".Apply(F).Should().Be(97u);
    }

    [Test]
    public void Apply1()
    {
        static uint F(string a, string b)
            => Zero + a + b;

        "a".Apply("b", F).Should().Be(874u);
    }

    [Test]
    public void Apply2()
    {
        static uint F(string a, string b, string c)
            => Zero + a + b + c;

        "a".Apply("b", "c", F).Should().Be(7091u);
    }

    [Test]
    public void Apply3()
    {
        static uint F(string a, string b, string c, string d)
            => Zero + a + b + c + d;

        "a".Apply("b", "c", "d", F).Should().Be(56828u);
    }

    [Test]
    public void AssignTo()
    {
        var valueA = "a";

        valueA.AssignTo(out var location).Should().BeSameAs(valueA);

        location.Should().BeSameAs(valueA);
    }

    [Test]
    public void CoalesceTo_T_Null()
    {
        var valueA   = "a";
        var location = null as string;

        valueA.CoalesceTo(ref location).Should().BeSameAs(valueA);

        location.Should().BeSameAs(valueA);
    }

    [Test]
    public void CoalesceTo_T_NotNull()
    {
        var valueA   = "a";
        var valueB   = "b";
        var location = valueB;

        valueA.CoalesceTo(ref location).Should().BeSameAs(valueB);

        location.Should().BeSameAs(valueB);
    }

    [Test]
    public void CoalesceTo_NullableOfT_Null()
    {
        var valueA   = 1;
        var location = null as int?;

        valueA.CoalesceTo(ref location).Should().Be(valueA);

        location.Should().Be(valueA);
    }

    [Test]
    public void CoalesceTo_NullableOfT_NotNull()
    {
        var valueA   = 1;
        var valueB   = 2;
        var location = valueB as int?;

        valueA.CoalesceTo(ref location).Should().Be(valueB);

        location.Should().Be(valueB);
    }
}
