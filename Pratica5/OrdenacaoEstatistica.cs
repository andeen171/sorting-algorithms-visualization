class OrdenacaoEstatistica {
    // TODO: contador de comparações e trocas
    // TODO: declarar demais métodos de ordenação
    public static int cont_c, cont_t;
    public static void Bolha(int[] vet) {
        cont_c = 0;
        cont_t = 0;
        int i, j, temp;
        for (i = 0; i < vet.Length - 1; i++) {
            for (j = vet.Length - 1; j > i; j--) {
                cont_c++;
                if (vet[j] < vet[j - 1]) {
                    temp = vet[j];
                    vet[j] = vet[j - 1];
                    vet[j - 1] = temp;
                    cont_t++;
                }
            }
        }
    }

    public static void Selecao(int[] arr)
    {
        cont_c = 0;
        cont_t = 0;
        int temp, smallest, n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            smallest = i;
            for (int j = i + 1; j < n; j++)
            {
                cont_c++;
                if (arr[j] < arr[smallest])
                {
                    smallest = j;
                }
            }
            temp = arr[smallest];
            arr[smallest] = arr[i];
            arr[i] = temp;
            cont_t++;
        }
    }

    public static void Insercao(int[] arr)
    {
        cont_c = 0;
        cont_t = 0;
        int i, key, j, n = arr.Length;
        for (i = 1; i < n; i++)
        {
            key = arr[i];
            j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
                cont_t++;
            }
            arr[j + 1] = key;
            cont_t++;
        }
    }

    public static void ShellSort(int[] arr)
    {
        cont_c = 0;
        cont_t = 0;
        int i, j, inc, temp, n = arr.Length;
        inc = 3;
        while (inc > 0)
        {
            for (i = 0; i < n; i++)
            {
                j = i;
                temp = arr[i];
                while ((j >= inc) && (arr[j - inc] > temp))
                {
                    arr[j] = arr[j - inc];
                    j = j - inc;
                    cont_t++;
                }
                arr[j] = temp;
                cont_t++;
            }
            if (inc / 2 != 0)
            {
                cont_c++;
                inc = inc / 2;
            } 
            else if (inc == 1)
            {
                cont_c += 2;
                inc = 0;
            }
            else
            {
                cont_c += 2;
                inc = 1;
            } 
        }
    }

    static void heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        cont_c++;
        if (left < n && arr[left] > arr[largest])
            largest = left;
        cont_c++;
        if (right < n && arr[right] > arr[largest])
            largest = right;
        cont_c++;
        if (largest != i)
        {
            int swap = arr[i];
            cont_t++;
            arr[i] = arr[largest];
            arr[largest] = swap;
            heapify(arr, n, largest);
        }
    }

    public static void HeapSort(int[] arr)
    {
        cont_c = 0;
        cont_t = 0;
        int n = arr.Length;
        for (int i = n / 2 - 1; i >= 0; i--)
            heapify(arr, n, i);
        for (int i = n - 1; i >= 0; i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;
            cont_t++;
            heapify(arr, i, 0);
        }
    }

    public static void QuickSort(int[] array)
    {
        cont_c = 0;
        cont_t = 0;
        Sort(ref array, 0, array.Length - 1);
    }

    private static void Sort(ref int[] Arr, int Left, int Right)
    {
        int Pivot;
        Pivot = Q_Sort(ref Arr, Left, Right);
        cont_c++;
        if (Left < Pivot - 1)
        {
            Sort(ref Arr, Left, Pivot - 1);
        }
        cont_c++;
        if (Right > Pivot + 1)
        {
            Sort(ref Arr, Pivot + 1, Right);
        }
    }

    static int Q_Sort(ref int[] Arr, int Left, int Right)
    {
        int Pivot;
        Pivot = Arr[Left];
        while (Left < Right)
        {
            while ((Arr[Right] >= Pivot) && (Left < Right))
            {
                Right--;
            }
            cont_c++;
            if (Left != Right)
            {
                cont_t++;
                Arr[Left] = Arr[Right];
                Left++;
            }
            while ((Arr[Left] <= Pivot) && (Left < Right))
            {
                Left++;
            }
            cont_c++;
            if (Left != Right)
            {
                cont_t++;
                Arr[Right] = Arr[Left];
                Right--;
            }
        }
        cont_t++;
        Arr[Left] = Pivot;
        return Left;
    }

    public static void MergeSort(int[] array)
    {
        cont_c = 0;
        cont_t = 0;
        sort(ref array, 0, array.Length - 1);
    }

    private static void sort(ref int[] array, int left, int right)
    {
        cont_c++;
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            sort(ref array, left, middle);
            sort(ref array, middle + 1, right);
            MergeArray(array, left, middle, right);
        }
    }

    public static void MergeArray(int[] array, int left, int middle, int right)
    {
        var leftArrayLength = middle - left + 1;
        var rightArrayLength = right - middle;
        var leftTempArray = new int[leftArrayLength];
        var rightTempArray = new int[rightArrayLength];
        int i, j;
        for (i = 0; i < leftArrayLength; ++i)
            leftTempArray[i] = array[left + i];
        for (j = 0; j < rightArrayLength; ++j)
            rightTempArray[j] = array[middle + 1 + j];
        i = 0;
        j = 0;
        int k = left;
        while (i < leftArrayLength && j < rightArrayLength)
        {
            cont_c++;
            if (leftTempArray[i] <= rightTempArray[j])
            {
                cont_t++;
                array[k++] = leftTempArray[i++];
            }
            else
            {
                cont_t++;
                array[k++] = rightTempArray[j++];
            }
        }
        while (i < leftArrayLength)
        {
            cont_t++;
            array[k++] = leftTempArray[i++];
        }
        while (j < rightArrayLength)
        {
            cont_t++;
            array[k++] = rightTempArray[j++];
        }
    }
}
    