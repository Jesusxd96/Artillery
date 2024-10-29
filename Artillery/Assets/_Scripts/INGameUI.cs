using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class INGameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text numeroDeBalas;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numeroDeBalas.text = "Balas restantes: " + GameManager.disparosRestantes.ToString();
        if (GameManager.disparosRestantes <= 0)
        {
            numeroDeBalas.text = "Sin balas";
        }
    }
}
