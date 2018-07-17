using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZPoint : MonoBehaviour {

    public static List<ZPoint> points = new List<ZPoint>();

    void Start () {
        isEmpty = true;
        isConnect = false;
        points.Add(this);
	}

    public bool isConnect;
    public bool isEmpty;
    public List<GameObject> lines = new List<GameObject>();

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Line" && !lines.Contains(collision.GetComponent<ZLine>()))
    //    {
    //        lines.Add(collision.GetComponent<ZLine>());
    //    }
    //    if (lines.Count != 0)
    //    {
    //        isEmpty = false;
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.tag == "Line")
    //    {
    //        if (lines.Contains(collision.GetComponent<ZLine>()))
    //        {
    //            lines.Remove(collision.GetComponent<ZLine>());
    //        }
    //        if (lines.Count == 0)
    //        {
    //            isEmpty = true;
    //        }
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Line" && !lines.Contains(collision.GetComponent<ZLine>()))
    //    {
    //        lines.Add(collision.GetComponent<ZLine>());
    //    }
    //    if (lines.Count != 0)
    //    {
    //        isEmpty = false;
    //    }
    //}

}
