using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;

using UnityEngine;


public class GenericTest
{

    public T log<T>(T a,T b)
    {
        T tempT = (dynamic)a + (dynamic)b;
        return tempT;
    }
    public T1 log<T1,T2>(T1 a,T2 b)
    {
        T1 tempT = (dynamic)a + (dynamic)b;
        return tempT;
    }

    public T sum<T>(ref T a,ref int b)
    {
        T tempT = log<T,int>(a, b);
        //제네릭 함수의(C++에선 템플릿) 전문화
        return tempT;
    }
    public void TestTempleteClass()
    {
        TempleteStudyQueue<GameObject> tempQueue = new TempleteStudyQueue<GameObject>();
    }

}

public class TempleteStudyQueue<T> 
{
    T[] datas;
    int maxSize;
    int nowCount = 0;
    private int NowCount
    {
        get 
        { 
            return nowCount;
        }
        set 
        {
            if (maxSize < value)
            {
                nowCount = maxSize;
                return;

            }
            else if(0 > value) 
            {
                nowCount = 0;
                return;
            }
            nowCount = value;
        }
    }
    private int FindArray
    {
        get
        {
            if (NowCount - 1 >= 0)
            {
                return NowCount - 1;
            }
            else
            {
                return 0;
            }
        }
    }
    public T this[int index]
    {
        get { return datas[index]; }
        set { datas[index] = value; }
    } 
    public TempleteStudyQueue(int setMaxSize = 100)
    {
        maxSize = setMaxSize;
        datas= new T[0];
    }
    public int Lenght
    {
        get
        {
            return NowCount;
        }
    }
    public void Clear()
    {
        Array.Resize(ref datas,0);
        NowCount = 0;
    }
    public void enqueue(T target)
    {
        if (NowCount< maxSize)
        {
            //0부터 먼저 들어온 데이터를 넣어줌
            NowCount++;
            Array.Resize(ref datas, NowCount);
            Debug.Log(FindArray);
            datas[FindArray] = target;
        }
        else
        {
            T lastTInQueue;
            for (int i = 0; i < NowCount; i++)
            {
                if (i > 0)
                {
                    lastTInQueue = datas[i];
                    datas[i - 1] = lastTInQueue;
                    lastTInQueue = default;
                }
            }
            Debug.Log(FindArray);
            datas[FindArray] = target;
        }
    }
    public T Dequeue()
    {
        if (NowCount > 0)
        {
            T tempReturnT = datas[0];
            T lastTInQueue;
            for (int i = 0; i < NowCount; i++)
            {
                if (i>0)
                {
                    lastTInQueue = datas[i];
                    datas[i - 1] = lastTInQueue;
                    lastTInQueue = default;
                }
            }
            NowCount--;
            Array.Resize(ref datas, NowCount);
            Debug.Log(NowCount);
            return tempReturnT;
        }
        else
        {
            return default;
        }
    }
}
//C#은 클래스 전문화는 안되는거같음.. 4-21일 45페이지까지 공부함
public class TempleteStudyQueueString : TempleteStudyQueue<string>
{
    string[] datas;
    int maxSize;
    int nowCount = 0;
    private int NowCount
    {
        get
        {
            return nowCount;
        }
        set
        {
            if (maxSize < value)
            {
                nowCount = maxSize;
                return;

            }
            else if (0 > value)
            {
                nowCount = 0;
                return;
            }
            nowCount = value;
        }
    }
    private int FindArray
    {
        get
        {
            if (NowCount - 1 >= 0)
            {
                return NowCount - 1;
            }
            else
            {
                return 0;
            }
        }
    }
    public new string this[int index]
    {
        get { return datas[index]; }
        set { datas[index] = value; }
    }
    public TempleteStudyQueueString(int setMaxSize = 100)
    {
        maxSize = setMaxSize;
        datas = new string[0];
    }
    public new int Lenght
    {
        get
        {
            return NowCount;
        }
    }
    public new void Clear()
    {
        Array.Resize(ref datas, 0);
        NowCount = 0;
    }
    public new void enqueue(string target)
    {
        if (NowCount < maxSize)
        {
            //0부터 먼저 들어온 데이터를 넣어줌
            NowCount++;
            Array.Resize(ref datas, NowCount);
            Debug.Log(FindArray);
            datas[FindArray] = target;
        }
        else
        {
            string lastTInQueue;
            for (int i = 0; i < NowCount; i++)
            {
                if (i > 0)
                {
                    lastTInQueue = datas[i];
                    datas[i - 1] = lastTInQueue;
                    lastTInQueue = default;
                }
            }
            Debug.Log(FindArray);
            datas[FindArray] = target;
        }
    }
    public new string Dequeue()
    {
        if (NowCount > 0)
        {
            string tempReturnT = datas[0];
            string lastTInQueue;
            for (int i = 0; i < NowCount; i++)
            {
                if (i > 0)
                {
                    lastTInQueue = datas[i];
                    datas[i - 1] = lastTInQueue;
                    lastTInQueue = default;
                }
            }
            NowCount--;
            Array.Resize(ref datas, NowCount);
            Debug.Log(NowCount);
            return tempReturnT;
        }
        else
        {
            return default;
        }
    }
}




public class TempleteTest <T,Y> where T : class
{

}