using ConsoleApp1.Utilities;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1.keyword
{
    public class GenericKeyword:BaseClass
    {
        ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
        public void CreateDirectory(string folderPath)
        {
            
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                stepPass($"New Directory created Sucessfully. Path: {folderPath}");
            }
            else
            {
                stepFail("Failed to create Directory!");
            }
        }

        public void CreateNewtextFileWithText(string textFilePath, string textToBeWritten)
        {

            if (!File.Exists(textFilePath))
            {
                File.WriteAllText(textFilePath, textToBeWritten);
                stepPass("New text File Created. Path '"+textFilePath+"'");
                stepPass("Write text in text file was successful!");
            }
            else
            {
                stepFail("Failed to write text in Text File");
            }
        }


        public Process StartApplication(string appName, string folderPath)
        {
            return folderPath != null ?  Process.Start(appName, folderPath): Process.Start(appName);
        }

        public void DeleteFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                Directory.Delete(folderPath, true);
                stepPass("Folder and its contents deleted successfully!");
                return;
            }                
            stepFail("Failed to delete folder and its contents!");
        }

        public Application LaunchApplication(string application)
        {
            return Application.Launch(application);
        }
        public Application LaunchStorApplication(string application)
        {
            return Application.LaunchStoreApp(application);
        }

        public Window GetCurrentWindow(Application app, UIA3Automation automation)
        {
            return app.GetMainWindow(automation);
        }

        public void ClickOn (Window mainWindow, string elementType, string element)
        {
            findElement(mainWindow, elementType, element).AsButton().Click();
        }
        public void ClickCheckBox(Window mainWindow, string elementType, string element)
        {
            findElement(mainWindow, elementType, element).AsCheckBox().Click();
        }
        public void EnterText(Window mainWindow, string elementType, string element, string text)
        {
            findElement(mainWindow, elementType, element).AsTextBox().Enter(text);
        }
        public Window findElement(Window mainWindow, string elementType, string element)
        {
            switch (elementType.ToLower())
            {
                case "name":
                    return (Window)mainWindow.FindFirstDescendant(cf.ByName(element));                    

                case "automationid":
                    return (Window)mainWindow.FindFirstDescendant(cf.ByAutomationId(element));

                case "classname":
                    return (Window)mainWindow.FindFirstDescendant(cf.ByClassName(element));

                default:
                    return null;
            }

        }


    }
}
