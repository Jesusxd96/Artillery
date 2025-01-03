using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderVelocidad : MonoBehaviour
{
    public PuntajeConfiguracionJugador opciones;
    Slider slider;
    public TMP_Text velocidadText;
    // Start is called before the first frame update
    public void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ControlarCambios(); });
    }
    public void ControlarCambios()
    {
        opciones.CambiarVelocidad(slider.value);
    }
    public void Update()
    {//Nadamas esta para que siempre tenga el valor que corresponde.
        slider.value = opciones.velocidadBala;
        velocidadText.text = slider.value.ToString();
    }
}
