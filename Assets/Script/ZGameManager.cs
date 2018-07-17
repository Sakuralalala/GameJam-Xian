using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZGameManager : MonoBehaviour {

    public static int step = 0;

    public Image defeat;
    public Text defeatYear;
    public Text year;
    public Text currentStep;


    public int addLine;
    public int removeLine;
    public int currentRemoveLine;

    List<GameObject> allLines = new List<GameObject>();

    List<GameObject> addLines = new List<GameObject>();

	// Use this for initialization
	void Start () {
        addLine = 2;
        currentRemoveLine = 5;
        removeLine = 1;
        GameObject[] bls = GameObject.FindGameObjectsWithTag("BigLine");
        foreach(GameObject bl in bls)
        {
            for(int i = 0;i<bl.transform.childCount;i++)
            {
                allLines.Add(bl.transform.GetChild(i).gameObject);
            }
        }

        while(addLines.Count < addLine)
        {
            int r = Random.Range(0, allLines.Count);
            if (!addLines.Contains(allLines[r]))
            {
                addLines.Add(allLines[r]);
            }
        }
        foreach(GameObject adl in addLines)
        {
            adl.GetComponent<SpriteRenderer>().enabled = true;
            adl.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            adl.GetComponent<Collider2D>().enabled = true;
            adl.GetComponent<ZLine>().enabled = true;
        }
        addLines = new List<GameObject>();
        while (addLines.Count < addLine)
        {
            int r = Random.Range(0, allLines.Count);
            if (!addLines.Contains(allLines[r]) && allLines[r].GetComponent<ZLine>().enabled == false)
            {
                addLines.Add(allLines[r]);
                allLines[r].GetComponent<SpriteRenderer>().enabled = true;
                allLines[r].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            }
        }
    }
	
    void OnClick(ZLine line)
    {
        List<ZLine> l = ZMapManager.instance.GetBigLine(line);
        bool isDelete = false;
        foreach(ZLine zl in ZLine.lines)
        {
            if (l.Contains(zl))
                continue;
            zl.isChoose = false;
            zl.isUse = false;
        }
        foreach(ZLine zl in l)
        {
            if(zl.isChoose && currentRemoveLine > 0)
            {
                zl.Destroy();
                isDelete = true;
            }
            else
            {
                zl.isChoose = true;
            }
        }
        if(isDelete)
        {
            isDelete = false;
            currentRemoveLine--;
            ClipController.clips.OnErase();
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentStep.text = currentRemoveLine.ToString();
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                GameObject gameObj = hit.collider.gameObject;
                if (gameObj.tag == "Line")
                {
                    OnClick(gameObj.GetComponent<ZLine>());
                }
            }
        }    
    }

    //TODO破碎
    void Defeat()
    {
        foreach(GameObject g in allLines)
        {
            if(g.GetComponent<ZLine>().enabled == true)
            {
                g.GetComponent<ZLine>().Destroy();
            }
            g.GetComponent<SpriteRenderer>().enabled = false;
        }
        defeat.gameObject.SetActive(true);
        defeatYear.text = step.ToString();

    }

    public void Quit()
    {

    }

    public void Again()
    {

    }

    //button下一步
    public void NextStep()
    {
        ClipController.clips.OnCrack();
        foreach(ZLine l in ZLine.lines)
        {
            l.isUse = false;
            l.isChoose = false;
        }
        step++;
        year.text = step.ToString();
        currentRemoveLine += removeLine;
        foreach(GameObject adl in addLines)
        {
            adl.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);
            adl.GetComponent<Collider2D>().enabled = true;
            adl.GetComponent<ZLine>().enabled = true;
            if (IsCircle())
            {
                Defeat();
            }
            else if (ZMapManager.instance.AddLine(adl.GetComponent<ZLine>()))
            {
                Defeat();
            }
            
        }
        addLines = new List<GameObject>();
        while (addLines.Count < addLine)
        {
            int r = Random.Range(0, allLines.Count);
            if (!addLines.Contains(allLines[r]) && allLines[r].GetComponent<ZLine>().enabled == false)
            {
                addLines.Add(allLines[r]);
                allLines[r].GetComponent<SpriteRenderer>().enabled = true;
                allLines[r].GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            }
        }
    }

    bool IsCircle()
    {
        bool circle = false;
        List<ZLine> zl = new List<ZLine>();
        foreach(GameObject g in allLines)
        {
            if(g.GetComponent<ZLine>().enabled == true)
            {
                zl.Add(g.GetComponent<ZLine>());
            }
        }
        List<ZPoint> zp = new List<ZPoint>();
        foreach(ZPoint p in ZPoint.points)
        {
            foreach(GameObject g in p.lines)
            {
                if(g.GetComponent<ZLine>().enabled == true)
                {
                    zp.Add(p);
                    break;
                }
            }
        }
        if (zp.Count <= zl.Count)
            circle = true;
        return circle;
    }

}
