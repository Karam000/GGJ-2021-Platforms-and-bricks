using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    [SerializeField] PlatformTimer timer;
    [SerializeField] float toleranceDuration;
    public int maxNumberOfJumps;
    public bool isLevelLastPlatform;
    float collisionTime;
    bool timerStarted;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.PlayerTag))
        {
            Debug.Log("Enter");
            collisionTime = Time.time;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.CompareTag(GameTags.PlayerTag))
        {
            Debug.Log((Time.time - collisionTime));
            if((Time.time - collisionTime) > toleranceDuration && !timerStarted)
            {
                timer.StartTimer();
                timerStarted = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.PlayerTag))
        {
            Debug.Log("Exit");
            timer.StopTimer();
            timerStarted = false;
        }
    }
}
