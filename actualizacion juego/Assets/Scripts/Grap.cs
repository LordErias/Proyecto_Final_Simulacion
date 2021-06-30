using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grap : MonoBehaviour
{
    public bool canGrap=false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("i can grap");
            canGrap = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        canGrap = false;
    }
}
