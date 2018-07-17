using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public static List<Line> Lines = new List<Line>();

    //此边上的点
    public List<Point> points;
    bool isChoose;
    bool isDestory;

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
		
	}
}
