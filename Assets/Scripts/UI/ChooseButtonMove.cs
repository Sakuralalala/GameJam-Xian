using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ChooseButtonMove : MonoBehaviour
{
    [SerializeField]
    [Header("位置1")]
    private Vector3 Value1;
    [SerializeField]
    [Header("位置2")]
    private Vector3 Value2;
    //...
    //改变的值
    private Vector3 myValue;
    private RectTransform rectTransform;

    // Use this for initialization
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        myValue = Value1;
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localPosition = myValue;
    }
    /// <summary>
    /// 移动
    /// </summary>
    private void Move()
    {
        //rectTransform.localPosition = Value1;
        Sequence s = DOTween.Sequence();
        s.Append(DOTween.To(() => myValue, x => myValue = x, Value2, 2.0f));
    }
}
