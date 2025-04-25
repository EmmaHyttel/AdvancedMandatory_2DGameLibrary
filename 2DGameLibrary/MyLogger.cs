using System.Diagnostics;

public class MyLogger
{
    private static MyLogger instance = new MyLogger();
    public static MyLogger Instance { get { return instance; } }

    public TraceSource tc = new TraceSource("GameLog");

    private bool isStarted = false;
    private readonly object lockObj = new();

    private MyLogger()
    {
        tc = new TraceSource("GameLog")
        {
            Switch = new SourceSwitch("GameLog", SourceLevels.All.ToString())
        };
    }

    public TraceSource Start()
    {
        lock (lockObj)
        {
            if (!isStarted)
            {
                isStarted = true;
                tc.Listeners.Add(new ConsoleTraceListener());

                tc.Listeners.Add(new TextWriterTraceListener("log.txt") { Filter = new EventTypeFilter(SourceLevels.Error) });

                tc.Listeners.Add(new XmlWriterTraceListener("log.xml"));

                try
                {
                    tc.Listeners.Add(new EventLogTraceListener("Application"));
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[Warning] Could not add EventLogTraceListener: {e.Message}");
                }

            }
        }

        return tc;
    }

    // jeg skal også have muligheden for at brugeren af mit framework kan sætte sin egen logging op 
}
