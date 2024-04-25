using System;
using System.Diagnostics;

// 제네릭 싱글톤 클래스 정의
public class MySingleton<T> where T : new()
{
    // 싱글톤 인스턴스를 저장할 정적 변수
    protected static T _singleton;

    // 싱글톤 인스턴스를 반환하는 메서드
    public static T GetSingleton()
    {
        // 아직 생성되지 않았으면 생성합니다.
        if (_singleton == null)
        {
            _singleton = new T();
        }

        return _singleton;
    }

    // 싱글톤 인스턴스를 해제하는 메서드
    public static void Release()
    {
        // 싱글톤 인스턴스를 기본값으로 설정하여 해제합니다.
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

// MySingleton 클래스를 상속받는 MyObject 클래스 정의
public class MyObject : MySingleton<MyObject>
{
    // 멤버 변수 선언 및 초기값 설정
    private int _value = 10;

    // 값을 설정하는 메서드
    public void SetValue(int value)
    {
        _value = value;
    }

    // 값을 반환하는 메서드
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

// 프로그램 진입점 및 실행 코드
public class Program
{
    public static void Main(string[] args)
    {
        // MyObject 클래스의 싱글톤 인스턴스 생성
        MyObject myObj1 = MyObject.GetSingleton();

        // 인스턴스의 값 출력
        Console.WriteLine(myObj1.GetValue());

        // MyObj2는 MyObj1과 동일한 객체입니다.
        MyObject myObj2 = MyObject.GetSingleton();

        // 인스턴스의 값을 변경
        myObj2.SetValue(20);

        // 변경된 값 출력
        Console.WriteLine(myObj1.GetValue());
        Console.WriteLine(myObj2.GetValue());
    }
}
