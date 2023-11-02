using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class cannon : MonoBehaviour
{

    public GameObject cannonBall;
    public GameObject spawn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        
        {
            Shoot(5);
        }

        if (Input.GetKeyDown(KeyCode.E))

        {
            StartCoroutine(SteadyShot(6, 0.5f));
        }
    }

    public void Shoot( int numberOfBalls)
    {
        for(int i = 0; 1 < numberOfBalls; i++)
        {
            Instantiate(cannonBall, spawn.transform.position, spawn.transform.rotation);
        }
    }

    IEnumerator SteadyShot(int numberOfBalls, float delay)
    {
        for (int i = 0; 1 < numberOfBalls; i++)
        {
            Instantiate(cannonBall, spawn.transform.position, spawn.transform.rotation);
            yield return new WaitForSeconds(delay);
        }
    }
}
