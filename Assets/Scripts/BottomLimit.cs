using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLimit : MonoBehaviour
{
    [SerializeField] GameObject respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().LoseLives(1);

            CharacterController cc = other.GetComponent<CharacterController>();
            cc.enabled = false;

            other.transform.position = respawnPoint.transform.position;

            cc.enabled = true;
        }
    }
}
