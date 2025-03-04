public class Sorting
{
    // Bubble Sort
    public static DynamicArray BubbleSort(DynamicArray array)
    {
        int n = array.Size();

       
        DynamicArray tempArray = new DynamicArray();

        for (int i = 0; i < n; i++)
        {
            tempArray.Add(array.Get(i));
        }

        
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (string.Compare(tempArray.Get(j).Name, tempArray.Get(j + 1).Name, StringComparison.OrdinalIgnoreCase) > 0)
                {
                    Swap(tempArray, j, j + 1);
                }
            }
        }

       
        return tempArray;
    }

    
    private static void Swap(DynamicArray array, int i, int j)
    {
        Contact temp = array.Get(i);
        array.Set(i, array.Get(j)); 
        array.Set(j, temp);
    }
    public static DynamicArray MergeSort(DynamicArray array)
    {
        int n = array.Size();

       
        DynamicArray tempArray = new DynamicArray();
        for (int i = 0; i < n; i++)
        {
            tempArray.Add(array.Get(i));
        }

        
        MergeSortHelper(tempArray, 0, n - 1);

        
        return tempArray;
    }

    private static void MergeSortHelper(DynamicArray array, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;

           
            MergeSortHelper(array, left, mid);
            MergeSortHelper(array, mid + 1, right);

           
            Merge(array, left, mid, right);
        }
    }

    private static void Merge(DynamicArray array, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

       
        DynamicArray leftArray = new DynamicArray();
        DynamicArray rightArray = new DynamicArray();

        
        for (int i = 0; i < n1; i++)
            leftArray.Add(array.Get(left + i));
        for (int j = 0; j < n2; j++)
            rightArray.Add(array.Get(mid + 1 + j));

        int iIndex = 0, jIndex = 0, k = left;

        
        while (iIndex < n1 && jIndex < n2)
        {
            if (string.Compare(leftArray.Get(iIndex).Name, rightArray.Get(jIndex).Name, StringComparison.OrdinalIgnoreCase) <= 0)
            {
                array.Set(k, leftArray.Get(iIndex));
                iIndex++;
            }
            else
            {
                array.Set(k, rightArray.Get(jIndex));
                jIndex++;
            }
            k++;
        }

        
        while (iIndex < n1)
        {
            array.Set(k, leftArray.Get(iIndex));
            iIndex++;
            k++;
        }

        
        while (jIndex < n2)
        {
            array.Set(k, rightArray.Get(jIndex));
            jIndex++;
            k++;
        }
    }
}

