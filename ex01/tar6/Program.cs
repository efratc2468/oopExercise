using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tar6
{

        struct SmallStruct
        {
            public int A;
            public int B;
        }

        struct BigStruct
        {
            public int A;
            public int B;
            public int C;
            public int D;
            public long E;
            public double F;
        }

        class SmallClass
        {
            public int A;
            public int B;
        }

        class BigClass
        {
            public int A;
            public int B;
            public int C;
            public int D;
            public long E;
            public double F;
        }

        class Program
        {
            public static void MemoryAllocationExperiment()
            {
                const int N = 10000;

                long baselineMemory = GC.GetAllocatedBytesForCurrentThread();

                // ========= סעיף א' – מערכים בסיסיים =========

                int[] intArray = new int[N];
                long afterIntArray = GC.GetAllocatedBytesForCurrentThread();

                double[] doubleArray = new double[N];
                long afterDoubleArray = GC.GetAllocatedBytesForCurrentThread();

                string[] stringArray = new string[N];
                long afterStringArray = GC.GetAllocatedBytesForCurrentThread();

                Console.WriteLine("=== Basic Arrays ===");
                Console.WriteLine($"Int array allocation: {afterIntArray - baselineMemory} bytes");
                Console.WriteLine($"Double array allocation: {afterDoubleArray - afterIntArray} bytes");
                Console.WriteLine($"String array allocation: {afterStringArray - afterDoubleArray} bytes");

                // ========= סעיף ב' – STRUCT ARRAYS =========

                SmallStruct[] smallStructArray = new SmallStruct[N];
                long afterSmallStructs = GC.GetAllocatedBytesForCurrentThread();

                BigStruct[] bigStructArray = new BigStruct[N];
                long afterBigStructs = GC.GetAllocatedBytesForCurrentThread();

                Console.WriteLine("\n=== Struct Arrays ===");
                Console.WriteLine($"SmallStruct array allocation: {afterSmallStructs - afterStringArray} bytes");
                Console.WriteLine($"BigStruct array allocation: {afterBigStructs - afterSmallStructs} bytes");

                // ========= סעיף ג' – CLASS ARRAYS =========

                SmallClass[] smallClassArray = new SmallClass[N];
                long afterSmallClasses = GC.GetAllocatedBytesForCurrentThread();

                // הקצאת כל אובייקט בפועל
                for (int i = 0; i < N; i++)
                    smallClassArray[i] = new SmallClass();

                long afterSmallClassObjects = GC.GetAllocatedBytesForCurrentThread();

                BigClass[] bigClassArray = new BigClass[N];
                long afterBigClassesArray = GC.GetAllocatedBytesForCurrentThread();

                for (int i = 0; i < N; i++)
                    bigClassArray[i] = new BigClass();

                long afterBigClassObjects = GC.GetAllocatedBytesForCurrentThread();

                Console.WriteLine("\n=== Class Arrays ===");
                Console.WriteLine($"SmallClass array only: {afterSmallClasses - afterBigStructs} bytes");
                Console.WriteLine($"SmallClass objects: {afterSmallClassObjects - afterSmallClasses} bytes");

                Console.WriteLine($"BigClass array only: {afterBigClassesArray - afterSmallClassObjects} bytes");
                Console.WriteLine($"BigClass objects: {afterBigClassObjects - afterBigClassesArray} bytes");
            }

            static void Main()
            {
                MemoryAllocationExperiment();
            }

        }

    }
