using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    private GenericList<NodeController> allAdjacentNodes;
    private float positionX;
    private float positionY;
    private float positionZ;
    public string nodeTag;
    void Awake()
    {
        allAdjacentNodes = new GenericList<NodeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetInitialValues(float positionX, float positionY, float positionZ, string nodeTag)
    {
        this.positionX = positionX;
        this.positionY = positionY;
        this.positionZ = positionZ;
        transform.position = new Vector3(positionX, positionY, positionZ);
        this.nodeTag = nodeTag;
    }
    public NodeController SelectNexNode()
    {
        int nodeSelected=Random.Range(0, allAdjacentNodes.Count);
        return allAdjacentNodes.GetNodeAtPosition(nodeSelected);
    }
    public void AddNodeAdjacent(NodeController node)
    {
        allAdjacentNodes.AddNoteAtStart(node);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Enemy")
        {
            other.GetComponent<EnemyController>().ChangeMovePosition(SelectNexNode().gameObject.transform.position);
        }
    }
}
