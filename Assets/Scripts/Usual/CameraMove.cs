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
        transform.position = myTarget;
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
}
