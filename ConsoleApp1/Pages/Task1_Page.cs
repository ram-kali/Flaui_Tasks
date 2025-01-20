using ConsoleApp1.keyword;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Pages
{
    public class Task1_Page:GenericKeyword
    {
        public string createNotePadFileWithText(string drivePath, string newFolderName, string textFileName, string textToBeWritten)
        {
            string newFolderPath = Path.Combine(drivePath, newFolderName);
            CreateDirectory(newFolderPath);
            string textFilePath = Path.Combine(newFolderPath, textFileName);
            CreateNewtextFileWithText(textFilePath, textToBeWritten);

            wait(1);
            return newFolderPath;
        }

        public void verifyTextInNotePad(string folderPath, string textFileName, string expectedText)
        {
            string textFilePath = Path.Combine(folderPath, textFileName);
            StartApplication("explorer.exe", folderPath);
            stepPass("Open Created Folder");
            wait(1);
            string actualText = File.ReadAllText(textFilePath);
            if (actualText == expectedText)
            {
                stepPass("Text verification succeeded! Expected Text: "+expectedText+" Actual Text: "+ actualText);                
            }
            else
            {
                stepFail("Failed to verify Text! Expected Text: " + expectedText + " Actual Text: " + actualText);
            }
        }

        public void deleteCreatedFolder(string folderPath)
        {
            DeleteFolder(folderPath);
        }
    }
}
