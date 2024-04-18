// Copyright 2024 Jeffrey Sharp
// SPDX-License-Identifier: ISC

namespace DotStuff;

[TestFixture]
public class ObjectExtensionsTests
{
    [Test]
    public void Tap_ReferenceType()
    {
        var (value, tapped) = ("a", default(string));

        value.Tap(s => { tapped = s; }).Should().BeSameAs(value);

        tapped.Should().BeSameAs(value);
    }

    [Test]
    public void TapWithArg_ReferenceType()
    {
        var (value, tapped, arged) = ("a", default(string), default(int));

        value.Tap(42, (s, a) => { tapped = s; arged = a; }).Should().BeSameAs(value);

        tapped.Should().BeSameAs(value);
    }

    [Test]
    public void Tap_ValueType()
    {
        var (value, tapped) = (42, default(int));

        value.Tap(n => tapped = n).Should().Be(value);

        tapped.Should().Be(value);
    }

    [Test]
    public void Apply_ReferenceType()
    {
        "a".Apply(s => s + "b").Should().Be("ab");
    }

    [Test]
    public void Apply_ValueType()
    {
        42.Apply(x => x + 81).Should().Be(123);
    }
}
