using SolidPrinciplesDemo.Formatters;
using SolidPrinciplesDemo.Interfaces;
using SolidPrinciplesDemo.Models;
using SolidPrinciplesDemo.Services;

IReportGenerator generator = new ReportGenerator();

Report report = new SalesReport();

var reportContent = generator.GenerateReport(report);

IReportFormatter formatter = new PdfFormatter();

var formattedReport = formatter.Format(reportContent);

IReportSaver saver = new ReportSaver();
saver.SaveToFile(formattedReport);

Console.WriteLine("Process Completed.");

var logger1 = Logger.GetInstance();
logger1.Log("Application Started");

var logger2 = Logger.GetInstance();
logger2.Log("Processing Report");

Console.WriteLine("Are both logger instances same?");
Console.WriteLine(Object.ReferenceEquals(logger1, logger2));