using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ClipBoardWatcher
{
	/// <summary>
	/// Summary description for APIFuncs.
	/// </summary>
	public class APIFuncs
	{
		#region Windows API Functions Declarations
		//This Function is used to get Active Window Title...
		[System.Runtime.InteropServices.DllImport("user32.dll",CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hwnd,string lpString, int cch);

		//This Function is used to get Handle for Active Window...
		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		private static extern IntPtr GetForegroundWindow();
	
		//This Function is used to get Active process ID...
		[System.Runtime.InteropServices.DllImport("user32.dll", CharSet=System.Runtime.InteropServices.CharSet.Auto)]
		private static extern Int32 GetWindowThreadProcessId(IntPtr hWnd,out Int32 lpdwProcessId);

        /// <summary>
        /// Places the given window in the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);

        /// <summary>
        /// Removes the given window from the system-maintained clipboard format listener list.
        /// </summary>
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

        #endregion


        #region User-defined Functions
        public static  Int32 GetWindowProcessID(IntPtr hwnd)
		{
			//This Function is used to get Active process ID...
			Int32 pid;
			GetWindowThreadProcessId(hwnd, out pid);
			return pid;
		}
		public static IntPtr getforegroundWindow()
		{
			//This method is used to get Handle for Active Window using GetForegroundWindow() method present in user32.dll
			return GetForegroundWindow();
		}
		public static string ActiveApplTitle()
		{
			//This method is used to get active application's title using GetWindowText() method present in user32.dll
			IntPtr hwnd =getforegroundWindow();
			if (hwnd.Equals(IntPtr.Zero)) return "";
			string lpText = new string((char) 0, 100);
			int intLength = GetWindowText(hwnd, lpText, lpText.Length);
			if ((intLength <= 0) || (intLength > lpText.Length)) return "unknown";
			return lpText.Trim();
		}

        public static bool AddClipboardListener(IntPtr hwnd)
        {
            return AddClipboardFormatListener(hwnd);
        }

        public static bool RemoveClipboardListener(IntPtr hwnd)
        {
            return RemoveClipboardFormatListener(hwnd);
        }

        #endregion

        /// <summary>
        /// Sent when the contents of the clipboard have changed.
        /// </summary>
        public const int WM_CLIPBOARDUPDATE = 0x031D;

        public APIFuncs()
		{
		}
	}
}
