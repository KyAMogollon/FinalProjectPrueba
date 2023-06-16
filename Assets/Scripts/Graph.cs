using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] GameObject nodePrefab;
    private GameObject currentNode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InsertNode(float positionX, float positionY, float positionZ)
    {
        currentNode=Instantiate(nodePrefab, transform.position, transform.rotation);
        currentNode.GetComponent<NodeController>().SetInitialValues(positionX, positionY, positionZ);
    }
}
