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

        public GridVisualizer AddRowsByColumn(IEnumerable<IEnumerable<object>> values)
        {
            if (values.Count() == 0) return this;
            _gridView.Invoke(() =>
            {
                _gridView.AddRow(values.Max(x => x.Count()));
                for (int i = 0; i < values.Count(); i++)
                {
                    for (int j = 0; j < values.ElementAt(i).Count(); j++)
                        _gridView[i, j].Value = values.ElementAt(i).ElementAt(j);
                }
            });
            return this;
        }

        public GridVisualizer AddRowsByColumn(Func<IEnumerable<IEnumerable<object>>> valuesFunc)
        {
            AddRowsByColumn(valuesFunc());
            return this;
        }

        public GridVisualizer AddRowsByRow(IEnumerable<IEnumerable<object>> values)
        {
            _gridView.Invoke(() =>
            {
                for (int i = 0; i < values.Count(); i++)
                {
                    _gridView.AddRow();
                    for (int j = 0; j < values.ElementAt(i).Count(); j++)
                        _gridView[j, i].Value = values.ElementAt(i).ElementAt(j);
                }
            });
            return this;
        }

        public GridVisualizer AddRowsByRow(Func<IEnumerable<IEnumerable<object>>> valuesFunc)
        {
            AddRowsByRow(valuesFunc());
            return this;
        }
    }
}
