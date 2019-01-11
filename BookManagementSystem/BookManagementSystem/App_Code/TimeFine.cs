using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// TimeFine 的摘要说明
/// </summary>
public class TimeFine
{
    public TimeFine()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public static void ClearCountByTime()
    {
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new ElapsedEventHandler(TimeEvent);
        // 设置引发时间的时间间隔 此处设置为１秒 
        aTimer.Interval = 1000;
        aTimer.Enabled = true;
    }

    private static void TimeEvent(object source, ElapsedEventArgs e)
    {
        // 得到 hour minute second 如果等于某个值就开始执行 
        int intHour = e.SignalTime.Hour;
        int intMinute = e.SignalTime.Minute;
        int intSecond = e.SignalTime.Second;
        // 定制时间,在00：00：00 的时候执行 
        int iHour = 00;
        int iMinute = 00;
        int iSecond = 00;

        // 设置 每天的00：00：00开始执行程序 
        if (intHour == iHour && intMinute == iMinute && intSecond == iSecond)
        {
            ClearCount();
        }
    }

    public static void ClearCount()
    {
        /*        string sql = "要执行的存储过程";
                int result = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, sql);
                if (result > 0)
                {
                    //TodayCount清零成功！; 
                }
                else
                {
                    //TodayCount清零失败！; 
                }
            
        */
    }
}