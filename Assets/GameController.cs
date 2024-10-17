using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private DataRepository _dataRepository;
    private GameData datosJuego;
    private TMP_Text puntaje;
    private TMP_Text healtText;
    int puntajeanterior = 0;
    int healtanterior = 0;
    void Start()
    {
        _dataRepository = new DataRepository();

        datosJuego=_dataRepository.LoadGame();
        puntaje = GameObject.Find("PuntajeText").GetComponent<TextMeshProUGUI>();
        healtText = GameObject.Find("HealtText").GetComponent<TextMeshProUGUI>();
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

        _dataRepository.SaveGame(datosJuego);
    }
    // Update is called once per frame
    void Update()
    {
        puntaje.text = "Puntaje: " + datosJuego.score;
        healtText.text = "Vida: " + datosJuego.healt;
    }
}