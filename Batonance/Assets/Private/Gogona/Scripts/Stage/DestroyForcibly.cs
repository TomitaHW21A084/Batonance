using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForcibly : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy")) {
            AdministerGameState.instance.GameOver();
            Destroy(other.gameObject, 3);
        }
    }
}
