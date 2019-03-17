using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Script Draws A Spot With Gizmo For Displaying Invisible Spot(The place where enemy resides before attack)
/// </summary>

public class DrawSpot : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.25f);
    }
}
