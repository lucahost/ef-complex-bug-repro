﻿namespace EF.ComplexPropertyBug.Models;

using System;
using System.Diagnostics;
using System.Globalization;
using Galaxus.Functional;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplayString) + "()}")]
public sealed record Id<T> : IComparable<Id<T>>, IConvertible
{
    private readonly long internalValue;

    private bool HasValue => internalValue >= 1;

    public Option<long> Value => HasValue ? internalValue.ToOption() : Option<long>.None;

    internal Id(long value)
    {
        internalValue = value;
    }

    private string GetDebuggerDisplayString()
    {
        return $"Id<{typeof(T).Name}>({Value})";
    }

    public static implicit operator long(Id<T> id) => id.Value.UnwrapOr(default);

    public static explicit operator Id<T>(long id) => Id.Create<T>(id).Unwrap();

    public static bool operator <(Id<T> left, Id<T> right) => left.Value.UnwrapOr(default) < right.Value.UnwrapOr(default);

    public static bool operator <=(Id<T> left, Id<T> right) => left.Value.UnwrapOr(default) <= right.Value.UnwrapOr(default);

    public static bool operator >=(Id<T> left, Id<T> right) => left.Value.UnwrapOr(default) >= right.Value.UnwrapOr(default);

    public static bool operator >(Id<T> left, Id<T> right) => left.Value.UnwrapOr(default) > right.Value.UnwrapOr(default);

    public int CompareTo(Id<T>? other) => Value.UnwrapOr(default).CompareTo(other?.Value.UnwrapOr(default));

    public override string ToString() => HasValue ? Value.UnwrapOr(default).ToString(CultureInfo.InvariantCulture) : "Autogenerated";
    public TypeCode GetTypeCode()
    {
        return internalValue.GetTypeCode();
    }

    public bool ToBoolean(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToBoolean(provider);
    }

    public byte ToByte(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToByte(provider);
    }

    public char ToChar(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToChar(provider);
    }

    public DateTime ToDateTime(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToDateTime(provider);
    }

    public decimal ToDecimal(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToDecimal(provider);
    }

    public double ToDouble(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToDouble(provider);
    }

    public short ToInt16(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToInt16(provider);
    }

    public int ToInt32(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToInt32(provider);
    }

    public long ToInt64(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToInt64(provider);
    }

    public sbyte ToSByte(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToSByte(provider);
    }

    public float ToSingle(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToSingle(provider);
    }

    public string ToString(IFormatProvider? provider)
    {
        return internalValue.ToString(provider);
    }

    public object ToType(Type conversionType, IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToType(conversionType, provider);
    }

    public ushort ToUInt16(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToUInt16(provider);
    }

    public uint ToUInt32(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToUInt32(provider);
    }

    public ulong ToUInt64(IFormatProvider? provider)
    {
        return ((IConvertible)internalValue).ToUInt64(provider);
    }
}

public static class Id
{
    public static Id<T> Autogenerated<T>() => new(long.MinValue);

    public static Result<Id<T>, string> Create<T>(long value)
    {
        if (value < 1)
        {
            return $"An id cannot be lower than 1: {value}";
        }

        return new Id<T>(value);
    }

    public static Id<T> CreateWithoutValidation<T>(long value)
    {
        return new Id<T>(value);
    }
}