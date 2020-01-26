using System;
using System.Collections.Generic;

namespace CodeSamples
{
    class CustomArrayMethods
    {
        public Boolean ComparePairs(List<int> listToSort, int mainIndex)
        {
            bool movedElement = false;
            // Inner loop to compare each pair of consecutive elements
            do
            {
                // Make sure larger value comes after lower value
                if (listToSort[mainIndex] >= listToSort[mainIndex + 1])
                {
                    int valueToMove = listToSort[mainIndex];
                    listToSort.RemoveAt(mainIndex);
                    listToSort.Insert(mainIndex + 1, valueToMove);
                    movedElement = true;
                }
                mainIndex++;
            }
            while (mainIndex < listToSort.Count - 1);
            return movedElement;
        }

        static void Main()
        {
            // Create an Array and copy to List for accessibility
            CustomArrayMethods arrayClass = new CustomArrayMethods();
            int[] originalArray = { 2, 5, 8, 1, 5, 9, 2, 73, 73, 2, 8, 51 };
            List<int> listToSort = new List<int>(originalArray);

            // Create empty List that will contain end result
            List<int> sortedList = new List<int>();

            // This Boolean is used to track whether all elements have already been sorted
            bool movedElement = false;

            // Print the unsorted original list
            Console.WriteLine(string.Join("\t", listToSort));

            // While there are still unsorted elements, loop through the elements and perform sort
            do
            {
                movedElement = arrayClass.ComparePairs(listToSort, 0);
                
                // If an element was moved due to being out of place, 
                // take the last element from list and add it to the sorted list
                if (movedElement)
                {
                    sortedList.Insert(0, listToSort[listToSort.Count - 1]);
                    listToSort.RemoveAt(listToSort.Count - 1);
                }
                else // if no element was moved, the remaining elements in listToSort are already in order, so add the remaining elements to sorted list
                {
                    sortedList.InsertRange(0, listToSort);
                    break;
                }
            }
            while (movedElement);
       
            // Print the final sorted list
            Console.WriteLine("\n");
            Console.WriteLine(string.Join("\t", sortedList));
            Console.WriteLine("\n");
            Console.ReadKey();
        }

    }
}
