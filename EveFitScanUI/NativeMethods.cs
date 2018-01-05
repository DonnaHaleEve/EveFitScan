//-----------------------------------------------------------------------
// <copyright company="Viktorie Lucilla" file="NativeMethods.cs">
// Copyright © Viktorie Lucilla 2015. All Rights Reserved
// </copyright>
//-----------------------------------------------------------------------
namespace EveFitScanUI
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Contains P/Invoke method signatures.
    /// </summary>
    internal static class NativeMethods
    {
        #region P/Invoked Methods

        /// <summary>
        /// Adds a clipboard viewer to the current chain of clipboard registrees.
        /// </summary>
        /// <param name="hWndNewViewer">Handle to current process</param>
        /// <returns>Handle of next process in chain</returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        /// <summary>
        /// Removes a clipboard viewer from the chain of clipboard registrees, adding one back in its place.
        /// </summary>
        /// <param name="hWndRemove">Handle to remove from chain.</param>
        /// <param name="hWndNewNext">Handle to replace with in chain.</param>
        /// <returns>True if successful, false otherwise.</returns>
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("User32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam);

        #endregion P/Invoked Methods
    }
}
