using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    [SerializeField] float speed = 3f;
    [SerializeField] float stopSpeed = 1f;
    [SerializeField] GameObject enemyDeadEfect;


    void Start()
    {


        target = GameObject.FindWithTag("Player").GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > stopSpeed)
            {

                transform.position += transform.forward * speed * Time.deltaTime;
            }

        }



    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TimeManager timeManager = FindObjectOfType<TimeManager>();
            timeManager.gameOver = true;
            Destroy(collision.gameObject);

        }
    }


    private void OnDisable()
    {
        Instantiate(enemyDeadEfect, transform.position, transform.rotation);
    }

}
