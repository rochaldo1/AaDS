namespace AaDS_1
{
    public class SortingAlgorithms
    {
        public static List<int> InsertionSort(List<int> list)
        {
            List<int> sortedList = new List<int>(list);
            for (int i = 1; i < sortedList.Count; i++)
            {
                int key = sortedList[i];
                int j = i - 1;

                while (j >= 0 && sortedList[j] > key)
                {
                    sortedList[j + 1] = sortedList[j];
                    j--;
                }
                sortedList[j + 1] = key;
            }
            return sortedList;
        }

        public static List<int> QuickSort(List<int> list)
        {
            List<int> sortedList = new List<int>(list);
            QuickSortRecursive(sortedList, 0, sortedList.Count - 1);
            return sortedList;
        }

        private static void QuickSortRecursive(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(list, left, right);
                QuickSortRecursive(list, left, pivot - 1);
                QuickSortRecursive(list, pivot + 1, right);
            }
        }

        private static int Partition(List<int> list, int left, int right)
        {
            int pivot = list[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (list[j] < pivot)
                {
                    i++;
                    Swap(list, i, j);
                }
            }
            Swap(list, i + 1, right);
            return i + 1;
        }

        public static List<int> MergeSort(List<int> list)
        {
            List<int> sortedList = new List<int>(list);
            MergeSortRecursive(sortedList, 0, sortedList.Count - 1);
            return sortedList;
        }

        private static void MergeSortRecursive(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                MergeSortRecursive(list, left, middle);
                MergeSortRecursive(list, middle + 1, right);
                Merge(list, left, middle, right);
            }
        }

        private static void Merge(List<int> list, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(list.ToArray(), left, leftArray, 0, n1);
            Array.Copy(list.ToArray(), middle + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;
            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    list[k] = leftArray[i];
                    i++;
                }
                else
                {
                    list[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                list[k] = leftArray[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                list[k] = rightArray[j];
                j++;
                k++;
            }
        }

        public static List<int> HeapSort(List<int> list)
        {
            List<int> sortedList = new List<int>(list);
            int n = sortedList.Count;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(sortedList, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                Swap(sortedList, 0, i);
                Heapify(sortedList, i, 0);
            }

            return sortedList;
        }

        private static void Heapify(List<int> list, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && list[left] > list[largest])
                largest = left;

            if (right < n && list[right] > list[largest])
                largest = right;

            if (largest != i)
            {
                Swap(list, i, largest);
                Heapify(list, n, largest);
            }
        }

        private static void Swap(List<int> list, int i, int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
