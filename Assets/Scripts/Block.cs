using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private bool isColided = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        //if (isColided == false)
       // {
            if (collision.gameObject.tag=="Player")
            {
                print(collision.gameObject.name);
                GetComponent<MeshRenderer>().material.color = Color.red;
                ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                scoreManager.score--;
                isColided = true;
            }
            
       // }

    }
}
