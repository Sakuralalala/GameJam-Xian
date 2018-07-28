using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipController : MonoBehaviour {

    public static ClipController clips;

    AudioClip erase, crack;

	// Use this for initialization
	void Start () {
        clips = this;
        erase = transform.Find("Erase").GetComponent<AudioSource>().clip;
        crack = transform.Find("Crack").GetComponent<AudioSource>().clip;        

    }
	
	public void OnErase()
    {
        AudioSource.PlayClipAtPoint(erase,Camera.main.transform.position);
    }

    public void OnCrack()
    {
        AudioSource.PlayClipAtPoint(crack, Camera.main.transform.position);
    }
}
