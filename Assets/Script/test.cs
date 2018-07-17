using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    List<int> l = new List<int>();
	// Use this for initialization
	void Start () {
        l.Add(1);
        l.Add(2);
        l.Add(3);
        l.Remove(2);
        print(l[0]);
        print(l[1]);
        BoxCollider2D b = GetComponent<BoxCollider2D>();
        print(b.enabled);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
