using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

    /// <summary>
    /// 判断是否有环
    /// </summary>
    /// <returns></returns>
    public bool IsCircle()
    {
        if(Line.Lines.Count >= Point.LinePoints.Count && Line.Lines.Count > 2)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 找到环所对应的边
    /// </summary>
    /// <returns></returns>
    public List<Line> CircleLine()
    {
        if(IsCircle())
        {
            
        }
        return null;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
