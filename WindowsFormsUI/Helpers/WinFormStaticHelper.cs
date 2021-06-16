using DataAccess.Entities;

using iTextSharp.text;
using iTextSharp.text.pdf;

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WindowsFormsUI.FormCommands.DataGridCommands;
using WindowsFormsUI.FormCommands.Receivers;

namespace WindowsFormsUI
{
    public static class WinFormStaticHelper
    {
       
        public static void Invoke(this Control control, MethodInvoker action)
        {
            control.Invoke(action);
        }

        public static void SetDoubleBuffered(this Control control)
        {
            //Taxes: Remote Desktop Connection and painting
            //http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(control, true, null);
        }

        public static string GetRuDayOfWeek(Day day)
        {
            return day switch
            {
                Day.Monday => "Понедельник",
                Day.Tuesday => "Вторник",
                Day.Wednesday => "Среда",
                Day.Thursday => "Четверг",
                Day.Friday => "Пятница",
                Day.Saturday => "Суббота",
                Day.Sunday => "Воскресенье",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        internal static void SaveDataGridView(DataTable dataTable, bool isTimetable = false, int hours = 7, Rectangle r = null)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var baseFont = BaseFont.CreateFont(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "//arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            try
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = "Pdf File |*.pdf";
                if (sfd.ShowDialog() != DialogResult.OK) return;
                var pdfDoc = new Document(r ??= new Rectangle(7000, 7000));

                using (var fs = new FileStream(sfd.FileName, FileMode.Create))
                using (var writer = PdfWriter.GetInstance(pdfDoc, fs))
                {
                    pdfDoc.Open();
                    pdfDoc.NewPage();
                    PdfPTable table = new PdfPTable(dataTable.Rows.Count + 1);
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        PdfPCell cell = new PdfPCell();
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        cell.Rotation = -90;
                        for (int j = dataTable.Rows.Count - 1; j >= 0; j--)
                        {
                            cell.Phrase = new Phrase(dataTable.Rows[j][i].ToString(), new Font(baseFont, 32, 0));
                            if(isTimetable)
                            {
                                if (j % (hours + 1) == 0 && j != dataTable.Rows.Count - 1)
                                    cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                                else cell.BackgroundColor = null;
                            }
                            table.AddCell(cell);
                        }
                        string cellText = dataTable.Columns[i].ColumnName;
                        cell.Phrase = new Phrase(cellText, new Font(baseFont, 40, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                        cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                        cell.PaddingBottom = 5;
                        table.AddCell(cell);
                    }
                    pdfDoc.Add(table);
                    pdfDoc.Close();
                }
            }
            catch(Exception e)
            {

            }
        }

        public static string GetRuDayOfWeek(int day)
        {
            return GetRuDayOfWeek((Day)day);
        }

        public static void ShowErrorMsgBox(string message)
        {
            MessageBox.Show(message, "Ошибка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
        }

        internal static void SaveAsPDF(TimetableViewInfo viewInfo, Rectangle r = null)
        {
            
            try
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = "Pdf File |*.pdf";
                if (sfd.ShowDialog() != DialogResult.OK) return;
                var pdfDoc = new Document(r ??= new Rectangle(7000, 7000));
                
                using (var fs = new FileStream(sfd.FileName, FileMode.Create))
                using (var writer = PdfWriter.GetInstance(pdfDoc, fs))
                {
                    pdfDoc.Open();
                    pdfDoc.NewPage();

                    //Adding  PdfPTable  
                    var dataTable = GetDataTableFromTimetableView(viewInfo);
                    var table = FillPdfTableWithTimetable(dataTable, GetBaseFont(), viewInfo);
                    
                    pdfDoc.Add(table);
                    pdfDoc.Close();
                }
                
            }
            catch (Exception ex)
            {

            }
        }

        private static DataTable GetDataTableFromTimetableView(TimetableViewInfo viewInfo)
        {
            var groups = viewInfo.TimetableView.Select(x => x.Group).Distinct().OrderBy(x => x.Id).ToList();
            var dgv = new DataGridView();
            new TimetableCommand(groups, viewInfo)
                .AddReceiver(new DataGridViewCommandReceiver(dgv))
                .Execute();
            return dgv.ToDataTable();
        }

        private static PdfPTable FillPdfTableWithTimetable(DataTable dataTable, 
            BaseFont baseFont, TimetableViewInfo viewInfo)
        {
            PdfPTable table = new PdfPTable(dataTable.Rows.Count + 1);
            var groups = viewInfo.TimetableView.Select(x => x.Group).Distinct().OrderBy(x => x.Id).ToList();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                cell.Rotation = -90;
                for (int j = dataTable.Rows.Count - 1; j >= 0; j--)
                {
                    cell.Phrase = new Phrase(dataTable.Rows[j][i].ToString(), new Font(baseFont, 32, 0));
                    if (j % (viewInfo.Hours + 1) == 0 && j != dataTable.Rows.Count - 1)
                        cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                    else cell.BackgroundColor = null;
                    table.AddCell(cell);
                }
                string cellText = groups[i].Id.ToString();
                cell.Phrase = new Phrase(cellText, new Font(baseFont, 40, 1, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#000000"))));
                cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#C8C8C8"));
                cell.PaddingBottom = 5;
                table.AddCell(cell);
            }
            return table;
        }

        public static BaseFont GetBaseFont()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return BaseFont.CreateFont(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "//arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }

        public static DataTable ToDataTable(this DataGridView dgv)
        {
            var dataTable = new DataTable();

            foreach (DataGridViewColumn col in dgv.Columns)
                dataTable.Columns.Add(col.HeaderText);

            foreach (DataGridViewRow row in dgv.Rows)
            {
                DataRow dRow = dataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dataTable.Rows.Add(dRow);
            }
            return dataTable;
        }

        public static string GetFileDialogResult(string fileExtension)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = fileExtension;
            fileDialog.Filter = $"Access database Files (*.{fileExtension})|*.{fileExtension}";
            if (fileDialog.ShowDialog() == DialogResult.OK) return fileDialog.FileName;
            return "";
        }

        public static string GetFolderDialogResult()
        {
            var fileDialog = new FolderBrowserDialog();
            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK) return fileDialog.SelectedPath;
            return "";
        }
    }
}
