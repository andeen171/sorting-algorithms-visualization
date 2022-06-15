using System.Threading;
using System.Windows.Forms;
class OrdenacaoGrafica {
    // intODO: declarar demais métodos de ordenação
    public static void Bolha(int[] vet, Panel p) {
        int i, j, temp;
        for (i = 0; i < vet.Length - 1; i++) {
            for (j = vet.Length - 1; j > i; j--) {
                if (vet[j] < vet[j - 1]) {
                    temp = vet[j];
                    vet[j] = vet[j - 1];
                    vet[j - 1] = temp;
                }
            }
            p.Invalidate(); // redesenha o painel
            Thread.Sleep(10); // espera 10 milisegundos
        }
    }

    public static void Selecao(int[] arr, Panel p)
    {
        int temp, smallest, n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            smallest = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[smallest])
                {
                    smallest = j;
                }
            }
            temp = arr[smallest];
            arr[smallest] = arr[i];
            arr[i] = temp;
            p.Invalidate(); // redesenha o painel
            Thread.Sleep(10); // espera 10 milisegundos
        }
    }

    public static void Insercao(int[] arr, Panel p)
    {
        int i, key, j, n = arr.Length;
        for (i = 1; i < n; i++)
        {
            key = arr[i];
            j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
            p.Invalidate(); // redesenha o painel
            Thread.Sleep(10); // espera 10 milisegundos
        }
    }

    public static void ShellSort(int[] arr, Panel p)
    {
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
                }
                arr[j] = temp;
                p.Invalidate(); // redesenha o painel
                Thread.Sleep(10); // espera 10 milisegundos
            }
            if (inc / 2 != 0)
                inc = inc / 2;
            else if (inc == 1)
                inc = 0;
            else
                inc = 1;
        }
    }

    static void heapify(int[] arr, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;
        if (left < n && arr[left] > arr[largest])
            largest = left;
        if (right < n && arr[right] > arr[largest])
            largest = right;
        if (largest != i)
        {
            int swap = arr[i];
            arr[i] = arr[largest];
            arr[largest] = swap;
            heapify(arr, n, largest);
        }
    }

    public static void HeapSort(int[] arr, Panel p)
    {
        int n = arr.Length;
        for (int i = n / 2 - 1; i >= 0; i--)
            heapify(arr, n, i);
        for (int i = n - 1; i >= 0; i--)
        {
            int temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;
            p.Invalidate(); // redesenha o painel
            Thread.Sleep(10); // espera 10 milisegundos
            heapify(arr, i, 0);
        }
    }

    public static void QuickSort(int[] array, Panel p)
    {
        Sort(ref array, 0, array.Length - 1, p);
    }

    private static void Sort(ref int[] Arr, int Left, int Right, Panel panel)
    {
        int Pivot;
        Pivot = Q_Sort(ref Arr, Left, Right, panel);
        if (Left < Pivot - 1)
        {
            Sort(ref Arr, Left, Pivot - 1, panel);
        }
        if (Right > Pivot + 1)
        {
            Sort(ref Arr, Pivot + 1, Right, panel);
        }
    }

    static int Q_Sort(ref int[] Arr, int Left, int Right, Panel panel)
    {
        int Pivot;
        Pivot = Arr[Left];
        while (Left < Right)
        {
            while ((Arr[Right] >= Pivot) && (Left < Right))
            {
                Right--;
            }
            if (Left != Right)
            {
                Arr[Left] = Arr[Right];
                Left++;
            }
            while ((Arr[Left] <= Pivot) && (Left < Right))
            {
                Left++;
            }
            if (Left != Right)
            {
                Arr[Right] = Arr[Left];
                Right--;
            }
        }
        Arr[Left] = Pivot;
        panel.Invalidate(); // redesenha o painel
        Thread.Sleep(10); // espera 10 milisegundos
        return Left;
    }

    public static void MergeSort(int[] array, Panel p)
    {
        sort(ref array, 0, array.Length - 1, p);
    }

    private static void sort(ref int[] array, int left, int right, Panel p)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            sort(ref array, left, middle, p);
            sort(ref array, middle + 1, right, p);
            MergeArray(array, left, middle, right, p);
        }
    }

    public static void MergeArray(int[] array, int left, int middle, int right, Panel p)
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
            if (leftTempArray[i] <= rightTempArray[j])
            {
                array[k++] = leftTempArray[i++];
            }
            else
            {
                array[k++] = rightTempArray[j++];
            }
        }
        while (i < leftArrayLength)
        {
            array[k++] = leftTempArray[i++];
        }
        while (j < rightArrayLength)
        {
            array[k++] = rightTempArray[j++];
        }
        p.Invalidate(); // redesenha o painel
        Thread.Sleep(10); // espera 10 milisegundos
    }
}
