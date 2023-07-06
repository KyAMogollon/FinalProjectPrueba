using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] GameObject nodePrefab;
    private GameObject currentNode;
    GenericList<NodeController> allNodes;
    [SerializeField] EnemyController light;
    // Start is called before the first frame update
    void Awake()
    {
        allNodes = new GenericList<NodeController>();
        InsertNode(74.6f, 141.4f, 102.7f, "0");
        InsertNode(136.9f, 141.4f, 109.1f, "1");
        InsertNode(34.1f, 85.9f, 146, "2");
        InsertNode(193.8f, 141.4f, 119.1f, "3");
    }
    void Start()
    {

        AddNodeAdjacent("0",new string [] {"1"});
        AddNodeAdjacent("1", new string[] { "2" });
        AddNodeAdjacent("2", new string[] { "3" });
        AddNodeAdjacent("3", new string[] {"0"});

        currentNode = allNodes.GetNodeAtPosition(3).gameObject;
        light.ChangeMovePosition(currentNode.gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void InsertNode(float positionX, float positionY, float positionZ, string nodeTag)
    {
        currentNode=Instantiate(nodePrefab, transform.position, transform.rotation,transform);
        currentNode.GetComponent<NodeController>().SetInitialValues(positionX, positionY, positionZ,nodeTag);
        allNodes.AddNoteAtStart(currentNode.GetComponent<NodeController>());
    }
    void AddNodeAdjacent(string nodeTag, string [] allAdjacentTags)
    {
        NodeController selectedNode = SearchNode(nodeTag);
        for (int i = 0; i < allAdjacentTags.Length; i++)
        {
            selectedNode.AddNodeAdjacent(SearchNode(allAdjacentTags[i]));
        }
    }
    NodeController SearchNode(string nodeTag)
    {
        int position = 0;
        for (int i = 0; i < allNodes.Count; i++)
        {
            if (allNodes.GetNodeAtPosition(i).nodeTag == nodeTag)
            {
                position = i;
                break;
            }
        }
        return allNodes.GetNodeAtPosition(position);
    }
}
