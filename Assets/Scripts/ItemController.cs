using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //Here object will smt
        meshRenderer.material.color = Color.yellow;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DZone"))
        {
            gameObject.SetActive(false);

            //Trigger game over here
        }
    }
}
