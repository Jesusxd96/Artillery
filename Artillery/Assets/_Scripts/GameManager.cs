using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager SingletonGameManager;
    //public PuntajeConfiguracionJugador velocidadBalas;
    public PuntajeConfiguracionJugador _velocidadBala;
    /*public static PuntajeConfiguracionJugador velocidadBala
    {//Intento de getter
        get => _velocidadBala;
        set => _velocidadBala = value;//Para poder settearle un valor
    }*/
    
    public static int enemigosRestantes;//Variable a utilizarse para determinar cuantos enemigos quedan en el juego
    public static bool isGameWon;

    private static int _disparosPorJuego = 10;
    public static int disparosRestantes
    {//Intento de setter y getter
        get => _disparosPorJuego;
        set => _disparosPorJuego = value;
    }
    public static float velocidadRotacion = 1;

    public GameObject CanvasGanar;
    public GameObject CanvasPerder;

    private void Awake()
    {
        if (SingletonGameManager == null)
            SingletonGameManager = this;
        else
            Debug.LogError("Ya existe una instancia de esta clase");
    }

    public void Start()
    {
        isGameWon=false;
        disparosRestantes = 10;
        enemigosRestantes = GameObject.FindGameObjectsWithTag("Objetivo").Length;
        //Debug.Log("Son " + enemigosRestantes + " Enemigos restantes");
        //velocidadBala = 30;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Son " + enemigosRestantes + " Enemigos restantes");
        if(disparosRestantes <= 0 && !isGameWon)
        {//Si no quedan disparos y el juego no se ha ganado
            PerderJuego();
        }
    }
    private void LateUpdate()
    {
        if (disparosRestantes > 0 && enemigosRestantes <= 0)
        {
            GanarJuego();
        }
    }
    public void GanarJuego()
    {
        isGameWon = true;
        CanvasGanar.SetActive(true);
    }
    public void PerderJuego()
    {
        CanvasPerder.SetActive(true);
    }
}
