using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    public float radius = 5f;
    [Range(1, 360)] public float angle = 45f;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;

    public GameObject water;

    public bool canSeeWater;

    public event Action OnWaterSeen;
    void Start()
    {
        water = GameObject.FindGameObjectWithTag("Water");
    }

    // Update is called once per frame
    void Update()
    {
        FOV();
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 0)
        {
            Transform target = rangeCheck[0].transform;
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector2.Distance(transform.position, target.position);

                if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                {
                    canSeeWater = true;
                    OnWaterSeen?.Invoke();
                    Destroy(water);
                }
                else
                {
                    canSeeWater = false;
                }
            }
            else
            {
                canSeeWater = false;
            }
        }
        else if (canSeeWater)
        {
            canSeeWater = false;
        }
    }
}
