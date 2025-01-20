This project automates tasks related to file handling and utilizes the Page Object Model (POM) framework implemented with FlaUI and TDD model.

 The automation focuses on simulating a series of steps to create, modify, verify, and delete files and folders using C#.

Since I had implemented Data driver model , we can easily customize the location of the folder and other data in testcase file. I planned to add a json or excel file for ease of use under data folder, but due to time constrain, I have implemented directly in testcase1

Task 1: File Handling
#Steps Automated
Open File Explorer.
Navigate to C:\ (using D:/  ).
Create a folder named TrumpfMetamation (using mouse click events or the keyboard shortcut Ctrl+Shift+N).
Create a file named Welcome.txt inside the TrumpfMetamation folder.
Write the text "Welcome to Trumpf Metamation!" inside the file.
Verify that the content of the Welcome.txt file matches the expected text.
Delete both the Welcome.txt file and the TrumpfMetamation folder.
Confirm that the folder and file have been successfully deleted.

#Code Implementation
The logic for file creation, text writing, verification, and deletion is implemented in the Task1_Page class under the Pages folder.
The test logic is encapsulated in the testcase1 class in the TestCases folder.

#Core Components
1. Pages/Task1_Page.cs
Contains the core logic for automating file operations:

createNotePadFileWithText():
	Creates a directory.
	Writes text to a file in the directory.
	Returns the path of the created folder.
verifyTextInNotePad():
	Reads and verifies the text in the file.
	Logs whether the verification was successful or failed.
deleteCreatedFolder():
	Deletes the created folder and its contents.
2. TestCases/testcase1.cs
Implements the scenario as a test case:
	Calls methods from Task1_Page to execute the following:
	Create the folder and file.
	Write and verify the file content.
	Delete the folder and file.
3. Keyword/GenericKeyword.cs
	Provides utility methods for file and folder operations.
	Includes helper functions such as CreateDirectory, DeleteFolder, and wait.
4. Utilities/baseClass.cs
	Contains reusable components and base logic for test execution.

Framework
The project uses the Page Object Model (POM) pattern to organize automation code for better readability, scalability, and maintainability.

#Framework Highlights:
FlaUI Integration:
	FlaUI is used to interact with the Windows UI for automation.
Logging:
	Results and steps are logged in TestResults/log.txt.
Reusability:
	Common tasks are encapsulated in reusable methods within the 	GenericKeyword and Task1_Page classes.

#How to Execute Task 1#
*Clone or download the project.
*Open the solution in Visual Studio.
*Ensure flag is set true for testcase 1 in Test.cs file.
*Run Test.cs file
*Review logs in the TestResults/log.txt file for results.



Task 2: Alarm Automation
#Description
This task automates the creation, verification, and deletion of an alarm in the Windows Clock application. The automation is implemented using the Page Object Model (POM) framework, TDD model and FlaUI for UI interactions.

#Steps Automated
Open the Clock App:
	Launch the Windows Clock application using FlaUI.
Navigate to Alarm:
	Select the "Alarm" tab within the app.
Create a New Alarm:
	Set the time to 9:00 AM.
	Name the alarm as Trumpf Metamation - Login Time.
	Select specific days for the alarm (e.g., Monday to Friday).
Enable the Alarm:
	Ensure the alarm is active and ready.
Verify Alarm Details:
	Validate that the alarm is saved with the expected time, name, and 	days.
Delete the Alarm:
	Remove the created alarm.
Validate Deletion:
	Confirm the alarm has been successfully deleted.

#Execution Flow
Launch the Clock App: The app is launched using the LaunchStoreApplication method.

Navigate to Alarm Tab: The method navigateMenuTab selects the "Alarm" option.

Create and Save Alarm: The following methods are called in sequence:

	clickAddAlarm: Clicks the "Add Alarm" button.
	setAlarmTime: Sets the alarm time to 9:00 AM.
	setAlarmName: Names the alarm Trumpf Metamation - Login Time.
	selectAlarmDays: Selects Monday to Friday for the alarm(we customize the required days as required in list).
	saveAlarm: Saves the alarm settings.
Delete and Validate: The method deleteAlarm removes the alarm, and validation ensures it is no longer present.

