﻿
// ReSharper disable All
// <auto-generated />

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable enable

namespace Biaui.Internals
{
    [DebuggerDisplay("X:{CenterX}, Y:{CenterY}, Radius:{Radius}")]
    public readonly struct ImmutableCircle_float : IEquatable<ImmutableCircle_float>
    {
        public readonly float CenterX;
        public readonly float CenterY;
        public readonly float Radius;

        public ImmutableCircle_float(float centerX, float centerY, float radius)
            => (CenterX, CenterY, Radius) = (centerX, centerY, radius);

        // ReSharper disable CompareOfFloatsByEqualityOperator
        public static bool operator ==(in ImmutableCircle_float source1, in ImmutableCircle_float source2)
            => source1.CenterX == source2.CenterX &&
               source1.CenterY == source2.CenterY &&
               source1.Radius == source2.Radius;
        // ReSharper restore CompareOfFloatsByEqualityOperator

        public static bool operator !=(in ImmutableCircle_float source1, in ImmutableCircle_float source2)
            => !(source1 == source2);

        public bool Equals(ImmutableCircle_float other)
            => this == other;

        public override bool Equals(object? obj)
        {
            if (obj is ImmutableCircle_float other)
                return this == other;

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
            => HashCodeMaker.To32(HashCodeMaker.Make(CenterX, CenterY, Radius));
    }

    [DebuggerDisplay("X:{CenterX}, Y:{CenterY}, Radius:{Radius}")]
    public readonly struct ImmutableCircle_double : IEquatable<ImmutableCircle_double>
    {
        public readonly double CenterX;
        public readonly double CenterY;
        public readonly double Radius;

        public ImmutableCircle_double(double centerX, double centerY, double radius)
            => (CenterX, CenterY, Radius) = (centerX, centerY, radius);

        // ReSharper disable CompareOfFloatsByEqualityOperator
        public static bool operator ==(in ImmutableCircle_double source1, in ImmutableCircle_double source2)
            => source1.CenterX == source2.CenterX &&
               source1.CenterY == source2.CenterY &&
               source1.Radius == source2.Radius;
        // ReSharper restore CompareOfFloatsByEqualityOperator

        public static bool operator !=(in ImmutableCircle_double source1, in ImmutableCircle_double source2)
            => !(source1 == source2);

        public bool Equals(ImmutableCircle_double other)
            => this == other;

        public override bool Equals(object? obj)
        {
            if (obj is ImmutableCircle_double other)
                return this == other;

            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
            => HashCodeMaker.To32(HashCodeMaker.Make(CenterX, CenterY, Radius));
    }

}
