using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessScroll : MonoBehaviour
{
    [SerializeField] private GameObject[] partesDenivel;
    [SerializeField] private float DistanceMinima;
    [SerializeField] Transform puntoFinal;
    [SerializeField] private int cantidadInicial;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        for (int i = 0; i < cantidadInicial; i++)
        {
            GeneradorParteNivel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.position,puntoFinal.position) < DistanceMinima)
        {
            GeneradorParteNivel();
        }
    }
    private void GeneradorParteNivel()
    {
        int numeroAleatorio=Random.Range(0,partesDenivel.Length);
        GameObject nivel=Instantiate(partesDenivel[numeroAleatorio], puntoFinal.position, Quaternion.identity);
        puntoFinal = BuscarPuntoFinal(nivel, "PuntoFinal");
    }
    private Transform BuscarPuntoFinal(GameObject parteDeNivel, string tag)
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
    }
}
