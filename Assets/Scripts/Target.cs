using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private TargetType _targetType;
    [SerializeField]
    [Range(0,120)]
    private float _influeceRadius;
    [SerializeField]
    [Range(-50,50)]
    private float _weight;

    private float _maxWeight = 50;

    public float GetAcceleration(Vector3 boidPosition)
    {
        float distance = (transform.position - boidPosition).magnitude;
        if (distance > _influeceRadius) 
            return 0;

        float resultWeight;
        if (_targetType == TargetType.CloseAttracter)
        {
            resultWeight = _weight / distance;
        }
        else
        {
            resultWeight = _weight * Mathf.Pow(distance / 20,2);
        }

        // return resultWeight;
        // Debug.Log(Mathf.Clamp(resultWeight, -_maxWeight, _maxWeight));
        return Mathf.Clamp(resultWeight, -_maxWeight, _maxWeight);
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _influeceRadius);
    }
    
}
[Serializable]
public struct TargetParams
{
    public Vector3 offsetToTarget;
    public float targetWheight;
}

enum TargetType
{
    CloseAttracter,
    FarAttracter,
    // AntiAttracter
}