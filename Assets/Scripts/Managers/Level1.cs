using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour {

    private List<Transform[]> steps=new List<Transform[]>();
    [SerializeField]
    private Transform[] lines;
    [SerializeField]
    private Transform[] longline;
    [SerializeField]
    Transform[] step1;
    [SerializeField]
    Transform[] step2;
    [SerializeField]
    Transform[] step3;
    [SerializeField]
    Transform[] step4;
    [SerializeField]
    Transform[] step5;

    public bool isWin = false;

    //记录当前第几步
    private int count = -1;
    //存储所有面
    [SerializeField]
    Transform father;
    private _Plane[] planes;
    public int pigment;

    // Use this for initialization
    void Start () {

        if (step1.Length != 0)
            steps.Add(step1);  
        if (step2.Length != 0)
            steps.Add(step2);
        if (step3.Length != 0)
            steps.Add(step3);
        if (step4.Length != 0)
            steps.Add(step4);
        if (step5.Length != 0)
            steps.Add(step5);
        
        foreach(Transform trans in lines)
            trans.gameObject.GetComponent<_Line>().ChangeState(Linestate.hide);

        planes = father.gameObject.GetComponentsInChildren<_Plane>();

        NextStep();
    }

    public void NextStep()
    {
        foreach (Transform line in lines)
        {
            if (line.gameObject.GetComponent<_Line>().GetState() == Linestate.focus)
            {
                line.gameObject.GetComponent<_Line>().ChangeState(Linestate.show);
            }
        }

        count++;

        //将新增线条状态改为show
        foreach (Transform line in steps[count])
        {
            if (line.gameObject.GetComponent<_LongLine>()!=null) continue;
            line.gameObject.GetComponent<_Line>().ChangeState(Linestate.show);
        }

        
        //判断是否有环
        foreach (_Plane p in planes)
            failed(p.Check());

        //如果是最后一步，没有ready状态的线条
        if (count == steps.Count - 1)
        {
            Debug.Log("you win!");
            //过关
            isWin = true;
            return;
        }

        //将下一步线条状态改为ready
        foreach (Transform line in steps[count + 1])
            line.gameObject.GetComponent<_Line>().ChangeState(Linestate.ready);

        foreach(Transform l in longline)
        {
            bool flag = l.gameObject.GetComponent<BoxCollider2D>().enabled;
            if (flag)
                l.gameObject.GetComponent<_LongLine>().LongLineHide();
            else
                l.gameObject.GetComponent<_LongLine>().LongLineShow();
        }        
    }

    private void failed(Transform trans)
    {
        if (trans == null) return;
        Debug.Log(trans.gameObject.name + "is a circle");
    }
}
