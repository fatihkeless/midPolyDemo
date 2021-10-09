using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // odadaki fizik sorunlarýný çözmek için bunu kullandým
    public float speed;
    private float verticalInput = 1;
    private float horizontalInput = 1;

    void Update()
    {
        moveRobot();
    }


    void moveRobot()
    {

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);


    }



}
