using System;
using System.Collections.Generic;
using System.Globalization;

public static class ReviewTask
{
    public static int Run(int[] attempts, int limit)
    {
        int total = 0;
        foreach (int used in attempts)
        {
            int remaining = Math.Max(0, limit - used);
            total += remaining;
        }
        return total;
    }
}
