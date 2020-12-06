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
                    _gridView.AddColumn(header, header);
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

        public GridVisualizer Resize()
        {
            _gridView.Invoke(() =>
            {
                for (int i = 0; i < _gridView.Columns.Count; i++)
                    _gridView.Columns[i].Width = _gridView.Columns[i].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                for (int i = 0; i < _gridView.Rows.Count; i++)
                    _gridView.Rows[i].Height = _gridView.Rows[i].GetPreferredHeight(i, DataGridViewAutoSizeRowMode.AllCells, true);
            });
            return this;
        }

    }
}
