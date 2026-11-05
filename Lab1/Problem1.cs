
using System;

public class MedianOfTwoSortedArrays
{
    public static double FindMedianSortedArrays(
        int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.Length;
        int n = nums2.Length;

        int left = 0;
        int right = m;

        while (left <= right)
        {
            int partition1 = left + (right - left) / 2;
            int partition2 = (m + n + 1) / 2 - partition1;

            int left1 = partition1 == 0
                ? int.MinValue : nums1[partition1 - 1];

            int right1 = partition1 == m
                ? int.MaxValue : nums1[partition1];

            int left2 = partition2 == 0
                ? int.MinValue : nums2[partition2 - 1];

            int right2 = partition2 == n
                ? int.MaxValue : nums2[partition2];

            if (left1 <= right2 && left2 <= right1)
            {
                if ((m + n) % 2 == 1)
                {
                    return Math.Max(left1, left2);
                }

                return ((double)Math.Max(left1, left2)
                    + Math.Min(right1, right2)) / 2;
            }

            if (left1 > right2)
            {
                right = partition1 - 1;
            }
            else
            {
                left = partition1 + 1;
            }
        }

        throw new ArgumentException(
            "Input arrays must be sorted.");
    }
}
