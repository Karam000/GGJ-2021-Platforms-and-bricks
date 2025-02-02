﻿using SO.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehavior : MonoBehaviour
{
    [SerializeField] PlatformTimer timer;
    [SerializeField] float toleranceDuration;
    [SerializeField] EventSO updateLevelProgress;
    [HideInInspector] public bool finished = false;
    [SerializeField] TextMesh textMesh;
    public int maxNumberOfJumps;
    public bool isLevelLastPlatform;
    float collisionTime;
    bool timerStarted;

    private void Start()
    {
        textMesh.text = maxNumberOfJumps.ToString(); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.PlayerTag))
        {
            collisionTime = Time.time;
            updateLevelProgress.Raise();
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.CompareTag(GameTags.PlayerTag))
        {
            Debug.Log("Collision Stay");
            if((Time.time - collisionTime) > toleranceDuration && !timerStarted)
            {
                timer.StartTimer();
                timerStarted = true;
            }
            if(timer.timerIsEnded)
            {

                Destroy(Player.PlayercurrentPlatform.gameObject);
                LevelController.Instance.Lose();
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(GameTags.PlayerTag))
        {
            timer.StopTimer();
            timerStarted = false;
        }
    }
    public void UpdatePlatformNum(int value)
    {
        textMesh.text = value.ToString();
    }
}
