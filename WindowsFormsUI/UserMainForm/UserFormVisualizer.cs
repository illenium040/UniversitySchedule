using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI.UserMainForm
{
    partial class UserForm
    {
        private async Task VisualizeGridView(Action gridAction)
        {
            dataLoadStatePanel.Visible = true;
            timetableGridView.Visible = false;
            await Task.Run(() => {
                timetableGridView.Invoke(() =>
                {
                    timetableGridView.Rows.Clear();
                    timetableGridView.Columns.Clear();
                    timetableGridView.Refresh();
                });
                try
                {
                    gridAction();
                }
                catch
                {

                }

            });
            timetableGridView.Update();
            dataLoadStatePanel.Visible = false;
            timetableGridView.Visible = true;
        }
    }
}
