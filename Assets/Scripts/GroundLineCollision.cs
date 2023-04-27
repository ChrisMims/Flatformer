using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Tools;
using Sirenix.OdinInspector;

[RequireComponent(typeof(MMBezierLineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]

public class GroundLineCollision : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;
    private LineRenderer lineRenderer;

    [Button("Initialize")]
    void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        lineRenderer = GetComponent<LineRenderer>();

        // When the line is moved, the collider doesn't stay aligned.
        // Running this at Start adjusts the collider's offset to align
        // it with the drawn object
        Vector2 colliderOffset = (Vector2)transform.position;
        edgeCollider.offset = -colliderOffset;

    }

    void Update()
    {
        SetEdgeCollider(lineRenderer);
    }
    private void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();
        for(int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(i);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }

        edgeCollider.SetPoints(edges);
    }
}
