using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [SerializeField] Slider progressSlider;
    [SerializeField] int levelPlatformsCount;
    [SerializeField] PlayerJumpState playerJump;
    public void UpdateLevelProgressBar()
    {
        progressSlider.value = playerJump.currentTargetIndex / levelPlatformsCount;
    }
}
