using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace _273.IntegerToEnglish;

internal static class Logic
{
    public static string NumberToWords(int num)
    {
        if (num == 0) return "Zero";
        var units = new Stack<int>();
        while (num > 0)
        {
            var last = num % 10;
            num /= 10;
            units.Push(last);
        }
        
        var sb = new StringBuilder();
        while (units.TryPop(out var amt))
        {
            int next;
            switch (units.Count)
            {
                case 0:
                    sb.Append(GetSingleNumberValue(amt, ""));
                    break;
                case 1:
                    next = -1;
                    if (amt == 1) next = units.Pop();
                    sb.Append(GetTensNumberValue(amt, next));
                    break;
                case 2:
                    sb.Append(GetSingleNumberValue(amt, "Hundred "));
                    break;
                case 3:
                    sb.Append(GetSingleNumberValue(amt, "Thousand "));
                    break;
                case 4:
                    next = -1;
                    if (amt == 1) next = units.Pop();
                    sb.Append(GetTensNumberValue(amt, next));
                    if (amt == 1 || (amt != 0 && units.Peek() == 0)) sb.Append("Thousand ");
                    break;
                case 5:
                    sb.Append(GetSingleNumberValue(amt, "Hundred "));
                    while (units.Count > 0 && units.Peek() == 0)
                    {
                        units.Pop();
                    }
                    if (units.Count % 3 == 0) sb.Append("Thousand ");
                    break;
                case 6:
                    sb.Append(GetSingleNumberValue(amt, "Million "));
                    while (units.Count > 0 && units.Peek() == 0)
                    {
                        units.Pop();
                    }
                    break;
                case 7:
                    next = -1;
                    if (amt == 1) next = units.Pop();
                    sb.Append(GetTensNumberValue(amt, next));
                    if (amt == 1 || units.Peek() == 0) sb.Append("Million ");
                    while (units.Count > 0 && units.Peek() == 0)
                    {
                        units.Pop();
                    }
                    break;
                case 8:
                    sb.Append(GetSingleNumberValue(amt, "Hundred "));

                    break;
                case 9:
                    sb.Append(GetSingleNumberValue(amt, "Billion "));
                    while (units.Count > 0 && units.Peek() == 0)
                    {
                        units.Pop();
                    }
                    break;
            }
        }

        return sb.ToString().Trim();
    }

    private static string GetTensNumberValue(int val, int next)
    {
        switch (val)
        {
            case 1:
                switch (next)
                {
                    case 1:
                        return "Eleven ";
                    case 2:
                        return "Twelve ";
                    case 3:
                        return "Thirteen ";
                    case 4:
                        return "Fourteen ";
                    case 5:
                        return "Fifteen ";
                    case 6:
                        return "Sixteen ";
                    case 7:
                        return "Seventeen ";
                    case 8:
                        return "Eighteen ";
                    case 9:
                        return "Nineteen ";
                }

                return "Ten ";
            case 2:
                return "Twenty ";
            case 3:
                return "Thirty ";
            case 4:
                return "Forty ";
            case 5:
                return "Fifty ";
            case 6:
                return "Sixty ";
            case 7:
                return "Seventy ";
            case 8:
                return "Eighty ";
            case 9:
                return "Ninety ";
        }

        return "";
    }

    private static string GetSingleNumberValue(int val, string append)
    {
        switch (val)
        {
            case 1:
                return "One " + append;
            case 2:
                return "Two " + append;
            case 3:
                return "Three " + append;
            case 4:
                return "Four " + append;
            case 5:
                return "Five " + append;
            case 6:
                return "Six " + append;
            case 7:
                return "Seven " + append;
            case 8:
                return "Eight " + append;
            case 9:
                return "Nine " + append;
        }

        return "";
    }
}