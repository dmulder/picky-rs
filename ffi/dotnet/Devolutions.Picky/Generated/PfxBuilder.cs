// <auto-generated/> by Diplomat

#pragma warning disable 0105
using System;
using System.Runtime.InteropServices;

using Devolutions.Picky.Diplomat;
#pragma warning restore 0105

namespace Devolutions.Picky;

#nullable enable

/// <summary>
/// PFX (PKCS12 archive) builder.
/// </summary>
public partial class PfxBuilder: IDisposable
{
    private unsafe Raw.PfxBuilder* _inner;

    /// <summary>
    /// Creates a managed <c>PfxBuilder</c> from a raw handle.
    /// </summary>
    /// <remarks>
    /// Safety: you should not build two managed objects using the same raw handle (may causes use-after-free and double-free).
    /// <br/>
    /// This constructor assumes the raw struct is allocated on Rust side.
    /// If implemented, the custom Drop implementation on Rust side WILL run on destruction.
    /// </remarks>
    public unsafe PfxBuilder(Raw.PfxBuilder* handle)
    {
        _inner = handle;
    }

    /// <returns>
    /// A <c>PfxBuilder</c> allocated on Rust side.
    /// </returns>
    public static PfxBuilder Init(Pkcs12CryptoContext cryptoContext)
    {
        unsafe
        {
            Raw.Pkcs12CryptoContext* cryptoContextRaw;
            cryptoContextRaw = cryptoContext.AsFFI();
            if (cryptoContextRaw == null)
            {
                throw new ObjectDisposedException("Pkcs12CryptoContext");
            }
            Raw.PfxBuilder* retVal = Raw.PfxBuilder.Init(cryptoContextRaw);
            return new PfxBuilder(retVal);
        }
    }

    public void AddSafeBagToCurrentSafeContents(SafeBag safeBag)
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PfxBuilder");
            }
            Raw.SafeBag* safeBagRaw;
            safeBagRaw = safeBag.AsFFI();
            if (safeBagRaw == null)
            {
                throw new ObjectDisposedException("SafeBag");
            }
            Raw.PfxBuilder.AddSafeBagToCurrentSafeContents(_inner, safeBagRaw);
        }
    }

    public void MarkSafeContentsAsReady()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PfxBuilder");
            }
            Raw.PfxBuilder.MarkSafeContentsAsReady(_inner);
        }
    }

    /// <exception cref="PickyException"></exception>
    public void MarkEncryptedSafeContentsAsReady()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PfxBuilder");
            }
            IntPtr resultPtr = Raw.PfxBuilder.MarkEncryptedSafeContentsAsReady(_inner);
            Raw.Pkcs12FfiResultVoidBoxPickyError result = Marshal.PtrToStructure<Raw.Pkcs12FfiResultVoidBoxPickyError>(resultPtr);
            Raw.Pkcs12FfiResultVoidBoxPickyError.Destroy(resultPtr);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
        }
    }

    /// <exception cref="PickyException"></exception>
    /// <returns>
    /// A <c>Pfx</c> allocated on Rust side.
    /// </returns>
    public Pfx Build()
    {
        unsafe
        {
            if (_inner == null)
            {
                throw new ObjectDisposedException("PfxBuilder");
            }
            IntPtr resultPtr = Raw.PfxBuilder.Build(_inner);
            Raw.Pkcs12FfiResultBoxPfxBoxPickyError result = Marshal.PtrToStructure<Raw.Pkcs12FfiResultBoxPfxBoxPickyError>(resultPtr);
            Raw.Pkcs12FfiResultBoxPfxBoxPickyError.Destroy(resultPtr);
            if (!result.isOk)
            {
                throw new PickyException(new PickyError(result.Err));
            }
            Raw.Pfx* retVal = result.Ok;
            return new Pfx(retVal);
        }
    }

    /// <summary>
    /// Returns the underlying raw handle.
    /// </summary>
    public unsafe Raw.PfxBuilder* AsFFI()
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

            Raw.PfxBuilder.Destroy(_inner);
            _inner = null;

            GC.SuppressFinalize(this);
        }
    }

    ~PfxBuilder()
    {
        Dispose();
    }
}
