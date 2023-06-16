using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpaunCont : MonoBehaviour
{
    [SerializeField] private GameObject Tree;
    private int n;
    private void Start()
    {
        n =  Random.Range(0,1);
        if (n == 0)
        {
            Instantiate(Tree,new Vector2(transform.position.x+Random.Range(-0.5f,0.5f), transform.position.y + Random.Range(-0.5f, 0.5f)),Quaternion.identity);
        }
    }
}
