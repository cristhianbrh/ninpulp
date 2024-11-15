using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject menuStartGame;
    private GameController  gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        gameController.DeadPlayer += ActiveMenu;
    }

    private void ActiveMenu(object sender, EventArgs e){
        menuGameOver.SetActive(true);
        gameController.TogglePause(false);
    }
    public void ActiveMenuStart(){
        menuStartGame.SetActive(true);
        gameController.TogglePause(false);
    }
    public void ContinueGame()
    {
        if(gameController.datosJuego.healt <= 0){
            gameController.resetData();
        }
        menuStartGame.SetActive(false);
        gameController.TogglePause(true);
    }
    public void StartGame()
    {
        gameController.resetData();
        menuStartGame.SetActive(false);
    }
    public void Reload()
    {
        gameController.resetData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameController.TogglePause(true);
        menuStartGame.SetActive(false);
        menuGameOver.SetActive(false);
    }

    public void Exit()
    {
        // gameController.resetData();
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

}
