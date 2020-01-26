using System;
using System.Collections.Generic;

namespace SortingConsole
{
    class SortingClass
    {
			static void Main()
			{
				// Create an Array and copy to List for accessibility
				int[] originalArray = { 2, 5, 8, 1, 5, 9, 2, 73, 73, 2, 8, 51 };
				List<int> listToSort = new List<int>(originalArray);

				Console.WriteLine("Unsorted: " + string.Join("\t", listToSort));

				// Sort it
				ArraySortingMethods.BubbleSort bubbleSort = new ArraySortingMethods.BubbleSort();
				List<int> sortedList = bubbleSort.Sort(listToSort);

				Console.WriteLine("Sorted with bubble sort: " + string.Join("\t", sortedList));

			}
	}
}
