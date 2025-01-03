using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Canon : MonoBehaviour
{
    public static bool bloqueado;//Se podra disparar o esta bloqueado el cannon?
    public AudioClip clipDisparo;
    private GameObject SonidoDisparo;
    private AudioSource SourceDisparo;

    [SerializeField]private GameObject balaPrefab;
    public GameObject ParticulasDisparo;
    public PuntajeConfiguracionJugador velocidadBala;

    private GameObject puntaCanon;//Donde se instanciara la bala
    private float rotacion;

    public CanonControls canonControls;
    private InputAction apuntar;
    private InputAction modificarFuerza;
    private InputAction disparar;

    private void Awake()
    {
        canonControls = new CanonControls();
    }
    private void OnEnable()
    {   //Primero se le asignan las acciones del action map deseado a las variables InputAction
        apuntar = canonControls.Canon.Apuntar;
        modificarFuerza = canonControls.Canon.ModificarFuerza;
        disparar = canonControls.Canon.Disparar;
        //Luego estas se deben de habilitar
        apuntar.Enable();
        modificarFuerza.Enable();
        disparar.Enable();
        disparar.performed += Disparar;
    }

    // Start is called before the first frame update
    void Start()
    {
        puntaCanon = transform.Find("PuntaCanon").gameObject;
        SonidoDisparo = GameObject.Find("SonidoDisparo");
        SourceDisparo = SonidoDisparo.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ModificarFuerzaBala();
        rotacion += apuntar.ReadValue<float>() * GameManager.velocidadRotacion;
        //Se le pasa el valor de Apuntar y se cambia la rotacion en base a eso
        if (rotacion<=90 && rotacion >= 0)
        {
            transform.eulerAngles = new Vector3(rotacion, 90, 0.0f);//Se hace asi por como esta posicionado el canon
        }
        if (rotacion > 90) rotacion = 90;
        if (rotacion < 0) rotacion = 0;
        //if (GameManager.disparosRestantes != 0)//Si los disparos no son 0, puedes disparar
        //{//Se que no es la solucion mas optima, pero funciona de momento sin cambiar mucho el codigo
        //        //Disparar();
        //} //Ya se agrego y limita las balas, sin embargo el tiempo entre bala y bala no se aplica ahora
        else
        {
            //Debug.Log("F, te quedaste sin disparos");
        }
    }

    private void Disparar(InputAction.CallbackContext context)
    {//Lo de CallbackContext sirve para mandar a llamar al metodo cuando el contexto de disparar se este realizando/llamado
        if (GameManager.disparosRestantes != 0 && GameManager.isGameWon==false)
        {//Si aun quedan disparos y el juego aun no se gana, se puede seguir disparando
            GameObject temp = Instantiate(balaPrefab, puntaCanon.transform.position, transform.rotation);
            //GameObject Particula = Instantiate(ParticulasDisparo, puntaCanon.transform.position, transform.rotation);
            Rigidbody tempRB = temp.GetComponent<Rigidbody>();
            SeguirCamara.objetivo = temp;
            Vector3 direccionDisparo = transform.rotation.eulerAngles;
            direccionDisparo.y = 90 - direccionDisparo.x;//Nuevamente, se hace en Z por la rotacion del gameobject
            Vector2 direccionParticulas = new Vector3(-90 + direccionDisparo.x, 90, 0);
            GameObject Particula = Instantiate(ParticulasDisparo, puntaCanon.transform.position, Quaternion.Euler(direccionParticulas), transform);
            tempRB.velocity = direccionDisparo.normalized * velocidadBala.velocidadBala;
            //tempRB.velocity = direccionDisparo.normalized * GameManager.velocidadBala.velocidadBala;
            //SourceDisparo.PlayOneShot(clipDisparo);
            SourceDisparo.Play();
            GameManager.disparosRestantes -= 1;
            bloqueado = true;
        }
    }
    private void ModificarFuerzaBala()
    {
        velocidadBala.velocidadBala = modificarFuerza.ReadValue<float>();
    }
}
