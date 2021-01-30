using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    [SerializeField] PlatformTimer timer;
    public int maxNumberOfJumps;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag(GameTags.PlayerTag))
        {
            timer.StartTimer();
        }
    }
}
