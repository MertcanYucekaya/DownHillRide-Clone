using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rigi;
    float screenWidth;
    float touchPosition;
    public float forceAmount;
    public float gravity;
    public bool isFinishGame = false;
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        screenWidth = Screen.width;
    }

    
    void Update()
    {
        transform.position += Vector3.down * gravity*Time.deltaTime;
        if (isFinishGame == false)
        {
            if (Input.touchCount == 1)
            {
                touchPosition = Input.GetTouch(0).position.x;
                if (touchPosition > screenWidth / 2)
                {
                    rigi.velocity = Vector3.right * forceAmount;
                }
                else
                {
                    rigi.velocity = Vector3.left * forceAmount;
                }
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            isFinishGame = true;
        }
    }
}
