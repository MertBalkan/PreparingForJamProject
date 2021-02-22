using PreparingForJamProject.Concretes.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGround : MonoBehaviour, IOnGround
{
    [SerializeField] private Transform[] footGroundTransforms;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float distance;

    private bool _isOnGround;

    public bool IsOnGround { get => _isOnGround; set => _isOnGround = value; }

    void Update()
    {
        CheckIsOnGround(footGroundTransforms);
    }
    void CheckIsOnGround(Transform[] footGroundTransforms)
    {
        foreach (Transform foot in footGroundTransforms)
        {
            RaycastHit2D hit = Physics2D.Raycast(foot.transform.position, foot.transform.forward, distance, layerMask);
            Debug.DrawRay(foot.transform.position, foot.transform.forward * distance, Color.red);

            if (hit.collider != null) _isOnGround = true;
            else _isOnGround = false;

            Debug.Log("IsOnGround:" + _isOnGround);
        }
    }
}