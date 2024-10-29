using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager SingletonGameManager;
    public static int velocidadBala = 30;
    public static int disparosPorJuego = 10;
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
