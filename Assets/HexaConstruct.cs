using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexaConstruct
{
    bool triangle;

    public HexaConstruct()
    {
        triangle = false;
    }

    public bool Triangle
    {
        get { return triangle; }
        set {  value = triangle; }  
    }
}
