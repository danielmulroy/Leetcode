
namespace _92.ReverseLinkedListII;

public class Solution
{
    public static ListNode ReverseBetween(ListNode head, int left, int right)
    {
        if (head.next == null || left == right) return head;

        ListNode a = head;
        ListNode b;
        ListNode c;
        ListNode d;

        for (var i = 1; i < left; i++)
        {
            head = head.next;
        }

        b = head;
        c = head.next;

        for (var i = left; i <= right; i++)
        {
            head = head.next;
        }

        d = head;

        for (var i = left; i < right; i++)
        {
            b.next = d;
            d = b;
            b = c;
            c = c.next;
        }

        b.next = d;
        if (left == 1) return b;

        c = a;
        for (var i = 1; i < left - 1; i++)
        {
            c = c.next;
        }
        c.next = b;
        return a;
    }


}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.next = next;
        this.val = val;
    }

    public override string ToString()
    {
        return next == null ? val.ToString() : $"{val} - {next}";
    }
}