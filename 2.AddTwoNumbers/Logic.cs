using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.AddTwoNumbers;

public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next = null) { 
        this.val = val; 
        this.next = next;
    }
}
 
public static class Logic
{
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var num = new List<int>();
        var carry = false;

        while (true)
        {
            var sum = l1.val + l2.val;
            if (carry) sum++;
            carry = sum > 9;
            num.Add(sum % 10);
            if (!carry && l1.next == null && l2.next == null)
                break;
            l1 = l1.next ?? new ListNode();
            l2 = l2.next ?? new ListNode();
        }

        var node = new ListNode(num.Last());
        for (var i = num.Count - 2; i >= 0; i--)
        {
            var digit = num[i];
            var nextNode = new ListNode(digit, node);
            node = nextNode;
        }
        return node;
    }

    private static int value;
    private static int carry;

    public static ListNode AddTwoNumbersRecursive(ListNode l1, ListNode l2)
    {
        value = 0;
        if (l1 == null && l2 == null && carry == 0) return null;
        if (l1 != null) value += l1.val;
        if (l2 != null) value += l2.val;
        value += carry;
        if (value > 9)
        {
            carry = 1;
            value -= 10;
        }
        else carry = 0;
        var root = new ListNode(value, AddTwoNumbers(l1?.next, l2?.next));
        return root;
    }
}