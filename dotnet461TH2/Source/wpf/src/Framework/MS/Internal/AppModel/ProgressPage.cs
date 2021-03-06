//+-----------------------------------------------------------------------
//
//  Copyright (c) Microsoft Corporation.  All rights reserved.
//
//  Description:
//      Deployment progress page. This is primarily a proxy to the native progress page, which supersedes
//      the managed one from up to v3.5. See Host\DLL\ProgressPage.hxx for details.
//
//  History:
//      2007/12/xx   [....]     Created
//
//------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Threading;
using System.Security;

// Disambiguate MS.Internal.HRESULT...
using HR = MS.Internal.Interop.HRESULT;

namespace MS.Internal.AppModel
{
    /// <SecurityNote>
    /// Critical due to SUC. 
    /// Even if a partilar method is considered safe, applying [SecurityTreatAsSafe] to it here won't help 
    /// much, because the transparency model still requires SUC-d methods to be called only from 
    /// SecurityCritical ones.
    /// </SecurityNote>
    [ComImport, Guid("1f681651-1024-4798-af36-119bbe5e5665")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [SecurityCritical(SecurityCriticalScope.Everything), SuppressUnmanagedCodeSecurity]
    interface INativeProgressPage
    {
        [PreserveSig]
        HR Show();
        [PreserveSig]
        HR Hide();
        [PreserveSig]
        HR ShowProgressMessage(string message);
        [PreserveSig]
        HR SetApplicationName(string appName);
        [PreserveSig]
        HR SetPublisherName(string publisherName);
        [PreserveSig]
        HR OnDownloadProgress(ulong bytesDownloaded, ulong bytesTotal);
    };

    /// <remarks>
    /// IProgressPage is public. It was introduced for the Media Center integration, which is now considered
    /// deprecated, but we have to support it at least for as long as we keep doing in-place upgrades.
    /// </remarks>
    interface IProgressPage2 : IProgressPage
    {
        void ShowProgressMessage(string message);
    };

    class NativeProgressPageProxy : IProgressPage2
    {
        /// <SecurityNote>
        /// Critical : Accepts critical argument INativeProgressPage
        ///            Sets critical member _npp
        /// </SecurityNote>
        [SecurityCritical]
        internal NativeProgressPageProxy(INativeProgressPage npp)
        {
            _npp = npp;
        }

        /// <SecurityNote>
        /// Critical: Calls a SUC'd COM interface method.
        /// TreatAsSafe: No concern about "spoofing" progress messages. A web site could just render an HTML 
        ///     page that looks like our progress page.
        /// </SecurityNote>
        [SecurityCritical, SecurityTreatAsSafe]
        public void ShowProgressMessage(string message)
        {
            // Ignore the error code.  This page is transient and it's not the end of the world if this doesn't show up.
            HR hr = _npp.ShowProgressMessage(message);
        }

        public Uri DeploymentPath
        {
            set { }
            get { throw new System.NotImplementedException(); }
        }

        /// <remarks>
        /// The native progress page sends a stop/cancel request to its host object, which then calls 
        /// IBrowserHostServices.ExecCommand(OLECMDID_STOP).
        /// </remarks>
        public DispatcherOperationCallback StopCallback
        {
            set { }
            get { throw new System.NotImplementedException(); }
        }

        /// <remarks>
        /// The native progress page sends a Refresh request to its host object, which then calls 
        /// IBrowserHostServices.ExecCommand(OLECMDID_REFRESH).
        /// </remarks>
        public System.Windows.Threading.DispatcherOperationCallback RefreshCallback
        {
            set { }
            get { return null; }
        }

        /// <SecurityNote>
        /// Critical: Calls a SUC'd COM interface method.
        /// TreatAsSafe: 1) The application name is coming from the manifest, so it could be anything.
        ///       This means the input doesn't need to be trusted. 
        ///     2) Setting arbitrary application/publisher can be considered spoofing, but a malicious website
        ///       could fake the whole progress page and still achieve the same.
        /// </SecurityNote>
        public string ApplicationName
        {
            [SecurityCritical, SecurityTreatAsSafe]
            set
            {
                // Ignore the error code.  This page is transient and it's not the end of the world if this doesn't show up.
                HR hr = _npp.SetApplicationName(value);
            }

            get { throw new System.NotImplementedException(); }
        }

        /// <SecurityNOoe>
        /// Critical: Calls a SUC'd COM interface method.
        /// TreatAsSafe: 1) The publisher name is coming from the manifest, so it could be anything.
        ///       This means the input doesn't need to be trusted. 
        ///     2) Setting arbitrary application/publisher can be considered spoofing, but a malicious website
        ///       could fake the whole progress page and still achieve the same.
        /// </SecurityNote>
        public string PublisherName
        {
            [SecurityCritical, SecurityTreatAsSafe]
            set
            { 
                // Ignore the error code.  This page is transient and it's not the end of the world if this doesn't show up.
                HR hr = _npp.SetPublisherName(value); 
            }

            get { throw new System.NotImplementedException(); }
        }

        /// <SecurityNOoe>
        /// Critical: Calls a SUC'd COM interface method.
        /// TreatAsSafe: Sending even arbitrary progress updates not considered harmful.
        /// </SecurityNote>
        [SecurityCritical, SecurityTreatAsSafe]
        public void UpdateProgress(long bytesDownloaded, long bytesTotal)
        {
            // Ignore the error code.  This page is transient and it's not the end of the world if this doesn't show up.
            HR hr = _npp.OnDownloadProgress((ulong)bytesDownloaded, (ulong)bytesTotal);
        }

        /// <SecurityNote>
        /// Critical : Field for critical type INativeProgressPage
        /// </SecurityNote>
        [SecurityCritical]
        INativeProgressPage _npp;
    };

}
