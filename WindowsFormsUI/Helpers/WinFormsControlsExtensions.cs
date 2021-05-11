using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public static class ComboBoxExtensions
    {
        public static T GetSelectedItem<T>(this ComboBox comboBox)
            where T : class
        {
            T item = null;
            comboBox.Invoke(()=> item = comboBox.SelectedItem as T);
            return item;
        }
    }

    public static class DataGridViewExtensions
    {
        public delegate void InvokeGridDelegate(DataGridView grid);
        public static void Invoke(this DataGridView grid, InvokeGridDelegate action)
        {
            grid.Invoke(action, grid);
        }

        public static void ChangeWidthFromDock(this DataGridView grid, DockStyle dock)
        {
            grid.Dock = dock;
            if (dock == DockStyle.Fill)
                grid.Width = grid.Parent.Width;
            else if (dock == DockStyle.Left || dock == DockStyle.Right)
                grid.Width = grid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible)
                + grid.HorizontalScrollingOffset + 20;
        }

        public static void AddRow(this DataGridView grid, int count = 1)
        {
            for (int i = 0; i < count; i++)
                grid.Rows.Add();
        }

        public static void Clear(this DataGridView grid)
        {
            
            grid.Invoke(g => 
            {
                g.Columns.Clear();
                g.Rows.Clear();
                g.Refresh();
            }
            );
        }
    }
}
