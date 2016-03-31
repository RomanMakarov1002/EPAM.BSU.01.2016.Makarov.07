using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Logic
{
    public static class Fibonacci
    {
        private static uint _numberOne = 1;
        private static uint _numberTwo = 0;
        private static uint _current;
        
        public static IEnumerable<uint> FibonacciSequence()
        {
            while (true)
            {
                try
                {
                    checked
                    {
                        _current = _numberOne + _numberTwo;
                    }
                }
                catch (OverflowException)
                {                    
                    yield break;
                }
                                                
                yield return _current;
                _numberOne = _numberTwo;
                _numberTwo = _current;               
                Thread.Sleep(500);
            }           
        }
    }
}
