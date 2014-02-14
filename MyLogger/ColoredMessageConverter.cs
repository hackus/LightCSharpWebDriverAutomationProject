using System.IO;
using System.Security.Cryptography.X509Certificates;
using log4net.Core;
using log4net.Layout.Pattern;
using System.Threading;
using System;
using System.Web;

namespace MyLogger
{
    public class ColoredMessageConverter : PatternLayoutConverter
    {        
        
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            string color = "";
            switch (loggingEvent.Level.Name)
            {
                case "DEBUG":
                    color = LoggerColor.DEBUG;
                    break;
                case "WARN":
                    color = LoggerColor.WARN;
                    break;
                case "INFO":
                    color = LoggerColor.INFO;
                    break;
                case "ERROR":
                    color = LoggerColor.ERROR;
                    break;
                case "FATAL":
                    color = LoggerColor.FATAL;
                    break;
            }

            string logToRender = string.Format("<div style='color:{0}'>{1}</div>", color, loggingEvent.RenderedMessage);
            logToRender = logToRender.Replace("\r\n", "<br>");
            string threadName = "";

            if (logToRender.Contains(LoggerMessages.TestSuiteStarted))
            {
                string str = "<style>"
                    + "#block_container"
                    + "{"
                    + "    text-align:left;"
                    + "}"
                    + "#bloc1, #bloc2"
                    + "{"
                    + "    display:inline;"
                    + "}"
                    + "</style>";

                writer.Write(str);
               
                return;
            }

            if (logToRender.Contains(LoggerMessages.TestSuiteResults)
                || logToRender.Contains(LoggerMessages.TestCasesRunned)
                || logToRender.Contains(LoggerMessages.TestCasesPassed)
                || logToRender.Contains(LoggerMessages.TestCasesFailed))
            {
                threadName = "";
            }
            else
            {
                threadName = Thread.CurrentThread.Name.Split(new string[] { "'" }, StringSplitOptions.RemoveEmptyEntries)[1] + ":";
            }

            string divBlockContainer = "<div id=\"block_container\" style='color:" + color + "'>_replaceme_</div>";
            string divBlock1 = "<div id=\"bloc1\" style=\"float:left;font-weight: bold\" >_replaceme_</div>";
            string divBlock2 = "<div id=\"bloc2\">_replaceme_</div>";

            string logToRenderAux = "";

            if (logToRender.Contains(LoggerMessages.AnchorFatal))
            {
                string screenshotPath = loggingEvent.RenderedMessage.Replace(LoggerMessages.AnchorFatal, "");
                Uri uri = new Uri(screenshotPath, UriKind.RelativeOrAbsolute);
                logToRenderAux = "<a style='display: inline;color:" + LoggerColor.FATAL + "' href='file:///" + uri.AbsolutePath + "'>error screenshot</a>";
            }
            if (logToRender.Contains(LoggerMessages.AnchorError))
            {
                string screenshotPath = loggingEvent.RenderedMessage.Replace(LoggerMessages.AnchorError, "");
                Uri uri = new Uri(screenshotPath, UriKind.RelativeOrAbsolute);
                logToRenderAux = "<a style='display: inline;color:" + LoggerColor.ERROR + "' href='file:///" + uri.AbsolutePath + "'>error screenshot</a>";
            }
         
            if (!logToRenderAux.Equals(""))
                logToRender = logToRenderAux;            

            divBlock1 = divBlock1.Replace("_replaceme_", threadName);
            divBlock2 = divBlock2.Replace("_replaceme_", logToRender);

            divBlockContainer = divBlockContainer.Replace("_replaceme_", divBlock1 + divBlock2);

            writer.Write(divBlockContainer);
        }
    }
}
