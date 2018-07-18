using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour {

    private bool isMove = false;
    private Vector3 target;
    private Vector3 myTarget;
    [SerializeField]
    [Header("移动间隔")]
    private float moveDis = 10;

    private float i=0;
    // Use this for initialization
    void Start()
    {
        myTarget = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButton(0))
        //{

        //    Move();

        //}
        //transform.position = myTarget;
    }
    private void LateUpdate()
    {
        transform.position = myTarget;
    //    GameObject.Find("BackGroundOld").GetComponent<SetImageAlpha>().leftX = i;
    }
    /// <summary>
    /// 相机右移函数
    /// </summary>
    public void MoveRight()
    {
        target = transform.position + new Vector3(moveDis, 0, 0);
        Sequence s = DOTween.Sequence();
        s.Append(DOTween.To(() => myTarget, x => myTarget = x, target, 2.0f)).SetEase(Ease.OutQuad);
    }
    /// <summary>
    /// 相机左移函数
    /// </summary>
    public void MoveLeft()
    {
        target = transform.position + new Vector3(-moveDis, 0, 0);
        Sequence s = DOTween.Sequence();
        s.Append(DOTween.To(() => myTarget, x => myTarget = x, target, 2.0f)).SetEase(Ease.OutQuad);
    }
    /// <summary>
    /// 胜利的时候相机移动
    /// </summary>
    public void MoveWin()
    {
        Vector3 nowPos = transform.position;
        Vector3 startPos = new Vector3(0, 0, -10);
        Sequence s = DOTween.Sequence();
        Sequence s2 = DOTween.Sequence();
        //快速回到初始点
        s.Append(DOTween.To(() => myTarget, x => myTarget = x, startPos, 0.5f)).SetEase(Ease.OutQuad);
        //缓慢移动到终点
        s.Insert(0.5f, DOTween.To(() => myTarget, x => myTarget = x, nowPos, 15.0f)).SetEase(Ease.Linear);
        
        //s2.Insert(0.5f,DOTween.To(() => i, x => i =x, 1, 15.0f)).SetEase(Ease.Linear);
        s2.Insert(0.5f, DOTween.To(() => i, x => i = x, 1, 13.0f));
        //s.Insert(0.5f, DOTween.To(() => myTarget, x => myTarget = x, nowPos, 10.0f));
    }

    IEnumerator moveWait()
    {
        yield return new WaitForSeconds(0.8f);
    }
}
