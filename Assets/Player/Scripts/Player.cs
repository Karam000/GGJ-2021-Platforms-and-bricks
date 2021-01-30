using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.Events;
using SO;
public class Player : MonoBehaviour
{
    [SerializeField] EventSO OnChangeValue;
    
    public VariableSO<int> NumSO;

    [SerializeField] CharacterCollision Character;

    public static bool isGrounded;
    public static bool reachedPlatform;
    public static PlatformBehavior PlayercurrentPlatform { get; set; }
    public static PlatformBehavior prevPlatform { get; set; }

    private void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void UpdateJumpsNum()
    {
        if (reachedPlatform)
        {
            NumSO.Value--;
            Debug.Log(NumSO.Value);
            if (NumSO.Value <= 0)
            {
                Destroy(PlayercurrentPlatform.gameObject);
                ResetJumpsNum();
            } 
        }
    }

    public void ResetJumpsNum()
    {
        if (reachedPlatform)
        {
            NumSO.Value = PlayercurrentPlatform.maxNumberOfJumps;

        }    
    }

    public void SetCurrentPlatform(PlatformBehavior currentPlatform)
    {
        if (prevPlatform == null || currentPlatform != prevPlatform)
        {
            PlayercurrentPlatform = currentPlatform;
            prevPlatform = PlayercurrentPlatform;
            NumSO = (VariableSO<int>)OnChangeValue.Value;
            NumSO.Value = PlayercurrentPlatform.maxNumberOfJumps;
        }
        else
        {
            PlayercurrentPlatform = prevPlatform;
        }
    }

}
