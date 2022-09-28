using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject playerDeadEfect;
    private Rigidbody rb;
    private Vector3 movement;
    private TimeManager timeManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timeManager = FindObjectOfType<TimeManager>();
    }
    void Update()
    {
        if (timeManager.gameOver == false && timeManager.gameFinished == false)
        {
            MoveThePlayer();
        }

        if (timeManager.gameOver == true || timeManager.gameFinished == true)
        {
            rb.isKinematic = true;
        }


    }
    private void MoveThePlayer()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        movement = new Vector3(x, 0, z);
        rb.AddForce(movement);
    }
    private void OnDisable()
    {
        Instantiate(playerDeadEfect, transform.position, transform.rotation);
    }
}
