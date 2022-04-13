using System;
using System.Collections.Generic;
using System.Linq;

namespace Music_Player
{
    class MergeSorter
    {
        /// <summary>
        /// Generic Merge sort for LinkedLists.
        /// </summary>
        /// <typeparam name="T">IComparable data type.</typeparam>
        /// <param name="unsortedList">The LinkedList to sort.</param>
        /// <returns>A new sorted LinkedList.</returns>
        public LinkedList<T> Sort<T>(LinkedList<T> unsortedList) where T : IComparable<T>
        {
            if (!(unsortedList == null || unsortedList.Count() == 0))
            {
                var listToSort = new List<T>(unsortedList);

                MergeSort(0, listToSort.Count - 1, listToSort);
                return new LinkedList<T>(listToSort);
            }
            return unsortedList;
        }

        /// <summary>
        /// This method is called recursively to separate the array into sub arrays.
        /// </summary>
        /// <param name="startIndex">The index of the first place in this sub array.</param>
        /// <param name="endIndex">The last index of this sub array.</param>
        private void MergeSort<T>(int startIndex, int endIndex, List<T> listToSort) where T : IComparable<T>
        {
            if (startIndex < endIndex && (endIndex - startIndex) >= 1)
            {
                int mid = (endIndex + startIndex) / 2;

                MergeSort(startIndex, mid, listToSort);
                MergeSort(mid + 1, endIndex, listToSort);

                Merge(startIndex, mid, endIndex, listToSort);
            }
        }

        /// <summary>
        /// This method does all the sorting and merging of the sub arrays.
        /// </summary>
        /// <param name="startIndex">The index of the first place in the sub array.</param>
        /// <param name="midIndex">The middle index of the sub array.</param>
        /// <param name="endIndex">The index of the last place in the sub array.</param>
        private void Merge<T>(int startIndex, int midIndex, int endIndex, List<T> originalList) where T : IComparable<T>
        {
            var tempItemStorage = new List<T>();
            int leftIndex = startIndex;
            int rightIndex = midIndex + 1;

            // Add items to the storage list in ascending order.
            while (leftIndex <= midIndex && rightIndex <= endIndex)
            {
                T leftItem = originalList[leftIndex];
                T rightItem = originalList[rightIndex];

                if (leftItem.CompareTo(rightItem) <= 0)
                {
                    tempItemStorage.Add(originalList[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    tempItemStorage.Add(originalList[rightIndex]);
                    rightIndex++;
                }
            }

            // Add any remaining items to the storage list.
            while (leftIndex <= midIndex)
            {
                tempItemStorage.Add(originalList[leftIndex]);
                leftIndex++;
            }
            while (rightIndex <= endIndex)
            {
                tempItemStorage.Add(originalList[rightIndex]);
                rightIndex++;
            }

            // Move items from the temp storage to the original list.
            int j = startIndex;
            for (int i = 0; i < tempItemStorage.Count(); i++)
            {
                originalList[j] = tempItemStorage[i];
                j++;
            }
        }

    }
}
