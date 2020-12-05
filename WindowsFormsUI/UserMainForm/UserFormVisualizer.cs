using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI.UserMainForm
{
    partial class UserForm
    {
        private void VisualizeGridView(Action gridAction)
        {
            dataLoadStatePanel.Invoke(() => dataLoadStatePanel.Visible = true);
            timetableGridView.Invoke(() =>
            {
                timetableGridView.Visible = false;
                timetableGridView.Rows.Clear();
                timetableGridView.Columns.Clear();
            });
            gridAction();
            timetableGridView.Invoke(() =>
            {
                timetableGridView.Visible = true;
                timetableGridView.Update();
            });
            dataLoadStatePanel.Invoke(() => dataLoadStatePanel.Visible = false);
        }
    }
}
