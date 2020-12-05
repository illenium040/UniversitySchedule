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

        public static IEnumerable<T> AppendWithIndex<T>(this IEnumerable<T> enumerable, int count, Func<int, T> func)
        {
            for (int i = 0; i < count; i++)
                enumerable = enumerable.Append(func(i));
            return enumerable;
        }

        public static IList<T> ForEachInList<T>(this IList<T> list, Action<IList<T>> action)
        {
            for (int i = 0; i < list.Count; i++)
                action(list);
            return list;
        }
    }
}
