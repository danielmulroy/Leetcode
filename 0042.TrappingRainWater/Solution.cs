namespace _0042.TrappingRainWater;

internal class Solution
{
    public static int Trap(int[] height)
    {
        var puddleCount = 0; 
        (int height, int index) highestPoint = (0, height.Length);
        var inPuddle = false;
        var startOfPuddleForward = 0;
        var startOfPuddleBackward = 0;
        var lastForward = 0;
        var lastBackward = 0;
        var indexForward = 0;
        var indexBackward = height.Length - 1;
        while (indexForward < indexBackward)
        {
            while (indexForward < highestPoint.index)
            {
                var next = height[indexForward];
                if (next > highestPoint.height)
                {
                    highestPoint = (next, indexForward);
                    break;
                }

                if (!inPuddle && next < lastForward)
                {
                    inPuddle = true;
                    startOfPuddleForward = lastForward;
                }

                if (inPuddle)
                {
                    if (next < startOfPuddleForward)
                        puddleCount += (startOfPuddleForward - next);
                    else
                        inPuddle = false;
                }

                indexForward++;
                lastForward = next;
            }

            while (indexBackward > highestPoint.index)
            {
                var next = height[indexBackward];
                if (next > highestPoint.height)
                {
                    highestPoint = (next, indexBackward);
                    break;
                }

                if (!inPuddle && next < lastBackward)
                {
                    inPuddle = true;
                    startOfPuddleBackward = lastBackward;
                }

                if (inPuddle)
                {
                    if (next < startOfPuddleBackward)
                        puddleCount += (startOfPuddleBackward - next);
                    else
                        inPuddle = false;
                }

                indexBackward--;
                lastBackward = next;
            }
        }
        
        return puddleCount;
    }
}