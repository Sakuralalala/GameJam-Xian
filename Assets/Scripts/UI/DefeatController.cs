using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatController : MonoBehaviour {


    public void BackToStart()
    {
        SceneManager.LoadScene(0);
    }
    public void ToLevel1()
    {
        SceneManager.LoadScene(1);
    }
    public void ToLevel2()
    {
        SceneManager.LoadScene(2);
    }
}
