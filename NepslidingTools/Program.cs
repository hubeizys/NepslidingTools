using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection;

namespace NepslidingTools
{
   
    static class Program
    {
        public static string gdvid;
        public static string txtstr;
        public static string txtbh;
        public static float hg;
        public static float qb;
        public static string DK; 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                BonusSkins.Register();
                SkinManager.EnableFormSkins();
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
                //Application.Run(new Login());
                SysHelper.RunFrmOnly<login4>();
            }
            catch (IndexOutOfRangeException err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }

    public static class SysHelper
    {
        /// <summary>  
        /// 唯一运行一个实例,第二次打开时会把首次运行的置顶  
        /// 缺陷：(1)应用程序改名后无效  (2)如果首次运行的界面最大化，置顶时，界面会缩小，需要手动调整  
        /// </summary>  
        /// <typeparam name="T">运行的窗体</typeparam>  
        public static void RunFrmOnly<T>() where T : new()
        {
            Process instance = RunningInstance();
            if (instance == null)
            {
                Form frm = new T() as Form;
                Application.Run(frm);
            }
            else
            {
                HandleRunningInstance(instance);
            }
        }

        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        private static void HandleRunningInstance(Process instance)
        {
            // 确保窗口没有被最小化或最大化  
            ShowWindowAsync(instance.MainWindowHandle, 4);
            // 设置真实例程为foreground  window  
            SetForegroundWindow(instance.MainWindowHandle); // 放到最前端  
        }

        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            return processes.Where(process => process.Id != current.Id).FirstOrDefault(
                process => Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName);
        }
    }
}
