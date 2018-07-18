using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleMove : MonoBehaviour {
    [SerializeField]
    [Header("位置1")]
    private Vector3 Value1;
    [SerializeField]
    [Header("位置2")]
    private Vector3 Value2;
    [SerializeField][Header("运行时间")]
    private float time=1.0f;
    //改变的值
    private Vector3 myValue;


    // Use this for initialization
    void Start () {
        myValue = Value1;
        Move();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = myValue;
	}
    /// <summary>
    /// 移动
    /// </summary>
    private void Move()
    {
        //rectTransform.localPosition = Value1;
        Sequence s = DOTween.Sequence();
        s.Append(DOTween.To(() => myValue, x => myValue = x, Value2, time));
    }
}
