// See https://aka.ms/new-console-template for more information

using _2.AddTwoNumbers;

var l1 = new ListNode(9);
//l1 = new ListNode(4, l1);
//l1 = new ListNode(2, l1);

var l2 = new ListNode(9);
l2 = new ListNode(9, l2);
//l2 = new ListNode(5, l2);

Logic.AddTwoNumbers(l1, l2);
