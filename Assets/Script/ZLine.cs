using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZLine : MonoBehaviour {

    public bool isChoose;
    public bool isDestroy;
    //寻路用
    public bool isUse;

    public static List<ZLine> lines = new List<ZLine>();
    public List<ZPoint> points;

    // Use this for initialization
    void Start () {
        lines.Add(this);
        isChoose = false;
        isDestroy = false;
        isUse = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(isChoose)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
        }
	}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Point" && !points.Contains(collision.GetComponent<ZPoint>()))
    //    {
    //        points.Add(collision.GetComponent<ZPoint>());
    //        collision.GetComponent<ZPoint>().isEmpty = false;
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Point" && !points.Contains(collision.GetComponent<ZPoint>()))
    //    {
    //        points.Add(collision.GetComponent<ZPoint>());
    //        collision.GetComponent<ZPoint>().isEmpty = false;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Point")
    //    {
    //        points.Remove(collision.GetComponent<ZPoint>());
    //    }
    //}

    public void Destroy()
    {
        isChoose = false;
        isDestroy = false;
        isUse = false;
        lines.Remove(this);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        enabled = false;
    }

}
