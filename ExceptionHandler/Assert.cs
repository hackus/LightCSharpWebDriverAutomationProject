using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ExceptionHandler
{
    public static class AssertCustomized
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string assertionFatal1 = "Error: on assert for value[{0}]";
        private const string assertionFatal2 = "Error: on assert for values expected[{0}] and actual[{1}]";

        public delegate void FuncMy<in T1, in T2>(T1 arg1, T2 arg2);
        public delegate void FuncMyWithOneParameter<in T1>(T1 arg1);        

        //public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);

        private static int _fatalCounter = 0;
        private static int _errorCounter = 0;

        public static void Main()
        {
            AssertCustomized.AreEqual(1, 1, false);
            AssertCustomized.AreEqual(1, 1, true);

            AssertCustomized.AreEqual(1, 2, false); 
            AssertCustomized.AreEqual(1, 2, true);
        }

        public static void AreEqual(object expected, object actual, bool severity=false)
        {
            RunAction(A.AreEqual, expected, actual, severity);

            //try
            //{
            //    Assert.AreEqual(expected, actual);
            //}
            //catch (AssertFailedException e)
            //{
            //    if (severity)
            //    {
            //        _fatalCounter++;
            //        log.Fatal(String.Format(assertionFatal, expected, actual));
            //        throw e;
            //    }
            //    _errorCounter++;
            //    log.Error(String.Format(assertionFatal, expected, actual));
            //}            
        }

        public static void AreNotEqual(object expected, object actual, bool severity = false)
        {
            RunAction(A.AreNotEqual, expected, actual, severity);
        }

        public static void IsTrue(bool o, bool severity = false)
        {   
            RunAction(A.IsTrue, o, severity);
        }

        public static void IsFalse(bool o, bool severity = false)
        {
            RunAction(A.IsFalse, o, severity);
        }

        public static void IsNull(object o, bool severity = false)
        {
            RunAction(A.IsNull, o, severity);
        }

        private static void RunAction(FuncMyWithOneParameter<object> myMethodName, object obj, bool severity)
        {
            try
            {
                myMethodName(obj);
            }
            catch (AssertFailedException e)
            {
                if (severity)
                {
                    _fatalCounter++;
                    log.Fatal(String.Format(assertionFatal1, obj));
                    throw e;
                }
                _errorCounter++;
                log.Error(String.Format(assertionFatal1, obj));
            }
        }

        private static void RunAction(FuncMyWithOneParameter<bool> myMethodName, bool obj, bool severity)
        {
            try
            {
                myMethodName(obj);
            }
            catch (AssertFailedException e)
            {
                if (severity)
                {
                    _fatalCounter++;
                    log.Fatal(String.Format(assertionFatal1, obj));
                    throw e;
                }
                _errorCounter++;
                log.Error(String.Format(assertionFatal1, obj));
            }
        }

        private static void RunAction(FuncMy<object, object> myMethodName, object expected, object actual, bool severity)
        {
            try
            {
                myMethodName(expected, actual);
            }
            catch (AssertFailedException e)
            {
                if (severity)
                {
                    _fatalCounter++;
                    log.Fatal(String.Format(assertionFatal2, expected, actual));                    
                    throw e;
                }
                _errorCounter++;
                log.Error(String.Format(assertionFatal2, expected, actual));
            }  
        }

        //// my extension
        //public static void AreEqual(MyEnum expected, int actual)
        //{
        //    A.AreEqual((int)expected, actual);
        //}

        public static void IsTrue(bool o)
        {
            A.IsTrue(o);
        }

        public static void IsFalse(bool o)
        {
            A.IsFalse(o);
        }

        public static void AreNotEqual(object notExpected, object actual)
        {
            A.AreNotEqual(notExpected, actual);
        }

        public static void IsNotNull(object o)
        {
            A.IsNotNull(o);
        }

        public static void IsNull(object o)
        {
            A.IsNull(o);
        }
    }
}
