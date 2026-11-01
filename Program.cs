using System;
using System.Collections.Generic;
using System.Globalization;
using static ReviewTask;

class Program
{
    static int failed = 0;
    static void Main()
    {
        Check("T01", () => Run(new[] { 0, 1, 3, 4 }, 3), "5");
        Check("T02", () => Run(new[] { 1 }, 5), "4");
        Check("T03", () => Run(new[] { 9 }, 3), "0");
        Check("T04", () => Run(new[] { 1, 1 }, 3), "4");
        Check("T05", () => Run(Array.Empty<int>(), 3), "0");
        Console.WriteLine("Failed: " + failed);
        Environment.ExitCode = failed == 0 ? 0 : 1;
    }

    static string Display(object value)
    {
        if (value is decimal d)
            return d.ToString("G29", CultureInfo.InvariantCulture);
        return Convert.ToString(value, CultureInfo.InvariantCulture);
    }

    static void Check(string id, Func<object> action, string expected)
    {
        try
        {
            string actual = Display(action());
            bool ok = actual == expected;
            if (!ok) failed++;
            Console.WriteLine(id + (ok ? " PASS" : " FAIL")
                + " expected=[" + expected + "] actual=[" + actual + "]");
        }
        catch (Exception error)
        {
            failed++;
            Console.WriteLine(id + " FAIL exception=" + error.GetType().Name
                + " expected=[" + expected + "]");
        }
    }
}
