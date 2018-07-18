using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLine : MonoBehaviour {

    public List<Line> lines = new List<Line>();
    public List<Point> points = new List<Point>();

	// Use this for initialization
	void Start () {
        Line[] ls = transform.GetComponentsInChildren<Line>();
        foreach(Line l in ls)
        {
            lines.Add(l);
            foreach(Point p in points)
            {
                if(!points.Contains(p))
                {
                    points.Add(p);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
