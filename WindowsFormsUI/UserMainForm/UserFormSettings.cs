using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI.UserMainForm
{
    partial class UserForm
    {

        private void AddGridViewSettings()
        {
            timetableGridView.SetDoubleBuffered();
            timetableGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            timetableGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            timetableGridView.ReadOnly = true;
            timetableGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            timetableGridView.RowHeadersVisible = false;
            timetableGridView.BackgroundColor = this.BackColor;

            timetableGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            timetableGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void AddPictureBoxSettings()
        {
            loadingPictureBox.Image = Properties.Resources.loadingGif;
            preDataLoaderPictureBox.Image = Properties.Resources.loadingGif;
            preDataLoaderPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            loadingPictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
        }
    }
}
