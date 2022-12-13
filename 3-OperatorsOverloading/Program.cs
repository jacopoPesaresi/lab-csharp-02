namespace OperatorsOverloading
{
    using System;

    /// <summary>
    /// The runnable entrypoint of the exercise.
    /// </summary>
    public class Program
    {
        /// <inheritdoc cref="Program" />
        public static void Main()
        {
            List<int> lst = List.From(1, 2, 3, 4, 5);

            int[] res1 = new int[] { 3, 4, 5, 4, 3 };

            // here { ... } is the same as new int[] { ... }
            int[] res2 = { 3, 4, 4, 3 };

            List<int> lst1 = List.Append(lst.Tail.Tail, List.From(4, 3));

            // Look at this cast!
            // It is possible because of the conversion operator implemented in list
            // Because it is implicit, we can also remove the cast here
            if (lst1 != (List<int>) res1)
            {
                throw new Exception("Wrong implementation");
            }

            List<int> lst2 = lst;
            lst2 += List.From(4, 3);

            if (lst2.Tail.Tail != lst1)
            {
                throw new Exception("Wrong implementation");
            }

            List<int> lst3 = lst2;
           
            // Look at this assignment!
            // It is possible because of the implicit conversion operator implemented in list
            lst3 -= 5;

            if (lst3.Tail.Tail != res2)
            {
                throw new Exception("Wrong implementation");
            }

            if (lst3 <= lst1)
            {
                throw new Exception("Wrong implementation");
            }

            if (lst1 >= lst2)
            {
                throw new Exception("Wrong implementation");
            }

            Console.WriteLine("Ok");
        }
    }
}
