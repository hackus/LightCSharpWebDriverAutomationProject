using System;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using A = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using MyLogger;

namespace ExceptionHandler
{
    public static class MyAssert
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string assertionFatal1 = "Error: on assert for value[{0}] ";
        private const string assertionFatal2 = "Error: on assert for values expected[{0}] and actual[{1}] ";

        public delegate void FuncMy<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
        public delegate void FuncMy<T1, T2>(T1 arg1, T2 arg2);
        public delegate void FuncMyWithOneParameter<T1>(T1 arg1);
        
        private static int _errorCounter = 0;

        public static void Main()
        {
            MyAssert.AreEqual(1, 1, false);
            MyAssert.AreEqual(1, 1, true);

            MyAssert.AreEqual(1, 2, false); 
            MyAssert.AreEqual(1, 2, true);
        }

        public static int getErrorCounter()
        {
            return _errorCounter;
        }

        public static int AreEqual(object expected, object actual, bool severity=false)
        {
            return RunAction(A.AreEqual, expected, actual, severity);
        }

        public static int AreNotEqual(object expected, object actual, bool severity = false)
        {
            return RunAction(A.AreNotEqual, expected, actual, severity);
        }

        public static int IsTrue(bool o, bool severity = false, String errorMessage = "Error occured:")
        {   
            return RunAction(A.IsTrue, o, severity, errorMessage);
        }

        public static int IsFalse(bool o, bool severity = false, String errorMessage = "Error occured:")
        {
            return RunAction(A.IsFalse, o, severity, errorMessage);
        }

        public static int IsNull(object o, bool severity = false, String errorMessage = "Error occured:")
        {
            return RunAction(A.IsNull, o, severity, errorMessage);
        }

        private static int RunAction<T>(FuncMyWithOneParameter<T> myMethodName, T obj, bool severity, String message)
        {
            try
            {
                myMethodName(obj);
            }
            catch (AssertFailedException e)
            {
                _errorCounter++;
                if (severity)
                {
                    
                    log.Fatal(String.Format(assertionFatal1, obj) + LoggerMessages.TestFailed + ";" + message);
                    return 1;
                }
                log.Error(String.Format(assertionFatal1, obj) + LoggerMessages.TestFailed + ";" + message);
                return 2;
            }

            return 0;
        }


        private static int RunAction(FuncMy<object, object> myMethodName, object expected, object actual, bool severity)
        {
            try
            {
                myMethodName(expected, actual);
            }
            catch (AssertFailedException e)
            {
                _errorCounter++;

                if (severity)
                {   
                    log.Fatal(String.Format(assertionFatal2, expected, actual) + LoggerMessages.TestFailed);                        
                    return 1;
                }

                log.Error(String.Format(assertionFatal2, expected, actual + LoggerMessages.TestFailed));
                return 2;
            }
            return 0;
        }
    }
}
