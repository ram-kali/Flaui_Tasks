using ConsoleApp1.TestCases;
using ConsoleApp1.Utilities;
using System;
using System.Diagnostics;
using System.IO;

class Test : BaseClass
{
    public static void Main()
    {
        beforeAll();
        if (false)
        {
            try
            {
                stepInfo("*** Start of Test Case1 ***");
                var testCase1 = new testcase1();
                testCase1.task1();
                stepInfo("*** End of Test Case1 ***");
            }
            catch (Exception ex)
            {
                stepFail($"Test case 1 Failed. An error occurred: {ex.Message}");
            }

            finally
            {
                afterAll();
            }
        }
        if (true)
        {
            try
            {
                stepInfo("*** Start of Test Case2 ***");
                var testCase2 = new TestCase2();
                testCase2.task2();
                stepInfo("*** End of Test Case2 ***");
            }
            catch (Exception ex)
            {
                stepFail($"Test case 2 failed. An error occurred: {ex.Message}");
            }

            finally
            {
                afterAll();
            }
        }

    }
}
