using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    GameObject[] levels;
    GameObject level;

    private void Start()
    {
        int count = GameObject.Find("Levels").transform.childCount;
        level = GameObject.Find("Levels");
        Init();
    }

    private void Win()
    {
        if (level.transform.GetChild(0).GetComponent<Level1>().isWin == true)
        {
            //相机移动，移动到下一个关卡，下一个关卡的UI显示
            //上一个关卡的UI关闭
            //控制ui的改变
            GameObject.Find("Main Camera").GetComponent<CameraMove>().MoveRight();
            //第一关的UI关闭
            StartCoroutine(hideCanvas(0));
            //第二关的UI开启
 //           level.transform.GetChild(1).gameObject.SetActive(true);
            level.transform.GetChild(0).GetComponent<Level1>().isWin = false;
        }
        if (level.transform.GetChild(1).GetComponent<Level1>().isWin == true)
        {
            GameObject.Find("Main Camera").GetComponent<CameraMove>().MoveRight();
            //第二关的UI关闭
            StartCoroutine(hideCanvas(1));
            //第三关的UI开启
 //           level.transform.GetChild(2).gameObject.SetActive(true);
            level.transform.GetChild(1).GetComponent<Level1>().isWin = false;
        }
        if (level.transform.GetChild(2).GetComponent<Level1>().isWin == true)
        {
            GameObject.Find("Main Camera").GetComponent<CameraMove>().MoveRight();
            //第三关的UI关闭
            StartCoroutine(hideCanvas(2));
            //第四关的UI开启
 //           level.transform.GetChild(3).gameObject.SetActive(true);
            level.transform.GetChild(2).GetComponent<Level1>().isWin = false;
        }
        if(level.transform.GetChild(3).GetComponent<Level1>().isWin == true)
        {
            StartCoroutine(hideCanvas(3));
            GameObject.Find("Main Camera").GetComponent<CameraMove>().MoveWin();
            level.transform.GetChild(3).GetComponent<Level1>().isWin = false;
            StartCoroutine(nextLevel());
        }
    }

    private void Update()
    {
        Win();
        //Debug.Log(level.transform.GetChild(0).GetComponent<Level1>().pigment);
    }
    /// <summary>
    /// 初始化
    /// </summary>
    private void Init()
    {
        level.transform.GetChild(0).GetComponent<Level1>().pigment = 2;
        level.transform.GetChild(1).GetComponent<Level1>().pigment = 3;
        level.transform.GetChild(2).GetComponent<Level1>().pigment = 3;
        level.transform.GetChild(3).GetComponent<Level1>().pigment = 2;
        //level.transform.GetChild(4).GetComponent<Level1>().pigment = 4;
    }

    IEnumerator hideCanvas(int i)
    {
        yield return new WaitForSeconds(2f);
        level.transform.GetChild(i).gameObject.SetActive(false);
        if (i < 3)
            level.transform.GetChild(i + 1).gameObject.SetActive(true);
    }

    IEnumerator nextLevel()
    {
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene(2);
    }
}
