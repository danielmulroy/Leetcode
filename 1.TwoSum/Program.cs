using System.Diagnostics;
using _1.TwoSum;

var nums = new[] { 1323, 2123, 3324, 4213, 2122, 3326, 4211, 21231, 33242, 424133, 4, 21234, 33245, 42133, 92123, 93324, 94213, 92122, 6, 93326, 94211, 921231, 933242, 9425133, 921234, 933245, 942133 };
var target = 10;

var sw = new Stopwatch();
sw.Start();
var brute = Logic.TwoSumBrute(nums, target);
sw.Stop();
var bruteTime = sw.ElapsedTicks;
sw.Restart();
Logic.TwoSumTwoPass(nums, target);
sw.Stop();
var tPTime = sw.ElapsedTicks;
sw.Restart();
Logic.TwoSumOnePass(nums, target);
sw.Stop();
var oPTime = sw.ElapsedTicks;


if (brute.Length == 0)
{
    Console.WriteLine("no matches :(");
    return;
}

Console.WriteLine($"{target} is sum at index {brute[0]} & {brute[1]}");
Console.WriteLine($"BRUTE - {bruteTime}");
Console.WriteLine($"TWO PASS - {tPTime}");
Console.WriteLine($"ONE PASS - {oPTime}");
