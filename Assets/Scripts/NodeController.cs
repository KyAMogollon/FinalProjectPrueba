using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    private GenericList<NodeController> allAdjacentNodes;
    private float positionX;
    private float positionY;
    private float positionZ;
    void Start()
    {
        allAdjacentNodes = new GenericList<NodeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetInitialValues(float positionX, float positionY, float positionZ)
    {
        this.positionX = positionX;
        this.positionY = positionY;
        this.positionZ = positionZ;
        transform.position = new Vector3(positionX, positionY, positionZ);
    }
    public void AddNodeAdjacent(NodeController node)
    {
        allAdjacentNodes.AddNoteAtStart(node);
    }
}
