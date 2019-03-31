# IEnumerator-
IEnumerator迭代器实现有以下两种方法
//方法1
//在类中提供一个迭代器IEnumerator GetEnumerator 而不必实现整个IEnumerable接口. 
//当编译器检测到迭代器时,自动生成IEnumerable 或 IEnumerable<T>接口的Current、MoveNext和Dispose方法

//方法2
//继承接口IEnumerator并实现Current，MoveNext，Reset
