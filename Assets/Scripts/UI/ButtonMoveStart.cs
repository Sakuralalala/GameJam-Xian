using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/// <summary>
/// 开始界面UI的动画
/// </summary>
public class ButtonMoveStart : MonoBehaviour {
    [SerializeField][Header("位置1")]
    private Vector3 Value1;
    [SerializeField][Header("位置2")]
    private Vector3 Value2;
    //...
    //改变的值
    private Vector3 myValue;
    private RectTransform rectTransform;

    // Use this for initialization
    void Start () {
        rectTransform = GetComponent<RectTransform>();
        Move();
	}
	
	// Update is called once per frame
	void Update () {
        transform.localPosition = myValue;
	}

    /// <summary>
    /// 按钮移动
    /// </summary>
    private void Move()
    {
        Sequence s = DOTween.Sequence();
        s.Append(DOTween.To(() => myValue, x => myValue = x, Value1, 1.5f));
        s.Insert(1.0f,DOTween.To(() => myValue, x => myValue = x, Value2, 1.5f));

    }
}
