using System;
using System.Linq;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        Func<int, bool> isDivisibleBy4 = x => x % 4 == 0;
        Func<int, bool> isDivisibleBy400 = x => x % 400 == 0 && x % 100 != 0;
        Func<int, bool> isDivisibleBy100 = x => x % 400 != 0 && x % 100 == 0;

        var leapYearPredicates = new [] {
            isDivisibleBy4,
            isDivisibleBy400
        };

        return leapYearPredicates.Any(x => x(year)) && !isDivisibleBy100(year);
    }
}