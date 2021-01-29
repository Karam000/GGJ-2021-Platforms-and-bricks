using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SO.Events;
using SO;
public class CharacterCollision : MonoBehaviour
{
    public static bool isGrounded;
    public VariableSO<int> NumSO;
    [SerializeField] EventSO OnChangeValue;

    public static PlatformBehavior PlayercurrentPlatform { get; private set; }
    private void Start()
    {
       NumSO = (VariableSO<int>)OnChangeValue.Value;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == GameTags.PlatformTag)
        {
            PlatformBehavior currentPlatform = collision.gameObject.GetComponent<PlatformBehavior>();
            PlayercurrentPlatform = currentPlatform;
            int max = currentPlatform.maxNumberOfJumps;
            isGrounded = true;
            NumSO.Value++;
            Debug.Log(NumSO.Value);
            if (NumSO.Value >= max)
            {
                Destroy(collision.gameObject);
                NumSO.Value = 0;
            }

        }
    }
   
}
