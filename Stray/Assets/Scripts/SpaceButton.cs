using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceButton : MonoBehaviour
{
    //The canvas you want to enable
    public GameObject canvas;

    void Start()
    {
        canvas.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Check if the object has the tag car
        if (other.gameObject.tag == "Player")
        {
            //Activate the canvas
            Debug.Log("InCollider");
            canvas.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("OutCollider");
            canvas.SetActive(false);
        }
    }
}