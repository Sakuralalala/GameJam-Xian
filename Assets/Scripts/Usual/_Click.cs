using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Click : MonoBehaviour {

    private bool IsAct = false;
    [SerializeField]
    Text value;

	// Use this for initialization
	void Start () {
        value.text = _Line.pigment.ToString();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&IsAct == false)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);      
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<_Line>() != null)
                    hit.collider.gameObject.GetComponent<_Line>().IsClicked();
                value.text = _Line.pigment.ToString();
            }
        }
    }
}
