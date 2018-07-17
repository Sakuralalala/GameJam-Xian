using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

    //总的点与非空的点
    public static List<Point> Points = new List<Point>();
    public static List<Point> LinePoints = new List<Point>();

    //此点上的边
    public List<Line> lines;

    [SerializeField]
    [Header("点的位置，z为0")]
    private Vector3 pos;
    public Vector3 Pos
    {
        get
        {
            return pos;
        }
        set
        {
            pos = value;
        }
    }

    [SerializeField]
    [Header("点上是否有边")]
    private bool haveLine;
    public bool HaveLine
    {
        get
        {
            return haveLine;
        }
        set
        {
            haveLine = value;
        }
    }

    void Init()
    {
        Points.Add(this);
        HaveLine = false;
        //transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Line" && !lines.Contains(collision.GetComponent<Line>()))
        {
            lines.Add(collision.GetComponent<Line>());
        }
        if (lines.Count != 0)
        {
            HaveLine = true;
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
            if(lines.Count == 0)
            {
                haveLine = false;
            }
        }
    }

    // Use this for initialization
    void Start () {
        Init();
	}
	
	// Update is called once per frame
	void Update () {
		if(haveLine && !LinePoints.Contains(this))
        {
            LinePoints.Add(this);
        }
	}
}
