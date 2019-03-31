using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 迭代器
{

    class Program
    {
        #region 数据源
        private static string[] strList = new string[]
        { 
            "test111",
            "test222",
            "test333",
            "test444",
            "test555"
        };
        #endregion 

        static void Main(string[] args)
        {
            //方法1
            Console.WriteLine("方法1：IEnumerator");
            MyIEnumerable1 my1 = new MyIEnumerable1(strList);
            IEnumerator tst = my1.GetEnumerator();

            //第一步：获取IEnumerator接口实例
            while (tst.MoveNext())//第二步：判断是否可以继续循环
            {
                Console.WriteLine(tst.Current);
            }

            //foreach (var item in my1)
            //{
            //    Console.WriteLine(item);
            //}

            //方法2
            Console.WriteLine("方法2：实现IEnumerator");
            MyIEnumerator2 my2 = new MyIEnumerator2(strList);
            //var list = my2.MyWhere(t => t.Contains("111"));//调用MyWhere
            //var listStr = list.ToList();
            //Console.WriteLine(listStr[0]);
            while (my2.MoveNext())
            {
                Console.WriteLine(my2.Current);
            }

            Console.ReadKey();
        }
    }


    //方法1
    //在类中提供一个迭代器IEnumerator GetEnumerator 而不必实现整个IEnumerable接口. 
    //当编译器检测到迭代器时,自动生成IEnumerable 或 IEnumerable<T>接口的Current、MoveNext和Dispose方法
    public class MyIEnumerable1
    {
        private string[] strList;
        public MyIEnumerable1(string[] _strList)
        {
            strList = _strList;
        }
        public IEnumerator GetEnumerator()
        {
            //return new MyIEnumerator2(strList);
            for (int i = 0; i < strList.Length; i++)
            {
                yield return strList[i];
            }
            //return this.strList.GetEnumerator();
        }
    }

    //方法2
    //继承接口IEnumerator并实现
    public class MyIEnumerator2 : IEnumerator
    {
        private string[] strList;
        private int position;
        public MyIEnumerator2(string[] _strList)
        {
            strList = _strList;
            position = -1;
        }
        public object Current
        {
            get { return strList[position]; }
        }
        public bool MoveNext()
        {
            position++;
            if (position < strList.Length)
                return true;
            return false;
        }
        public void Reset()
        {
            position = -1;
        }
    }


    //public class MyIEnumerable3 : IEnumerable
    //{
    //    private string[] strList;
    //    public MyIEnumerable3(string[] _strList)
    //    {
    //        strList = _strList;
    //    }

    //    public IEnumerator GetEnumerator()
    //    {
    //        for (int i = 0; i < strList.Length; i++)
    //        {
    //            yield return strList[i];
    //        }
    //    }

    //    public IEnumerable<string> MyWhere(Func<string, bool> func)
    //    {
    //        foreach (string item in this)
    //        {
    //            if (func(item))
    //            {
    //                yield return item;
    //            }
    //        }
    //    }
    //}
}
