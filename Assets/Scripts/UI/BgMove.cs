using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BgMove : MonoBehaviour {

    private Vector3 target;
    [SerializeField]
    private float moveDis = 15;

    public void MoveRight()
    {
        target = new Vector3(transform.position.x - moveDis,transform.position.y,transform.position.z);
        transform.DOMove(target, 2f);
    }

    public void BackToStart()
    {
        target = new Vector3(transform.position.x + 2*moveDis, transform.position.y, transform.position.z);
        transform.DOMove(target, 2f);
    }
}
