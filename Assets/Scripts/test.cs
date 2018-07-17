using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test : MonoBehaviour {

    private GameObject[] walls;
    //判断是否掉落
    private bool isFall = false;

    private Vector3 change;
   

	// Use this for initialization
	void Start () {
        walls = GameObject.FindGameObjectsWithTag("Wall");
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            walls[0].GetComponent<Rigidbody2D>().gravityScale = 5.0f;
            isFall = true;
            Fall(walls[0]);
            
        }
        walls[0].transform.eulerAngles = change;
	}
    /// <summary>
    /// 掉落函数
    /// </summary>
    private void Fall(GameObject g)
    {
        Sequence s = DOTween.Sequence();
        s.Append(DOTween.To(() => change, x => change = x, new Vector3(-120, -180, -50), 1.5f));
        s.Insert(1.0f, DOTween.To(() => change, x => change = x, new Vector3(-240, 180, -50), 1.0f));

    }
}
