using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour {

    public List<Point> points = new List<Point>();
    public List<Line> lines = new List<Line>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Point")
        {
            points.Add(collision.GetComponent<Point>());
        }
        if(collision.tag == "Line" && collision.GetComponent<Line>().points.Count == 2)
        {
            foreach(Point p in collision.GetComponent<Line>().points)
            {
                if(!points.Contains(p))
                {
                    return;
                }
            }
            if (!lines.Contains(collision.GetComponent<Line>()))
                lines.Add(collision.GetComponent<Line>());         
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Line" && collision.GetComponent<Line>().points.Count == 2)
        {
            foreach (Point p in collision.GetComponent<Line>().points)
            {
                if (!points.Contains(p))
                {
                    return;
                }
            }
            if (!lines.Contains(collision.GetComponent<Line>()))
                lines.Add(collision.GetComponent<Line>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Line")
        {
            if(lines.Contains(collision.GetComponent<Line>()))
            {
                lines.Remove(collision.GetComponent<Line>());
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
    //TODO
    void DestoryPlane()
    {
        if (points.Count <= lines.Count)
        {
            print("脱落");
            foreach (Line l in lines)
            {
                Line.Lines.Remove(l);              
            }
            lines = new List<Line>();
        }
    }

	// Update is called once per frame
	void Update () {
        DestoryPlane();
	}
}
