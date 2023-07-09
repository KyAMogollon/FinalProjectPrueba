using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScroll : MonoBehaviour
{
    GenericList<GameObject> listObstaculos;
    [SerializeField] Transform puntoFinal;
    [SerializeField] GameObject obstaculo1;
    [SerializeField] GameObject obstaculo2;
    [SerializeField] GameObject obstaculo3;
    //[SerializeField] GameObject obstaculo4;
    public float timeToRespawn = 3f;
    private float enemyToRespawn=0;
    // Start is called before the first frame update
    private void Awake()
    {
        listObstaculos = new GenericList<GameObject>();
        listObstaculos.AddNoteAtStart(obstaculo1);
        listObstaculos.AddNoteAtStart(obstaculo2);
        listObstaculos.AddNoteAtStart(obstaculo3);
        //listObstaculos.AddNoteAtStart(obstaculo4);
    }
    void Start()
    {
        //InvokeRepeating("GeneradorParteNivel", timeToRespawn, timeToRespawn);
    }

    // Update is called once per frame
    void Update()
    {
        enemyToRespawn +=Time.deltaTime;
        if (enemyToRespawn >= timeToRespawn)
        {
            enemyToRespawn = 0;
            GeneradorParteNivel();
        }
    }
    private void GeneradorParteNivel()
    {
        int numeroAleatorio=Random.Range(0,listObstaculos.Count);
        Instantiate(listObstaculos.GetNodeAtPosition(numeroAleatorio), puntoFinal.position, Quaternion.identity);
        //puntoFinal = BuscarPuntoFinal(nivel, "PuntoFinal");
    }
    /*private Transform BuscarPuntoFinal(GameObject parteDeNivel, string tag)
    {
        Transform punto = null;
        foreach(Transform ubicacion in parteDeNivel.transform)
        {
            if (ubicacion.CompareTag(tag))
            {
                punto = ubicacion;
                break;
            }
        }
        return punto;
    }*/
}
