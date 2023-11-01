using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangePickUp : MonoBehaviour
{
    [Header("Materials")]
    public Material defaultMaterial;
    public Material newMaterial;

    [Header("Duration")]
    public float duration;

    //Components

    private MeshRenderer myMr;
    private MeshRenderer playerMr;
    private Collider myCollider;


    // Start is called before the first frame update
    void Start()
    {
        myMr = GetComponent<MeshRenderer>();
        myCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if player
        if(other.gameObject.CompareTag("Player"))
        {
            //Get mesh render
            playerMr = other.gameObject.GetComponent<MeshRenderer>();

            //start coroutine
            StartCoroutine(ColorChange());

        }
    }

    IEnumerator ColorChange()
    {
        //change to new color
        playerMr.material = newMaterial;

        //wait
        yield return new WaitForSeconds(duration);

        //change back
        playerMr.material = defaultMaterial;
    }
}
