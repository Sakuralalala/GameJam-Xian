using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public void StartGame()
    {
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);

        GameObject.Find("Title1").gameObject.SetActive(false);
        GameObject.Find("Title2").gameObject.SetActive(false);
        GameObject.Find("Title3").gameObject.SetActive(false);
        GameObject.Find("Title4").gameObject.SetActive(false);
    }
    public void GameIntroduce()
    {
        Debug.Log("游戏介绍");
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(true);
    }
    public void ExitGame()
    {
        Debug.Log("退出游戏");
        Application.Quit();
    }
    public void ReturnStart()
    {
        GameObject.Find("Canvas").transform.GetChild(3).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(true);
    }
    public void NormalMode()
    {
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(true);
    }
    public void HardMode()
    {
        //GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
        //进入hard模式
        SceneManager.LoadScene(3);
    }
    public void GameOne()
    {
        //第一章
        StartCoroutine(LoadLevel(1));        
    }
    public void GameTwo()
    {
        //第二章
        StartCoroutine(LoadLevel(2));
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadLevel(int i)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(i);
    }
}
