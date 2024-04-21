// <auto-generated/> by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky;

#nullable enable

public partial class AttributeTypeAndValueParameters: IDisposable
{
    private unsafe Raw.AttributeTypeAndValueParameters* _inner;

    public AttributeTypeAndValueParametersType Type
    {
        get
        {
            return GetType();
        }
    }

    /// <summary>
    /// Creates a managed <c>AttributeTypeAndValueParameters</c> from a raw handle.
    /// </summary>
    /// <remarks>
    /// Safety: you should not build two managed objects using the same raw handle (may causes use-after-free and double-free).
    /// <br/>
    /// This constructor assumes the raw struct is allocated on Rust side.
    /// If implemented, the custom Drop implementation on Rust side WILL run on destruction.
    /// </remarks>
    public unsafe AttributeTypeAndValueParameters(Raw.AttributeTypeAndValueParameters* handle)
    {
        _inner = handle;
    }

    /// <returns>
    /// A <c>AttributeTypeAndValueParametersType</c> allocated on C# side.
    /// </returns>
    public AttributeTypeAndValueParametersType GetType()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.AttributeTypeAndValueParametersType retVal = Raw.AttributeTypeAndValueParameters.GetType(_inner);
            return (AttributeTypeAndValueParametersType)retVal;
        }
    }

    /// <returns>
    /// A <c>DirectoryString</c> allocated on Rust side.
    /// </returns>
    public DirectoryString? ToCommonName()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.DirectoryString* retVal = Raw.AttributeTypeAndValueParameters.ToCommonName(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new DirectoryString(retVal);
        }
    }

    /// <returns>
    /// A <c>DirectoryString</c> allocated on Rust side.
    /// </returns>
    public DirectoryString? ToSurname()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.DirectoryString* retVal = Raw.AttributeTypeAndValueParameters.ToSurname(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new DirectoryString(retVal);
        }
    }

    /// <returns>
    /// A <c>DirectoryString</c> allocated on Rust side.
    /// </returns>
    public DirectoryString? ToSerialNumber()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.DirectoryString* retVal = Raw.AttributeTypeAndValueParameters.ToSerialNumber(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new DirectoryString(retVal);
        }
    }

    /// <returns>
    /// A <c>DirectoryString</c> allocated on Rust side.
    /// </returns>
    public DirectoryString? ToCountryName()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.DirectoryString* retVal = Raw.AttributeTypeAndValueParameters.ToCountryName(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new DirectoryString(retVal);
        }
    }

    /// <returns>
    /// A <c>DirectoryString</c> allocated on Rust side.
    /// </returns>
    public DirectoryString? ToLocalityName()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.DirectoryString* retVal = Raw.AttributeTypeAndValueParameters.ToLocalityName(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new DirectoryString(retVal);
        }
    }

    /// <returns>
    /// A <c>DirectoryString</c> allocated on Rust side.
    /// </returns>
    public DirectoryString? ToStateOrProvinceName()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.DirectoryString* retVal = Raw.AttributeTypeAndValueParameters.ToStateOrProvinceName(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new DirectoryString(retVal);
        }
    }

    /// <returns>
    /// A <c>DirectoryString</c> allocated on Rust side.
    /// </returns>
    public DirectoryString? ToStreetName()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.DirectoryString* retVal = Raw.AttributeTypeAndValueParameters.ToStreetName(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new DirectoryString(retVal);
        }
    }

    /// <returns>
    /// A <c>DirectoryString</c> allocated on Rust side.
    /// </returns>
    public DirectoryString? ToOrganizationName()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.DirectoryString* retVal = Raw.AttributeTypeAndValueParameters.ToOrganizationName(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new DirectoryString(retVal);
        }
    }

    /// <returns>
    /// A <c>DirectoryString</c> allocated on Rust side.
    /// </returns>
    public DirectoryString? ToOrganizationalUnitName()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.DirectoryString* retVal = Raw.AttributeTypeAndValueParameters.ToOrganizationalUnitName(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new DirectoryString(retVal);
        }
    }

    /// <returns>
    /// A <c>VecU8</c> allocated on Rust side.
    /// </returns>
    public VecU8? ToEmailAddress()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.VecU8* retVal = Raw.AttributeTypeAndValueParameters.ToEmailAddress(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new VecU8(retVal);
        }
    }

    /// <returns>
    /// A <c>DirectoryString</c> allocated on Rust side.
    /// </returns>
    public DirectoryString? ToGivenName()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.DirectoryString* retVal = Raw.AttributeTypeAndValueParameters.ToGivenName(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new DirectoryString(retVal);
        }
    }

    /// <returns>
    /// A <c>DirectoryString</c> allocated on Rust side.
    /// </returns>
    public DirectoryString? ToPhone()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.DirectoryString* retVal = Raw.AttributeTypeAndValueParameters.ToPhone(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new DirectoryString(retVal);
        }
    }

    /// <returns>
    /// A <c>VecU8</c> allocated on Rust side.
    /// </returns>
    public VecU8? ToCustom()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("AttributeTypeAndValueParameters");
            }
            Raw.VecU8* retVal = Raw.AttributeTypeAndValueParameters.ToCustom(_inner);
            if (retVal == null)
            {
                return null;
            }
            return new VecU8(retVal);
        }
    }

    /// <summary>
    /// Returns the underlying raw handle.
    /// </summary>
    public unsafe Raw.AttributeTypeAndValueParameters* AsFFI()
    {
        return _inner;
    }

    /// <summary>
    /// Destroys the underlying object immediately.
    /// </summary>
    public void Dispose()
    {
        unsafe
        {
            if (_inner == null)
            {
                return;
            }

            Raw.AttributeTypeAndValueParameters.Destroy(_inner);
            _inner = null;

            GC.SuppressFinalize(this);
        }
    }

    ~AttributeTypeAndValueParameters()
    {
        Dispose();
    }
}