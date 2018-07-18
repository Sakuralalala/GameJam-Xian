using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZMapManager : MonoBehaviour {

    public static ZMapManager instance;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        //print(ZLine.lines.Count);
	}
    public Stack<ZPoint> circlePoint = new Stack<ZPoint>();

    public bool AddLine(ZLine line)
    {
        bool circle = false;
        circlePoint = new Stack<ZPoint>();
        line.isUse = true;
        circle = DFSAddLine(line.points[0], line.points[1]);
        foreach (ZLine l in ZLine.lines)
        {
            l.isUse = false;
        }
        return circle;
    }

    bool DFSAddLine(ZPoint p1, ZPoint p2)
    {
        ZPoint temp = p1;
        circlePoint.Push(temp);
        while(circlePoint.Count != 0)
        {
            temp =  circlePoint.Peek();
            int d = 0;
            while(d < temp.lines.Count)
            {
                if(temp.lines[d].GetComponent<ZLine>().enabled == true)
                {
                    if (temp.lines[d].GetComponent<ZLine>().isUse == false)
                    {
                        temp.lines[d].GetComponent<ZLine>().isUse = true;
                        foreach (ZPoint p in temp.lines[d].GetComponent<ZLine>().points)
                        {
                            if (p != temp)
                            {

                                temp = p;
                                circlePoint.Push(temp);
                                break;
                            }
                        }
                        if (temp == p2)
                        {
                            return true;
                        }
                        else
                        {
                            d = 0;
                        }
                    }
                    else
                    {
                        d++;
                    }
                }
                else
                {
                    d++;
                }
            }
            circlePoint.Pop();
        }
        return false;
    }

    public Stack<ZPoint> bigPoint = new Stack<ZPoint>();
    public List<ZLine> bigLine = new List<ZLine>();

    public List<ZLine> GetBigLine(ZLine line)
    {
        bigLine = new List<ZLine>();
        bigPoint = new Stack<ZPoint>();
        line.isUse = true;
        bigLine.Add(line);
        DFSGetBigLine(line.points[0], line.points[1]);
        foreach (ZLine l in ZLine.lines)
        {
            l.isUse = false;
        }
        return bigLine;
    }

    void DFSGetBigLine(ZPoint p1, ZPoint p2)
    {
        ZPoint temp = p1;
        bigPoint.Push(p1);
        while(true)
        {
            temp = bigPoint.Peek();
            int d = 0;
            Transform[] t = new Transform[4];
            GameObject[] go = new GameObject[2];
            foreach(GameObject g in temp.lines)
            {
                if(g.GetComponent<ZLine>().enabled == true)
                {
                    t[d] = g.transform.parent;
                    d++;                   
                }
            }
            if(d == 2 && t[0] == t[1])
            {
                d = 0;
                foreach (GameObject g in temp.lines)
                {
                    if (g.GetComponent<ZLine>().enabled == true)
                    {
                        go[d] = g;
                        d++;
                    }
                }
            }
            else
            {
                break;
            }
            foreach(GameObject l in go)
            {
                if(!bigLine.Contains(l.GetComponent<ZLine>()))
                {
                    bigLine.Add(l.GetComponent<ZLine>());
                    foreach(ZPoint p in l.GetComponent<ZLine>().points)
                    {
                        if (p != temp)
                        {
                            bigPoint.Push(p);
                        }
                    }
                }
            }
        }
        temp = p2;
        bigPoint.Push(p2);
        while (true)
        {
            temp = bigPoint.Peek();
            int d = 0;
            Transform[] t = new Transform[4];
            GameObject[] go = new GameObject[2];
            foreach (GameObject g in temp.lines)
            {
                if (g.GetComponent<ZLine>().enabled == true)
                {
                    t[d] = g.transform.parent;
                    d++;
                }
            }
            if (d == 2 && t[0] == t[1])
            {
                d = 0;
                foreach (GameObject g in temp.lines)
                {
                    if (g.GetComponent<ZLine>().enabled == true)
                    {
                        go[d] = g;
                        d++;
                    }
                }
            }
            else
            {
                break;
            }
            foreach (GameObject l in go)
            {
                if (!bigLine.Contains(l.GetComponent<ZLine>()))
                {
                    bigLine.Add(l.GetComponent<ZLine>());
                    foreach (ZPoint p in l.GetComponent<ZLine>().points)
                    {
                        if (p != temp)
                        {
                            bigPoint.Push(p);
                        }
                    }
                }
            }
        }
    }
}
