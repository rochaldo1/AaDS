namespace AaDS_1
{
    public class LCS
    {
        public static string FindLCS(string a, string b)
        {
            return Hirschberg(a, b, a.Length, b.Length);
        }

        private static string Hirschberg(string a, string b, int m, int n)
        {
            if (n == 0)
                return "";
            if (m == 1)
            {
                for (int j = 0; j < n; j++)
                    if (b[j] == a[0])
                        return a[0].ToString();
                return "";
            }

            int mid = m / 2;
            string aFirstHalf = a.Substring(0, mid);
            string aSecondHalf = a.Substring(mid);

            int[] l1 = ComputeLCSLength(aFirstHalf, b);
            int[] l2 = ComputeLCSLength(ReverseString(aSecondHalf), ReverseString(b));

            int max = 0;
            int k = 0;
            for (int j = 0; j <= n; j++)
            {
                int sum = l1[j] + l2[n - j];
                if (sum > max)
                {
                    max = sum;
                    k = j;
                }
            }

            string lcsFirstHalf = Hirschberg(aFirstHalf, b.Substring(0, k), mid, k);
            string lcsSecondHalf = Hirschberg(aSecondHalf, b.Substring(k), m - mid, n - k);

            return lcsFirstHalf + lcsSecondHalf;
        }

        private static int[] ComputeLCSLength(string a, string b)
        {
            int m = a.Length;
            int n = b.Length;

            int[,] dp = new int[m + 1, n + 1];

            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else if (a[i - 1] == b[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            int[] result = new int[n + 1];

            for (int j = 0; j <= n; j++)
            {
                result[j] = dp[m, j];
            }

            return result;
        }

        private static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
