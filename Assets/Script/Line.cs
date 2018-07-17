using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public static List<Line> Lines = new List<Line>();

    //此边上的点
    public List<Point> points;
    //此边所在的面
    //public List<Plane> planes;
    bool isChoose;
    bool isDestroy;

    void DestroyLine()
    {
        foreach(Point p in points)
        {
            if(p.lines.Count == 2)
            {
                Line l0 = p.lines[0];
                BigLine bl0 = transform.parent.GetComponent<BigLine>();
                if(bl0.lines.Contains(p.lines[1]))
                {                   
                    foreach(Plane pl in p.planes)
                    {
                        pl.points.Remove(p);
                    }
                    Destroy(p.gameObject);
                }
            }
        }
    }

    void AddLine(Line line)
    {
        foreach(Point p in line.points)
        {
            if(p.lines.Count == 3)
            {
                BigLine bl0 = p.lines[0].transform.parent.GetComponent<BigLine>();
                if(bl0.lines.Contains(p.lines[1]))
                {

                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Point")
        {
            points.Add(collision.GetComponent<Point>());
            collision.GetComponent<Point>().HaveLine = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Point")
        {
            points.Remove(collision.GetComponent<Point>());
        }
    }
    // Use this for initialization
    void Start () {
        Lines.Add(this);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.W))
        {
            DestroyLine();
        }
	}
}
