using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BgMove : MonoBehaviour {

    private Vector3 target;
    [SerializeField]
    private float moveDis = 15;
    private Vector3 source;

    private void Awake()
    {
        source = transform.position;
    }

    public void MoveRight()
    {
        target = new Vector3(transform.position.x - moveDis,transform.position.y,transform.position.z);
        transform.DOMove(target, 2f);     
    }

    public void BackToStart()
    {
        transform.DOMove(source, 2f);
    }
}
