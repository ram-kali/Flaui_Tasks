using ConsoleApp1.keyword;
using ConsoleApp1.Pages;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using Application = FlaUI.Core.Application;

namespace ConsoleApp1.TestCases
{
    class TestCase2:Task2_Page
    {
        static GenericKeyword keyword = new GenericKeyword();
        UIA3Automation automation = new UIA3Automation();
        Application app = keyword.LaunchStorApplication("Microsoft.WindowsAlarms_8wekyb3d8bbwe!App");
        
        public void task2()
        {
            navigateMenuTab(app, automation, "Alarm");
            clickAddAlarm(app, automation);
            setAlarmTime(app, automation, 9, 0);
            setAlarmName(app, automation, "Trumpf Metamation - Login Time");
             List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
            selectAlarmDays(app, automation, days);
            saveAlarm(app, automation);
            deleteAlarm(app, automation, "Trumpf Metamation - Login Time");

        }
        

    }
}