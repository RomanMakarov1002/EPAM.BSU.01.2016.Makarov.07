using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Task4Logic;

namespace NUnit_Tests
{
    [TestFixture]
    public class Task4Tests
    {
        private static int Cmp(int x, int y)
        {
            return x.CompareTo(y);
        }

        private static int Cmp4Double(double x, double y)
        {
            return x.CompareTo(y);
        }

        [Test]
        public void BinarySearch_Test()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int[] arr = new int[5] { 1, 2, 5, 8, 9 };
            string[] arrWithStrings = new string[8] {"a", "ab", "abc", "abcd", "abcdef", "fsfsfsfs", "ttttttttt", "whahahahahaha"};
            string str = "was";
            double[] arr2 = new double[8] {0.0, 0.2, 0.4, 0.6, 0.8, 1, 1.2, 1.4};
            Assert.AreEqual(BinarySearch.Search(arr,2,Cmp),1);
            Assert.AreEqual(BinarySearch.Search(arr, 8, Cmp), 3);
            Assert.AreEqual(BinarySearch.Search(arr2, 0.2, Cmp4Double ), 1);
            Assert.AreEqual(BinarySearch.Search(arr2, 1.4, Cmp4Double), 7);
            Assert.AreEqual(BinarySearch.Search(arrWithStrings, "a", String.Compare), 0);
            Assert.AreEqual(BinarySearch.Search(arrWithStrings, "abcd", String.Compare), 3);
            Assert.AreEqual(BinarySearch.Search(arrWithStrings, "Hello", String.Compare), -1);
        }
    }
}
