using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Talking{

[System.Serializable] 
public class Diaglogue
{
    public string name; 
    [TextArea(3,10)]
    public string[] sentences; 

}
}

