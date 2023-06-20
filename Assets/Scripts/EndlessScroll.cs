using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScroll : MonoBehaviour
{
    [SerializeField] private GameObject[] partesDenivel;
    [SerializeField] Transform puntoFinal;
    // Start is called before the first frame update
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
        int numeroAleatorio=Random.Range(0,partesDenivel.Length);
        Instantiate(partesDenivel[numeroAleatorio], puntoFinal.position, Quaternion.identity);
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
