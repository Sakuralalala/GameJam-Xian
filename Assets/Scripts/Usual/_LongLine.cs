using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _LongLine : MonoBehaviour {

    //存储与大边垂直的小边
    [SerializeField]
    _Line[] parallel;
    //存储组成大边的小边
    [SerializeField]
    _Line[] vertical;

    void Start()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false; 
    }

    //当垂直的边被禁用时且所有组成该大边的小边均为show状态，大边激活
    public void LongLineShow()
    {   
        foreach (_Line line in vertical)
        {
            if (line.GetState() == Linestate.show)
                return;
        }        
        foreach(_Line line in parallel)
        {
            if (line.GetState() != Linestate.show)
                return;           
        }

        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        gameObject.GetComponent<_Line>().ChangeState(Linestate.show);

        foreach (_Line line in parallel)
        {
            line.ChangeState(Linestate.hide);
        }
    }

    public void LongLineHide()
    {
        bool flag = false;
        foreach(_Line line in vertical)
        {
            if (line.GetState() == Linestate.show)
                flag = true;                        
        }

        if (flag == false)
            return;

        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        foreach (_Line l in parallel)
        {
            l.ChangeState(Linestate.show);
        }
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<_Line>().ChangeState(Linestate.hide);
    }

    private void Update()
    {
        if (gameObject.GetComponent<_Line>().GetState() == Linestate.show && gameObject.GetComponent<BoxCollider2D>().enabled == false)
            gameObject.GetComponent<_Line>().ChangeState(Linestate.hide);
    }
}
