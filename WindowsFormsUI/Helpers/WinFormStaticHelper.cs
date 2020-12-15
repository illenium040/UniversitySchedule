using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public static class WinFormStaticHelper
    {
       
        public static void Invoke(this Control control, MethodInvoker action)
        {
            control.Invoke(action);
        }

        public static void SetDoubleBuffered(this Control control)
        {
            //Taxes: Remote Desktop Connection and painting
            //http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(control, true, null);
        }

        public static string GetRuDayOfWeek(Day day)
        {
            return day switch
            {
                Day.Monday => "Понедельник",
                Day.Tuesday => "Вторник",
                Day.Wednesday => "Среда",
                Day.Thursday => "Четверг",
                Day.Friday => "Пятница",
                Day.Saturday => "Суббота",
                Day.Sunday => "Воскресенье",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static string GetRuDayOfWeek(int day)
        {
            return GetRuDayOfWeek((Day)day);
        }

        public static void ShowErrorMsgBox(string message)
        {
            MessageBox.Show(message, "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
        }


        public static string GetFileDialogResult(string fileExtension)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = fileExtension;
            fileDialog.Filter = $"Access database Files (*.{fileExtension})|*.{fileExtension}";
            if (fileDialog.ShowDialog() == DialogResult.OK) return fileDialog.FileName;
            return "";
        }

        public static string GetFolderDialogResult()
        {
            var fileDialog = new FolderBrowserDialog();
            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK) return fileDialog.SelectedPath;
            return "";
        }
    }
}
