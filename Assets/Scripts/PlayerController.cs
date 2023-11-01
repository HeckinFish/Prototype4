using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPowerup = false;
    private float powerupStrength = 50;
    public GameObject powerupIndicator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        rb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        powerupIndicator.transform.position = transform.position + new Vector3(0, 1, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with " + collision.gameObject.name + "with powerup set to " + hasPowerup);
            enemyRb.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
