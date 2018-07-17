using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Linestate{
    hide,
    ready,
    show,
    focus
}

public class _Line : MonoBehaviour {

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Linestate state=Linestate.hide;

	// Use this for initialization
	void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeState(Linestate.hide);
	}

    //点击事件触发focus或者hide
    public void IsClicked()
    {
        if (state == Linestate.hide || state == Linestate.ready)
            return;
        if (state == Linestate.show)
        {
            _Line[] lines = transform.parent.gameObject.GetComponentsInChildren<_Line>();
            foreach(_Line l in lines)
            {
                if (l.GetState() == Linestate.focus)
                    l.ChangeState(Linestate.show);
            }
            ChangeState(Linestate.focus);
            return;
        }
        if (state == Linestate.focus)
        {
            if(transform.parent.transform.parent.GetComponent<Level1>().pigment>=1)
            {
                transform.parent.transform.parent.GetComponent<Level1>().pigment--;
                ChangeState(Linestate.hide);
                gameObject.SetActive(false);
                _LongLine[] longlines = transform.parent.gameObject.GetComponentsInChildren<_LongLine>();
                foreach(_LongLine l in longlines)
                {
                    bool flag = l.gameObject.GetComponent<BoxCollider2D>().enabled;
                    if (flag)
                        l.LongLineHide();
                    else
                        l.LongLineShow();
                }
                return;
            }
            else
            {
                Debug.Log("步数不够辣！");
                ChangeState(Linestate.show);
            }
        }
    }

    //改变状态同时改变显示效果
    public void ChangeState(Linestate newstate)
    {
        state = newstate;
        BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
        if (state == Linestate.hide)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0);
            collider.enabled = false;
        }
        if (state == Linestate.ready)
        {
            spriteRenderer.color = Color.gray;
            collider.enabled = false;
        }
        if (state == Linestate.show)
        {
            spriteRenderer.color = Color.black;
            collider.enabled = true;
        }
        if (state == Linestate.focus)
        {
            spriteRenderer.color = Color.red;
          
        }
          


    }

    public Linestate GetState()
    {
        return state;
    }
}
