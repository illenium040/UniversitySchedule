using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsUI.AdminMainForm.UpdateDbData
{
    public interface IModifyGridDbData
    {
        public void Add();
        public void Remove(DataGridViewRow row);
        public void Update(int rowIndex);
    }
}