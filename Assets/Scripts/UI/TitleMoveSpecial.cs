using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TitleMoveSpecial : MonoBehaviour {

    Color myColor;
    // Use this for initialization
    void Start () {

        //myColor = GetComponent<SpriteRenderer>().color;
        myColor = new Color(1, 1, 1, 0);
        Move();
    }
	
	// Update is called once per frame
	void Update () {

        GetComponent<SpriteRenderer>().color = myColor;
        
    }

    private void Move()
    {
        
        Sequence s = DOTween.Sequence();
        s.Append(DOTween.To(() => myColor, x => myColor = x, new Color(1,1,1,1), 2.5f));
        //s.Insert(2.5f, DOTween.To(() => myValue, x => myValue = x, Value3, 2.5f));
        ////s.Insert(2.0f, DOTween.To(() => myValue, x => myValue = x, Value4, 1.0f));
        //s.SetLoops(1);
    }
}
