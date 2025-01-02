using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Configuracion", menuName = "Herramientas/Configuracion", order = 1)]
public class PuntajeConfiguracionJugador : PlayerSettings
{
    public float velocidadBala = 30;

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidadBala = nuevaVelocidad;
    }
}
