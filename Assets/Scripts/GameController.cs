using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using System.Linq;

public class GameController : MonoBehaviour
{
    private DataRepository _dataRepository;
    public GameData datosJuego;
    private TMP_Text puntaje;
    private TMP_Text healtText;
    int puntajeanterior = 0;
    [SerializeField] int healtanterior = 0;
    public event EventHandler DeadPlayer;

    public GameObject heartPrefab;
    public Transform heartContainer;

    private bool isPaused = false;


    void Start()
    {
        _dataRepository = new DataRepository();

        datosJuego=_dataRepository.LoadGame();
        puntaje = GameObject.Find("PuntajeText").GetComponent<TextMeshProUGUI>();
        healtText = GameObject.Find("HealtText").GetComponent<TextMeshProUGUI>();

        heartPrefab = GameObject.Find("HeartImage");
        heartContainer = GameObject.Find("HeartPanel").transform;
    }
    public void AddScore(int scoreToAdd)
    {
        puntajeanterior= datosJuego.score;
        datosJuego.score += scoreToAdd;
        
        // if (datosJuego.score%50==0)
        // {
            _dataRepository.SaveGame(datosJuego);

        // }
    }
    public void ModifyHealt(int healt)
    {
        healtanterior = datosJuego.healt;
        datosJuego.healt = datosJuego.healt + healt;
        if(datosJuego.healt <= 0){
            DeadPlayer?.Invoke(this, EventArgs.Empty);
        }

        _dataRepository.SaveGame(datosJuego);
    }
    public void resetData(){
        datosJuego.healt = 5;
        datosJuego.score = 0;
        _dataRepository.SaveGame(datosJuego);
    }
    // Update is called once per frame
    void Update()
    {
        puntaje.text = "Puntaje: " + datosJuego.score;
        // healtText.text = "Vida: " + string.Concat(Enumerable.Repeat("❤️", datosJuego.healt));
        foreach (Transform child in heartContainer)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < datosJuego.healt; i++)
        {
            Instantiate(heartPrefab, heartContainer);
        }
    }
    public void TogglePause(bool pause)
    {
        isPaused = !pause;
        

        if (isPaused)
        {
            Time.timeScale = 0; // Pausa el tiempo
        }
        else
        {
            Time.timeScale = 1; // Reanuda el tiempo
        }
    }
}
