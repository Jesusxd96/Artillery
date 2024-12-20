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
        //set => _velocidadBala = 30;
    }
    private static int _disparosPorJuego = 10;
    public static int disparosRestantes
    {//Intento de setter y getter
        get => _disparosPorJuego;
        set => _disparosPorJuego = value;
    }
    public static float velocidadRotacion = 1;

    private void Awake()
    {
        if (SingletonGameManager == null)
            SingletonGameManager = this;
        else
            Debug.LogError("Ya existe una instancia de esta clase");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
