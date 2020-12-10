using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    //ran out of ideas
    public static class IdkHelper
    {
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
    }
}
