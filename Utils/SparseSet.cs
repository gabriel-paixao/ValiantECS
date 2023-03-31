using System.Collections.Generic;

namespace ValiantECS.Utils
{
    public class SparseSet
    {
        private List<int> sparse;
        private List<int> dense;
        private int count;

        public SparseSet()
        {
            sparse = new List<int>();
            dense = new List<int>();
            count = 0;
        }

        public void Add(int index)
        {
            if (index >= sparse.Count)
            {
                sparse.AddRange(new int[index - sparse.Count + 1]);
            }

            sparse[index] = count;
            dense.Add(index);
            count++;
        }

        public void Remove(int index)
        {
            if (!Contains(index)) return;

            int last = dense[count - 1];
            sparse[last] = sparse[index];
            dense[sparse[index]] = last;
            count--;
        }

        public bool Contains(int index)
        {
            return index < sparse.Count && sparse[index] < count && dense[sparse[index]] == index;
        }

        public int GetDenseIndex(int index)
        {
            return sparse[index];
        }
    }
}
