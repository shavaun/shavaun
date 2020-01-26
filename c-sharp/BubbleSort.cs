using System;
using System.Collections.Generic;

namespace ArraySortingMethods
{
    class BubbleSort
    {
        public List<int> Sort(List<int> listToSort)
        {

            // TODO: Validate method
            // if(validateList(listToSort) then continue, else throw error

            // Create empty List that will contain end result
            List<int> sortedList = new List<int>();

            // This Boolean is used to track whether all elements have already been sorted
            bool movedElement = false;

            // While there are still unsorted elements, loop through the elements and perform sort
            do
            {
                movedElement = ComparePairs(listToSort, 0);

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

            // Return the final sorted list

            return sortedList;
        }
        private Boolean ComparePairs(List<int> listToSort, int mainIndex)
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
    }
}
