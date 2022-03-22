namespace _393.UTF8Validation;

public class Solution
{
    public static bool ValidUtf8(int[] data)
    {
        var checkNext = 0;
        for (int i = 0; i < data.Length; i++)
        {
            var num = Convert.ToString(Convert.ToByte(data[i]), 2).PadLeft(8, '0');

            if (checkNext != 0)
            {
                checkNext--;
                if (num[0] == '1' && num[1] == '0') { continue; }
                return false;
            }

            checkNext = 0;
            if (num[0] == '0') continue;
            if (num[1] == '1')
            {
                checkNext++;
                if (num[2] != '1') continue;
                checkNext++;
                if (num[3] != '1') continue;
                checkNext++;
                if (num[4] == '1') return false;
            }
            else return false;
        }
        return checkNext == 0;
    }
}
