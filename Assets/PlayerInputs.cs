using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.Events;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] EventSO OnPlayerTab;
    [SerializeField] EventSO OnCollectGems;
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CharacterCollision.isGrounded)
        {
            OnPlayerTab.Raise();

            CharacterCollision.isGrounded = false;
            Debug.Log("clicked");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnCollectGems.Raise();
            Debug.Log("space");

        }
    }
}
