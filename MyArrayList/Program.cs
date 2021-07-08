using System;

namespace MyArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomCollections.ArrayList<int> test = new CustomCollections.ArrayList<int>();
            test.Add(5);
            test.Add(1);
            test.Add(12);
            test.Add(20);
            test.Add(80);
            test.Add(19);
            test.Add(11);
            test.Add(27);
            test.Add(293);
            test.Add(128);

            CustomCollections.ArrayList<int> testcopy = new CustomCollections.ArrayList<int>();
            testcopy.AddAll(test);
            testcopy.AddAll(test);
            testcopy.AddAll(test);
            testcopy.AddAll(test);

            Console.WriteLine($"We are deleting {testcopy.Remove(2)} value");

            Console.WriteLine($"ArrayList has {testcopy.Size} values and the 39º value is {testcopy.Get(38)}. Buffer size is {testcopy.Capacity}");

            foreach (int value in testcopy)
            {
                Console.WriteLine(value);
            }
        }
    }
}
