using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScroll : MonoBehaviour
{
    GenericList<GameObject> listObstaculos;
    [SerializeField] private GameObject[] partesDenivel;
    [SerializeField] Transform puntoFinal;
    // Start is called before the first frame update
    private void Awake()
    {
        listObstaculos = new GenericList<GameObject>();
        for(int i = 0; i < partesDenivel.Length; i++)
        {
            listObstaculos.AddNodeAtPosition(partesDenivel[i],i);
        }
    }
    void Start()
    {
        GeneradorParteNivel();
        InvokeRepeating("GeneradorParteNivel",1.5f,1.5f);
    }

    // Update is called once per frame
    void Update()
    {
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
