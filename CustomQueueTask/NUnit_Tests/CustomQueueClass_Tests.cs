using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomQueueT;

namespace NUnit_Tests
{
    [TestFixture]
    public class CustomQueueClass_Tests
    {
        [Test]
        public void QueueMethods_Tests()
        {
            CustomQueue<int> queueOfInts = new CustomQueue<int>(5);
            queueOfInts.Enqueue(3);
            queueOfInts.Enqueue(7);
            queueOfInts.Enqueue(2);
            queueOfInts.Enqueue(1);
            queueOfInts.Enqueue(5);
            int[] expectedRes = new int[5] {3, 7, 2, 1, 5};
            int i = 0;
            foreach (var item in queueOfInts)
            {
                Assert.AreEqual(expectedRes[i],item);
                i++;
            }
            List<double> list = new List<double>(5) {0.2,0.4,0.6,0.8, 1};
            CustomQueue<double> queueOfDoubles = new CustomQueue<double>(list);
            double[] expecteDoubles = new double[5] { 0.2, 0.4, 0.6, 0.8 ,1};
            i = 0;
            foreach (var item in queueOfDoubles)
            {
                Assert.AreEqual(expecteDoubles[i], item);
                i++;
            }

            queueOfDoubles.Dequeue();
            Assert.AreEqual(4, queueOfDoubles.Count);
            Assert.AreEqual(0.4, queueOfDoubles.Peek());
            queueOfDoubles.Dequeue();
            Assert.AreEqual(0.6, queueOfDoubles.Peek());

            string[] array = new string[3] {"Hello,", " it's", " me"};
            CustomQueue<string> queueOfStrings = new CustomQueue<string>(array);
            Assert.AreEqual(3, queueOfStrings.Capacity);
        }
    }
}
