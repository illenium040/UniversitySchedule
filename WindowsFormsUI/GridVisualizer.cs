using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public class GridVisualizer
    {
        private DataGridView _gridView;
        private GridVisualizerSettings _settings;

        public GridVisualizer(DataGridView grid)
        {
            _gridView = grid;
        }

        public GridVisualizer AddSettings(GridVisualizerSettings settings)
        {
            _settings = settings;
            return this;
        }

        public GridVisualizer AddColumns(IEnumerable<string> columnHeaders)
        {
            if (columnHeaders.Count() == 0) return this;
            if (_gridView.InvokeRequired)
                _gridView.Invoke(() => AddColumnsToInvoke(columnHeaders));
            else AddColumnsToInvoke(columnHeaders);
            return this;
        }

        private void AddColumnsToInvoke(IEnumerable<string> columnHeaders)
        {
            foreach (var header in columnHeaders)
                _gridView.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = header,
                    Name = header,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                });
        }

        public GridVisualizer AddColumns(Func<IEnumerable<string>> columsNameFunc)
        {
            AddColumns(columsNameFunc());
            return this;
        }

        public GridVisualizer AddRowsByColumn(Func<IEnumerable<IEnumerable<object>>> valuesFunc)
        {
            AddRowsByColumn(valuesFunc());
            return this;
        }

        public GridVisualizer AddRowsByColumn(IEnumerable<IEnumerable<object>> values)
        {
            if (values.Count() == 0) return this;
            if(_gridView.InvokeRequired)
                _gridView.Invoke(() => AddRowsByColumnToInvoke(values));
            else AddRowsByColumnToInvoke(values);
            return this;
        }

        private void AddRowsByColumnToInvoke(IEnumerable<IEnumerable<object>> values)
        {
            values.EnumerableTo2DArray(x =>
            {
                _gridView.AddRow(x.Max(x => x.Count()));
                for (int i = 0; i < x.Length; i++)
                {
                    for (int j = 0; j < x[i].Length; j++)
                        _gridView[i, j].Value = x[i][j];
                }
            });
        }

        public GridVisualizer AddRowsByRow(Func<IEnumerable<IEnumerable<object>>> valuesFunc)
        {
            AddRowsByRow(valuesFunc());
            return this;
        }

        public GridVisualizer AddRowsByRow(IEnumerable<IEnumerable<object>> values)
        {
            if (_gridView.InvokeRequired)
                _gridView.Invoke(() => AddRowsByRowToInvoke(values));
            else AddRowsByRowToInvoke(values);
            return this;
        }

        private void AddRowsByRowToInvoke(IEnumerable<IEnumerable<object>> values)
        {
            values.EnumerableTo2DArray(x =>
            {
                for (int i = 0; i < x.Length; i++)
                {
                    _gridView.AddRow();
                    for (int j = 0; j < x[i].Length; j++)
                        _gridView[j, i].Value = x[i][j];
                }
            });
        }

        public GridVisualizer Resize()
        {
            if (_gridView.InvokeRequired)
                _gridView.Invoke(() => ResizeToInvoke());
            else ResizeToInvoke();
            return this;
        }

        private void ResizeToInvoke()
        {
            foreach (var col in _gridView.Columns.AsEnumerable())
                col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            foreach (var row in _gridView.Rows.AsEnumerable())
                row.Height = row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
        }
    }
}
