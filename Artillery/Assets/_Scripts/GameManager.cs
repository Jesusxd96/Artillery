using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager SingletonGameManager;
    private static int _velocidadBala = 30;
    public static int velocidadBala
    {//Intento de getter
        get => _velocidadBala;
        set => _velocidadBala = value;//Para poder settearle un valor
    }
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
        disparosRestantes = 10;
        velocidadBala = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(disparosRestantes <= 0)
        {
            PerderJuego();
        }
    }
    public void GanarJuego()
    {
        CanvasGanar.SetActive(true);
    }
    public void PerderJuego()
    {
        CanvasPerder.SetActive(true);
    }
}
