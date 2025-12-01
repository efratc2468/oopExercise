using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex01
{

    class Program
    {
        class MyClass
        {
            public int Number;
        }

        struct MyStruct
        {
            public int Number;
        }

        static void Main()
        {
            Console.WriteLine("=== השמה בין משתנים ===");


            MyClass class1 = new MyClass { Number = 10 };
            MyClass class2 = class1;
            class2.Number = 20;

            Console.WriteLine($"class1.Number = {class1.Number}");
            Console.WriteLine($"class2.Number = {class2.Number}");


            MyStruct struct1 = new MyStruct { Number = 10 };
            MyStruct struct2 = struct1;
            struct2.Number = 20;

            Console.WriteLine($"struct1.Number = {struct1.Number}");
            Console.WriteLine($"struct2.Number = {struct2.Number}");

            ChangeClass(class1);
            Console.WriteLine($"class1.Number אחרי פונקציה = {class1.Number}"); // 100


            ChangeStruct(struct1);
            Console.WriteLine($"struct1.Number אחרי פונקציה = {struct1.Number}"); // 10 (לא השתנה)


            ChangeStructRef(ref struct1);
            Console.WriteLine($"struct1.Number אחרי ChangeStructRef = {struct1.Number}"); // 200
        }

        static void ChangeClass(MyClass c)
        {
            c.Number = 100;
        }

        static void ChangeStruct(MyStruct s)
        {
            s.Number = 100;
        }

        static void ChangeStructRef(ref MyStruct s)
        {
            s.Number = 200;
        }

    }
}