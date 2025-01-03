using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Objetivo : MonoBehaviour
{
    public UnityEvent GameWon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Explosion")
        {
            GameManager.enemigosRestantes -= 1;//Se le resta un enemigo
            /*if(GameManager.enemigosRestantes <= 0)
                GameWon.Invoke();*/
            Destroy(this.gameObject);
        }
    }
}