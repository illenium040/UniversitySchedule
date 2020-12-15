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
            _gridView.Invoke(() =>
            {
                foreach (var header in columnHeaders)
                    _gridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = header,
                        Name = header,
                        SortMode = DataGridViewColumnSortMode.NotSortable
                    });
            });
            
            return this;
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
            _gridView.Invoke(() =>
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
            });
            return this;
        }


        public GridVisualizer AddRowsByRow(Func<IEnumerable<IEnumerable<object>>> valuesFunc)
        {
            AddRowsByRow(valuesFunc());
            return this;
        }

        public GridVisualizer AddRowsByRow(IEnumerable<IEnumerable<object>> values)
        {
            _gridView.Invoke(() =>
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
                
            });
            return this;
        }

        //TODO: use max height and max width to resize cells
        public GridVisualizer Resize()
        {
            _gridView.Invoke(() =>
            {
                var maxWidth = _gridView.Columns.AsEnumerable()
                    .Max(col => col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true));
                var minWidth = _gridView.Columns.AsEnumerable()
                    .Min(col => col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true));
                foreach (var col in _gridView.Columns.AsEnumerable())
                    col.Width = (maxWidth + minWidth) / (maxWidth / minWidth);
                foreach (var row in _gridView.Rows.AsEnumerable())
                    row.Height = row.GetPreferredHeight(row.Index, DataGridViewAutoSizeRowMode.AllCells, true);
                
            });
            return this;
        }
    }
}
