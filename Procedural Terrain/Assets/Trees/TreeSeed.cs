using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSeed : MonoBehaviour
{
    public GameObject tree;

    Transform player;
    Rigidbody rb;

    TreeRules treeRules = new TreeRules();
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        rb.AddForce((player.transform.forward + Vector3.up) * 200);
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.CompareTag("Ground"))
        {
            GameObject newTree = Instantiate(tree, new Vector3(transform.position.x, transform.position.y - 6f, transform.position.z), Quaternion.identity);
            TreeGenerator treeGen = newTree.GetComponent<TreeGenerator>();

            float num = Random.Range(0, 5);
            if (num <= 1)
            {
                treeGen.rules = treeRules.reed;
                treeGen.axiom = "R";
                treeGen.GenerateTree();
                treeGen.GenerateNextIteration();
                treeGen.GenerateNextIteration();
                treeGen.GenerateNextIteration();
            }
            else if (num <= 2)
            {
                treeGen.rules = treeRules.twistingTree;
                treeGen.axiom = "F+F+";
                treeGen.GenerateTree();
                treeGen.GenerateNextIteration();
                treeGen.GenerateNextIteration();
            }
            else if (num <= 3)
            {
                treeGen.rules = treeRules.smallTree;
                treeGen.axiom = "+FF+R";
                treeGen.GenerateTree();
                treeGen.GenerateNextIteration();
                treeGen.GenerateNextIteration();
            }
            else if (num <= 4)
            {
                treeGen.rules = treeRules.twistedLeaningTree;
                treeGen.axiom = "+FF+R";
                treeGen.GenerateTree();
                treeGen.GenerateNextIteration();
                treeGen.GenerateNextIteration();
            }
            else
            {
                treeGen.rules = treeRules.fanTree;
                treeGen.axiom = "+FF+R";
                treeGen.GenerateTree();
                treeGen.GenerateNextIteration();
                treeGen.GenerateNextIteration();
            }
        }
    }
}
