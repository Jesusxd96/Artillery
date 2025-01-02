using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    /*Canvas a utilizarse en el menu principal*/
    public GameObject MainMenuCanvas;
    public GameObject OptionsCanvas;
    //GameObject ConfirmationCanvas; //Canvas para confirmar si ya gg el juego o nel pastel.

    public void Start()
    {
        MainMenuCanvas.SetActive(true);
        OptionsCanvas.SetActive(false);
        //ConfirmationCanvas.SetActive(false);
    }
    public void StartGame()
    {   //Temporal por si se implementa una seleccion de niveles a futuro.
        var NextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > NextLevel)
            SceneManager.LoadScene(NextLevel);
        else
            SceneManager.LoadScene(0);//El Main menu siempre sera la Scene 0
    }
    public void OptionsMenu()
    {
        //Muestra el menu de opciones
        OptionsCanvas.SetActive(true);
        MainMenuCanvas.SetActive(false);
    }
    public void ReturnToMenu()
    {
        //Muestra el menu de opciones
        OptionsCanvas.SetActive(false);
        MainMenuCanvas.SetActive(true);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
