using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Plane : MonoBehaviour {

    public _Line[] lines;

    public Transform Check()
    {
        foreach(_Line line in lines)
        {
            if(line.GetState()!=Linestate.show)
                return null;
        }
        return gameObject.transform;
    }
}
