using ConsoleApp1.keyword;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Pages
{
    public class Task2_Page:GenericKeyword
    {
     
        public void navigateMenuTab(FlaUI.Core.Application app, UIA3Automation automation, string buttonName)
        {
            try
            {
                Window mainWindow = GetCurrentWindow(app, automation);
                ClickOn(mainWindow, "Name", buttonName);
                stepPass($"Select '{buttonName}' tab in Menu");
            }
            catch (Exception e)
            {
                stepPass($"Failed select '{buttonName}' tab in Menu. Error:" + e);
            }
            
        }
        public void clickAddAlarm(FlaUI.Core.Application app, UIA3Automation automation)
        {
           
            try
            {
                Window mainWindow = GetCurrentWindow(app, automation);
                ClickOn(mainWindow, "AutomationID", "AddAlarmButton");
                stepPass($"Click 'AddAlarmButton' Button");
            }
            catch (Exception e)
            {
                stepPass($"Failed create New Alarm. Error:" + e);
            }

        }

        public void setAlarmTime(FlaUI.Core.Application app, UIA3Automation automation, int hour, int minutes)
        {
            try
            {
                Window mainWindow = GetCurrentWindow(app, automation);
                if (hour > 7)
                {
                    ClickOn(mainWindow, "AutomationID", "HourPicker");
                    for (int times = 0; times < (hour - 7); times++)
                    {
                        Keyboard.Press(VirtualKeyShort.UP);
                    }
                    stepPass($"The hour is set to {hour}");

                }
                else
                {
                    ClickOn(mainWindow, "AutomationID", "HourPicker");
                    for (int times = 0; times < (7 - hour); times++)
                    {
                        Keyboard.Press(VirtualKeyShort.DOWN);
                    }
                    stepPass($"The hour timer is set to {hour} hour");

                }

                if (minutes > 0)
                {
                    ClickOn(mainWindow, "AutomationID", "HourPicker");
                    for (int times = 0; times < minutes; times++)
                    {
                        Keyboard.Press(VirtualKeyShort.UP);
                    }
                    stepPass($"The hour is set to {minutes} minutes");
                }
                else
                {
                    stepPass("The minutes timer is set to 00 minutes");

                }

            }
            catch (Exception e)
            {
                stepPass($"Failed set Alarm Time. Error:" + e);
            }

        }

        public void setAlarmName(FlaUI.Core.Application app, UIA3Automation automation, string alarmName)
        {
            try
            {
                Window mainWindow = GetCurrentWindow(app, automation);
                EnterText(mainWindow, "Name", "Alarm name", alarmName);
                stepPass($"The Alarm Name is set to '{alarmName}'");
            }
            catch (Exception e)
            {
                stepPass($"Failed set Alarm Name. Error:" + e);
            }

        }

        public void setRepeatedAlarm(FlaUI.Core.Application app, UIA3Automation automation, bool condition)
        {
            try
            {
                if (condition)
                {
                    Window mainWindow = GetCurrentWindow(app, automation);
                    ClickCheckBox(mainWindow, "AutomationID", "RepeatCheckBox");
                    stepPass("Repeat Alarm Set Successfully!");
                    return;
                }
                stepPass("Repeat Alarm CheckBox is not turned on");

            }
            catch (Exception e)
            {
                stepPass($"Failed to Turn Off/On Repeated Alarm. Error:" + e);
            }


        }

        public void selectAlarmDays(FlaUI.Core.Application app, UIA3Automation automation, List<string> days)
        {
            try
            {
                Window mainWindow = GetCurrentWindow(app, automation);
                for (int i = 0; i < days.Count; i++)
                {
                    ClickOn(mainWindow, "Name", days[i]);
                    stepPass($"Select {days[i]}");
                }

            }
            catch (Exception e)
            {
                stepPass($"Failed to select Alarm Days. Error:" + e);
            }

        }

        public void saveAlarm(FlaUI.Core.Application app, UIA3Automation automation)
        {
            try
            {
                Window mainWindow = GetCurrentWindow(app, automation);
                ClickOn(mainWindow, "Name", "Save");
            }
            catch (Exception e)
            {
                stepPass($"Failed to save Alarm . Error:" + e);
            }

        }

        public void deleteAlarm(FlaUI.Core.Application app, UIA3Automation automation, string AlarmName)
        {
            try
            {
                Window mainWindow = GetCurrentWindow(app, automation);
                ClickOn(mainWindow, "Name", "AlarmName");
                wait(1);
                ClickOn(mainWindow, "AutomationID", "DeleteButton");
            }
            catch (Exception e)
            {
                stepPass($"Failed to Delete Alarm . Error:" + e);
            }

        }
    }
}
