using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.AdminMainForm.UpdateDbData
{
    public class UpdatedData<T>
    {
        public Dictionary<DataGridViewRow, T> DataRowToData { get; }
        public List<T> Added { get; }
        public List<T> Removed { get; }
        public List<T> Updated { get; }

        public UpdatedData()
        {
            DataRowToData = new Dictionary<DataGridViewRow, T>();
            Added = new List<T>();
            Removed = new List<T>();
            Updated = new List<T>();
        }

        public void Check()
        {
            for (int i = 0; i < Added.Count; i++)
            {
                if (Removed.Contains(Added[i]))
                {
                    Removed.Remove(Added[i]);
                    Added.Remove(Added[i]);
                    i--;
                }
            }
            for (int i = 0; i < Updated.Count; i++)
            {
                if (Removed.Contains(Updated[i]) || Added.Contains(Updated[i]))
                {
                    Updated.Remove(Updated[i]);
                    i--;
                }
            }
        }

        public void Clear()
        {
            Added.Clear();
            Removed.Clear();
            Updated.Clear();
        }
    }
}
