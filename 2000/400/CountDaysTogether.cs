using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyExercises
{
    /// <summary>
    /// 2409. 统计共同度过的日子数
    /// </summary>
    internal class CountDaysTogether
    {
        public static int Run(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
        {
            DateTime arriveA = DateTime.Parse("1999-" + arriveAlice);
            DateTime leaveA = DateTime.Parse("1999-" + leaveAlice);
            DateTime arriveB = DateTime.Parse("1999-" + arriveBob);
            DateTime leaveB = DateTime.Parse("1999-" + leaveBob);

            DateTime arrive = arriveA > arriveB ? arriveA : arriveB;
            DateTime leave = leaveA < leaveB ? leaveA : leaveB;


            return leave >= arrive ? (leave - arrive).Days + 1 : 0;
        }
    }
}
