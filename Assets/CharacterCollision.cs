using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    public static bool isGrounded;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == GameTags.PlatformTag)
        {
            isGrounded = true;
        }
    }
}
