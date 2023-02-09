namespace DailyExercises
{
    /// <summary>
    /// 6214. 判断两个事件是否存在冲突
    /// </summary>
    internal class TimeConflict
    {
        public static bool HaveConflict(string[] event1, string[] event2)
        {
            DateTime[] date1 = event1.Select(x => DateTime.Parse(x)).ToArray();
            DateTime[] date2 = event2.Select(x => DateTime.Parse(x)).ToArray();

            if ((date1[1]<date2[0] && (date2[1]>date2[0] || date2[1]<date1[0]))||
               date2[0] < date1[0] && date2[1] < date1[0]) return false;
            else return true;
        }
    }
}
