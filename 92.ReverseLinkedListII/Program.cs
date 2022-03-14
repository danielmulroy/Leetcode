
using _92.ReverseLinkedListII;

var head = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
//var head = new ListNode(1, new ListNode(2, new ListNode(3)));

Console.WriteLine(head);

var reverse = Solution.ReverseBetween(head, 2, 4);

Console.WriteLine(reverse); 
