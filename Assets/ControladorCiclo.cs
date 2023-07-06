using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCiclo : MonoBehaviour
{
    [SerializeField] private Light lightglobal;
    [SerializeField] private CicloDia[] ciclosDia;
    [SerializeField] private float tiempoPorCiclo;
    private float tiempoActualCiclo = 0;
    private float porcentajeCiclo;
    private int cicloActual = 0;
    private int cicloSiguiente = 1;
    // Start is called before the first frame update
    void Start()
    {
        lightglobal.color = ciclosDia[0].colorCiclo;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoActualCiclo += Time.deltaTime;
        porcentajeCiclo = tiempoActualCiclo / tiempoPorCiclo;
        if (tiempoActualCiclo >= tiempoPorCiclo)
        {
            tiempoActualCiclo = 0;
            cicloActual = cicloSiguiente;
            if (cicloSiguiente + 1 > ciclosDia.Length-1)
            {
                cicloSiguiente = 0;
            }
            else
            {
                cicloSiguiente += 1;
            }
        }
        ChangeClimax(ciclosDia[cicloActual].colorCiclo, ciclosDia[cicloSiguiente].colorCiclo);
    }
    public void ChangeClimax(Color colorActual, Color siguienteColor)
    {
        lightglobal .color = Color.Lerp(colorActual, siguienteColor, porcentajeCiclo);
    }
}
