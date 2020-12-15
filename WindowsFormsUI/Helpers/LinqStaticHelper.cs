using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public static class LinqStaticHelper
    {
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

        public static void EnumerableTo2DArray<T>(this IEnumerable<IEnumerable<T>> enumearble, Action<T[][]> action)
        {
            action(enumearble.Select(x => x.ToArray()).ToArray());
        }

        public static IEnumerable<DataGridViewRow> AsEnumerable(this DataGridViewRowCollection dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView)
                yield return row;
        }

        public static IEnumerable<DataGridViewColumn> AsEnumerable(this DataGridViewColumnCollection dataGridView)
        {
            foreach (DataGridViewColumn row in dataGridView)
                yield return row;
        }
    }
}
