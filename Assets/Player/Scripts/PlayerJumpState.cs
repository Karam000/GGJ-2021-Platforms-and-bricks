using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : MonoBehaviour
{
    Vector3 jump;
    public float jumpForce = 2.0f;
    Rigidbody rb;
    [Range(20f, 70f)] public float jumpAngle;
    Vector3 target;
    [HideInInspector] public int currentTargetIndex = 0;
    [SerializeField] List<GameObject> targets;
    Vector3 currentTarget;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public Vector3 GetNextTargetNode()
    {
        if (targets.Count >= currentTargetIndex+1)
        {
            currentTarget = targets[currentTargetIndex].transform.position;
            currentTargetIndex++;
            return currentTarget;
        }
        return -1 * Vector3.one;
    }
    public void JumpNormal()
    {
        if(Player.isGrounded)
        {
            Player.isGrounded = false;
            Player.goingToPlatform = false;
            jump = new Vector3(0.0f, 2.0f, 0.0f);

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }
    public void JumpCurved()
    {
        //character = this.transform.GetChild(0).gameObject;
        if (Player.prevPlatform == null || (Player.isGrounded && Player.canChangePlatform))
        {
            Player.reachedPlatform = false;
            Player.isGrounded = false;
            Player.goingToPlatform = true;

            Vector3 startPos = this.transform.position;
            target = GetNextTargetNode();

            if (target != -1 * Vector3.one)
            {
                Vector3 projectileXZPos = new Vector3(startPos.x, 0.0f, startPos.z);
                Vector3 targetXZPos = new Vector3(target.x, 0.0f, target.z);

                this.transform.LookAt(targetXZPos);

                float R = Vector3.Distance(projectileXZPos, targetXZPos);
                float G = Physics.gravity.y;
                float tanAlpha = Mathf.Tan(jumpAngle * Mathf.Deg2Rad);
                float H = target.y - transform.position.y;

                //float distance = Vector3.Distance(startPos, target);
                float Vz = Mathf.Sqrt(G * R * R / (2.0f * (H - R * tanAlpha)));
                float Vy = tanAlpha * Vz;

                Vector3 localVelocity = new Vector3(0f, Vy, Vz);
                Vector3 globalVelocity = transform.TransformDirection(localVelocity);

                rb.velocity = globalVelocity;
            }
        }

    }

}
