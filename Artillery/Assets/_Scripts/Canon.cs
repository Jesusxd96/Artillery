using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField]private GameObject balaPrefab;
    private GameObject puntaCanon;//Donde se instanciara la bala
    private float rotacion;

    // Start is called before the first frame update
    void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rotacion += Input.GetAxis("Horizontal") * GameManager.velocidadRotacion;
        if(rotacion<=90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);//Se hace asi por como esta posicionado el canon
        }
        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;
        if (GameManager.disparosRestantes != 0)//Si los disparos no son 0, puedes disparar
        {//Se que no es la solucion mas optima, pero funciona de momento sin cambiar mucho el codigo
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject temp = Instantiate(balaPrefab, puntaCanon.transform.position, transform.rotation);
                Rigidbody tempRB = temp.GetComponent<Rigidbody>();
                Vector3 direccionDisparo = transform.rotation.eulerAngles;
                direccionDisparo.y = 90 - direccionDisparo.x;//Nuevamente, se hace en Z por la rotacion del gameobject
                tempRB.velocity = direccionDisparo.normalized * GameManager.velocidadBala;
                GameManager.disparosRestantes -= 1;
            }
        }
        else
        {
            Debug.Log("F, te quedaste sin disparos");
        }
    }
}
