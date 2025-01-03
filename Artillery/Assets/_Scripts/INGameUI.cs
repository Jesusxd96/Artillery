using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class INGameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text numeroDeBalas;
    [SerializeField] private TMP_Text enemigosRestantes;

    // Update is called once per frame
    void Update()
    {
        enemigosRestantes.text = "Objetivos restantes: " + GameManager.enemigosRestantes.ToString();
        numeroDeBalas.text = "Balas restantes: " + GameManager.disparosRestantes.ToString();
        if (GameManager.disparosRestantes <= 0)
        {
            numeroDeBalas.text = "Sin balas";
        }
    }
}
