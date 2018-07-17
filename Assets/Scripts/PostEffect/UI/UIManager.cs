﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public void StartGame()
    {
        Debug.Log("开始游戏");

        GameObject.Find("Canvas").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
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
        GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(false);
        //进入hard模式
    }
    public void GameOne()
    {
        //第一章
    }
    public void GameTwo()
    {
        //第二章
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}