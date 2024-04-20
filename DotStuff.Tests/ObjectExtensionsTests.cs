// Copyright 2024 Jeffrey Sharp
// SPDX-License-Identifier: ISC

namespace DotStuff;

using static String;

[TestFixture]
public class ObjectExtensionsTests
{
    [Test]
    public void Tap0()
    {
        var valueA = "a";
        var tapped = null as string;

        valueA.Tap(a => { tapped = a; }).Should().BeSameAs(valueA);

        tapped.Should().BeSameAs(valueA);
    }

    [Test]
    public void Tap1()
    {
        var valueA = "a";
        var tapped = null as string;

        valueA.Tap("b", (a, b) => { tapped = Concat(a, b); }).Should().BeSameAs(valueA);

        tapped.Should().Be("ab");
    }

    [Test]
    public void Tap2()
    {
        var valueA = "a";
        var tapped = null as string;

        valueA.Tap("b", "c", (a, b, c) => { tapped = Concat(a, b, c); }).Should().BeSameAs(valueA);

        tapped.Should().Be("abc");
    }

    [Test]
    public void Tap3()
    {
        var valueA = "a";
        var tapped = null as string;

        valueA.Tap("b", "c", "d", (a, b, c, d) => { tapped = Concat(a, b, c, d); }).Should().BeSameAs(valueA);

        tapped.Should().Be("abcd");
    }

    [Test]
    public void Apply0()
    {
        "a".Apply(Concat).Should().Be("a");
    }

    [Test]
    public void Apply1()
    {
        "a".Apply("b", Concat).Should().Be("ab");
    }

    [Test]
    public void Apply2()
    {
        "a".Apply("b", "c", Concat).Should().Be("abc");
    }

    [Test]
    public void Apply3()
    {
        "a".Apply("b", "c", "d", Concat).Should().Be("abcd");
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
