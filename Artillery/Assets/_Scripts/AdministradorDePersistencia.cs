using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorDePersistencia : MonoBehaviour
{//a pesar de ser una copia del proyecto anterior, esta hecho asi para poder guardar varios scriptable objects de ser necesario.
    public List<PuntajeConfiguracionJugador> ObjetosAGuardar;
    public void OnEnable()
    {
        for (int i = 0; i < ObjetosAGuardar.Count; i++)
        {
            var so = ObjetosAGuardar[i];
            so.Cargar();
        }
    }

    public void OnDisable()
    {
        for (int i = 0; i < ObjetosAGuardar.Count; i++)
        {
            var so = ObjetosAGuardar[i];
            so.Guardar();
        }
    }
}
