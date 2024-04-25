using System;
using System.Diagnostics;

// ���׸� �̱��� Ŭ���� ����
public class MySingleton<T> where T : new()
{
    // �̱��� �ν��Ͻ��� ������ ���� ����
    protected static T _singleton;

    // �̱��� �ν��Ͻ��� ��ȯ�ϴ� �޼���
    public static T GetSingleton()
    {
        // ���� �������� �ʾ����� �����մϴ�.
        if (_singleton == null)
        {
            _singleton = new T();
        }

        return _singleton;
    }

    // �̱��� �ν��Ͻ��� �����ϴ� �޼���
    public static void Release()
    {
        // �̱��� �ν��Ͻ��� �⺻������ �����Ͽ� �����մϴ�.
        _singleton = default(T);
    }
    public static T ReturnValueInParent()
    {
        return _singleton;
    }
    public static T AddValueInParent(T Value)
    {
        _singleton = Value;
        return _singleton;
    }
}

// MySingleton Ŭ������ ��ӹ޴� MyObject Ŭ���� ����
public class MyObject : MySingleton<MyObject>
{
    // ��� ���� ���� �� �ʱⰪ ����
    private int _value = 10;

    // ���� �����ϴ� �޼���
    public void SetValue(int value)
    {
        _value = value;
    }

    // ���� ��ȯ�ϴ� �޼���
    public int GetValue()
    {
        return _value;
    }
}   
public class MySingletonInt : MySingleton<int>
{
    static public int IsItIntOnly()
    {
        _singleton = -100;
        return _singleton;
    }
}
public class GimoTTi : MySingleton<GimoTTi>
{

}

// ���α׷� ������ �� ���� �ڵ�
public class Program
{
    public static void Main(string[] args)
    {
        // MyObject Ŭ������ �̱��� �ν��Ͻ� ����
        MyObject myObj1 = MyObject.GetSingleton();

        // �ν��Ͻ��� �� ���
        Console.WriteLine(myObj1.GetValue());

        // MyObj2�� MyObj1�� ������ ��ü�Դϴ�.
        MyObject myObj2 = MyObject.GetSingleton();

        // �ν��Ͻ��� ���� ����
        myObj2.SetValue(20);

        // ����� �� ���
        Console.WriteLine(myObj1.GetValue());
        Console.WriteLine(myObj2.GetValue());
    }
}
