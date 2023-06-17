using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField] GameObject nodePrefab;
    private GameObject currentNode;
    GenericList<NodeController> allNodes;
    [SerializeField] EnemyController enemy;
    // Start is called before the first frame update
    void Awake()
    {
        allNodes = new GenericList<NodeController>();
    }
    void Start()
    {
        InsertNode(3, -0.84f, -6.67f, "0");
        InsertNode(3, 4.48f, 5.41f, "1");
        InsertNode(3, 5.9f, -3.13f, "2");
        InsertNode(3, -2f, 4.65f, "3");

        AddNodeAdjacent("0",new string [] {"1","2","3"});
        AddNodeAdjacent("1", new string[] { "2","3","0" });
        AddNodeAdjacent("2", new string[] { "3","0","1" });
        AddNodeAdjacent("3", new string[] { "0","1","2" });

        currentNode = allNodes.GetNodeAtPosition(3).gameObject;
        enemy.ChangeMovePosition(currentNode.gameObject.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
    }
    void InsertNode(float positionX, float positionY, float positionZ, string nodeTag)
    {
        currentNode=Instantiate(nodePrefab, transform.position, transform.rotation, gameObject.transform);
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
