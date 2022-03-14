
namespace _206.ReverseLinkedList;

public class Solution
{
    public static ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        while (head != null)
        {
            var next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }

        return prev;
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
}