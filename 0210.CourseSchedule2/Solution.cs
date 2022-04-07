namespace _0210.CourseSchedule2;

internal class Solution
{
    private static int[] isNodeProcessed;
    private static bool isCycle;
    private static List<int> order = new();
    private static Dictionary<int, List<int>> graph = new();
    public static int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        isNodeProcessed = new int[numCourses];

        //3 states of node will be determined as follows
        //-1: Node is unprocessed
        //0: Node is current processing
        //1: Node is processed
        Array.Fill(isNodeProcessed, -1);

        //Create graph representation of all all the nodes with given input using adjacency list
        foreach (var prerequisite in prerequisites)
        {
            var prevCourse = prerequisite[1];
            var nextCourse = prerequisite[0];
            graph.TryAdd(prevCourse, new List<int>());
            graph[prevCourse].Add(nextCourse);
        }

        //Call DFS on unprocessed nodes
        for (var i = 0; i < numCourses; i++)
        {
            //If node is currently not processed
            if (isNodeProcessed[i] == -1)
            {
                Dfs(i);
            }
        }

        order.Reverse();

        return isCycle ? Array.Empty<int>() : order.ToArray();
    }

    private static void Dfs(int currentIndex)
    {
        //Check condition to detect cycle
        if (isCycle)
        {
            return;
        }

        //Start performing DFS on each child node of current node
        //Set current node state to 0 as this node is currently getting processed.
        //This will be set to 1 when process is completed and callback is returned to current node index after recursion
        isNodeProcessed[currentIndex] = 0;

        //Traverse all the neighbouring nodes of current node
        if (graph.ContainsKey(currentIndex))
        {
            foreach (var nodeNeighbours in graph[currentIndex])
            {
                switch (isNodeProcessed[nodeNeighbours])
                {
                    case -1:
                        //Check if this neighbour is already processed
                        Dfs(nodeNeighbours);
                        break;
                    case 0:
                        //If node already getting processed is called again, cycle is detected
                        isCycle = true;
                        break;
                }
            }
        }

        //Set current node to be processed
        isNodeProcessed[currentIndex] = 1;
        order.Add(currentIndex);
    }


    //public static int[] FindOrder(int numCourses, int[][] prerequisites)
    //{
    //    if (prerequisites.Length == 0)
    //    {
    //        var arr = new int[numCourses];
    //        for (var j = 0; j < numCourses; j++)
    //        {
    //            arr[j] = j;
    //        }

    //        return arr;
    //    }

    //    var requires = new Dictionary<int, List<int>>();
    //    var fulfills = new Dictionary<int, List<int>>();
    //    foreach (var p in prerequisites)
    //    {
    //        if (!requires.ContainsKey(p[0])) requires.Add(p[0], new List<int>());
    //        if (!fulfills.ContainsKey(p[1])) fulfills.Add(p[1], new List<int>());

    //        requires[p[0]].Add(p[1]);
    //        fulfills[p[1]].Add(p[0]);
    //    }

    //    var i = numCourses;
    //    var coursesToTake = new HashSet<int>();
    //    var coursesTaken = new HashSet<int>();
    //    var courseListOrder = new List<int>();

    //    while (i > 0)
    //    {
    //        coursesToTake.Add(i);
    //    }

    //    while (courseList.Count != numCourses)
    //    {

    //    }

    //    return stack.Count == 0 && returnOrder.Count != numCourses ? Array.Empty<int>() : returnOrder.ToArray();
    //}
}

/* var i = 0;
        while (requires.ContainsKey(i))
            i++;
var returnOrder = new List<int>{i};
        var added = new HashSet<int>{i};
        var stack = new Stack<int>();
        if (fulfills.ContainsKey(i))
        {
            foreach (var j in fulfills[i])
                stack.Push(j);
        }

        while (returnOrder.Count < numCourses && stack.Count > 0)
        {
            var potentialNext = stack.Pop();
            if (added.Contains(potentialNext)) continue;
            var requirements = requires[potentialNext];
            var allGood = requirements.All(req => added.Contains(req));
            if (allGood)
            {
                returnOrder.Add(potentialNext);
                added.Add(potentialNext);
                if (fulfills.ContainsKey(potentialNext))
                {
                    foreach (var j in fulfills[potentialNext])
                        if (!added.Contains(j)) stack.Push(j);
                }
            }
*/