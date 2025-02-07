using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROPGadgetFinder
{
    internal static class Extensions
    {
        public static IList<T> MoveUp<T>(this IList<T> list, int index)
        {
            if (index > 0 && index < list.Count)
            {
                (list[index], list[index - 1]) = (list[index - 1], list[index]);
            }
            return list;
        }

        public static ListBox.ObjectCollection MoveUp(this ListBox.ObjectCollection list, int index)
        {
            if (index > 0 && index < list.Count)
            {
                (list[index], list[index - 1]) = (list[index - 1], list[index]);
            }
            return list;
        }

        public static IList<T> MoveDown<T>(this IList<T> list, int index)
        {
            if (index >= 0 && index < list.Count - 1)
            {
                (list[index], list[index + 1]) = (list[index + 1], list[index]);
            }
            return list;
        }
        public static ListBox.ObjectCollection MoveDown(this ListBox.ObjectCollection list, int index)
        {
            if (index >= 0 && index < list.Count - 1)
            {
                (list[index], list[index + 1]) = (list[index + 1], list[index]);
            }
            return list;
        }
    }
}
