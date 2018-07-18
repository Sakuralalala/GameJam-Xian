using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Plane : MonoBehaviour {

    public _Line[] lines;
    public List<_Plane> children;

    private void Start()
    {
        _Plane[] allPlanes=transform.parent.GetComponentsInChildren<_Plane>();
        foreach(_Plane plane in allPlanes)
        {
            if (gameObject.name == plane.gameObject.name)
                children.Add(plane);
        }
    }

    public Transform Check()
    {
        foreach(_Line line in lines)
        {
            if(line.GetState()!=Linestate.show)
                return null;
        }
        Debug.Log(this.gameObject.name);
        return gameObject.transform;
    }
}
