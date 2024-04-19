using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericTest : MonoBehaviour
{
    public (T,A) log<T,A>(T a,A b)
    {
        (T, A) tempTarget = (a, b);
        return tempTarget;
    }
}

public class TempleteTest <T,Y> where T : class
{

}
