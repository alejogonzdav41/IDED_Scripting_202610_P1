namespace IDED_Scripting_202610_P1
{
    internal class TestMethods
    {
        /*public static void SeparateElements(Queue<int> input, out Stack<int> included, out Stack<int> excluded)
        {
            included = null;
            excluded = null;
        }
        */
        public static void SeparateElements(Queue<int> input, out Stack<int> included, out Stack<int> excluded)
        {
            included = new Stack<int>();
            excluded = new Stack<int>();

            while (input.Count > 0)
            {
                int value = input.Dequeue();

                if (BelongsToSeries(value))
                    included.Push(value);
                else
                    excluded.Push(value);
            }
        }

        private static bool BelongsToSeries(int value)
        {
            if (value == 0) return true;

            int abs = value < 0 ? -value : value;

            int root = (int)System.Math.Sqrt(abs);

            if (root * root != abs)
                return false;

            // Regla de signo:
            // raíz PAR -> positivo
            // raíz IMPAR -> negativo

            if (root % 2 == 0 && value > 0)
                return true;

            if (root % 2 != 0 && value < 0)
                return true;

            return false;
        }

        /*
        public static List<int> GenerateSortedSeries(int n) => null;
        */

        public static List<int> GenerateSortedSeries(int n)
        {
            List<int> list = new List<int>();

            // Generar desde 0 hasta n-1
            for (int i = 0; i < n; i++)
            {
                int value = i * i;

                if (i % 2 != 0)
                    value = -value;

                list.Add(value);
            }

            // Ordenamiento ascendente (sin Sort())
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = 0; j < list.Count - i - 1; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        int temp = list[j];
                        list[j] = list[j + 1];
                        list[j + 1] = temp;
                    }
                }
            }

            return list;
        }

        /*
        public static bool FindNumberInSortedList(int target, in List<int> list) => false;
        */

        public static bool FindNumberInSortedList(int target, in List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == target)
                    return true;
            }

            return false;
        }

        /*
        public static int FindPrime(in Stack<int> list) => 0;
        */

        public static int FindPrime(in Stack<int> list)
        {
            Stack<int> temp = new Stack<int>();

            // Invertir pila para buscar desde el "fondo"
            foreach (int value in list)
                temp.Push(value);

            while (temp.Count > 0)
            {
                int value = temp.Pop();

                if (IsPrime(value))
                    return value;
            }

            return 0;
        }

        public static bool IsPrime(int n) => false;

        /*
        public static Stack<int> RemoveFirstPrime(in Stack<int> stack) => null;
        */
        public static Stack<int> RemoveFirstPrime(in Stack<int> stack)
        {
            Stack<int> temp = new Stack<int>();
            Stack<int> result = new Stack<int>();

            // Invertir
            foreach (int value in stack)
                temp.Push(value);

            bool removed = false;

            while (temp.Count > 0)
            {
                int value = temp.Pop();

                if (!removed && IsPrime(value))
                {
                    removed = true;
                    continue;
                }

                result.Push(value);
            }

            return result;
        }

        /*
        public static Queue<int> QueueFromStack(Stack<int> stack) => null;
        */
        public static Queue<int> QueueFromStack(Stack<int> stack)
        {
            Queue<int> queue = new Queue<int>();
            Stack<int> temp = new Stack<int>();

            // Invertir pila
            foreach (int value in stack)
                temp.Push(value);

            while (temp.Count > 0)
                queue.Enqueue(temp.Pop());

            return queue;
        }
    }
}