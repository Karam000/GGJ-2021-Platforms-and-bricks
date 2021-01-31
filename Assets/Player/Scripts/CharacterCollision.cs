using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.Events;
using SO;
public class CharacterCollision : MonoBehaviour
{
    [SerializeField] Player player;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(GameTags.SafeZoneTag))
        {
            Player.isGrounded = true;
        }
        if (collision.gameObject.CompareTag(GameTags.PlatformTag))
        {
            Player.isGrounded = true;
            Player.reachedPlatform = true;
            PlatformBehavior currenPlatform = collision.gameObject.GetComponent<PlatformBehavior>();
            player.SetCurrentPlatform(currenPlatform);
        }
    }
}
