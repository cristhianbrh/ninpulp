using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    private GameController  gameController;
    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gameController.DeadPlayer += ActiveMenu;
    }

    private void ActiveMenu(object sender, EventArgs e){
        menuGameOver.SetActive(true);
    }
    public void Reload()
    {
        gameController.resetData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        gameController.resetData();
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
