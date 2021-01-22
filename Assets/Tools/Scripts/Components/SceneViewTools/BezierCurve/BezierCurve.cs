using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    [SerializeField]
    Vector3[] points = new Vector3[] { new Vector3(-1, -1), new Vector3(-1, 1), new Vector3(1, 1), new Vector3(1, -1) };
    [SerializeField]
    int smoothness = 10;

    [SerializeField, HideInInspector]
    Vector3[] bezierCurvePoints;
    [HideInInspector]
    public float distance;


    // transform between world and local space
    public Vector3[] Points
    {
        get
        {
            Vector3[] _p = new Vector3[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                _p[i] = transform.TransformPoint(points[i]);
            }

            return _p;
        }
        set
        {
            Vector3[] _p = new Vector3[value.Length];

            for (int i = 0; i < value.Length; i++)
            {
                _p[i] = transform.InverseTransformPoint(value[i]);
            }

            points = _p;
        }
    }

    public Vector3[] BezierCurvePoints => bezierCurvePoints;

#if UNITY_EDITOR
    public Color curveColor = Color.white;
    public float curveWidth = 1f;
    [SerializeField]
    bool drawGizmos = true;
#endif
    [SerializeField]
    bool calculateInAwake = false, calculateDistance = true;

    private void Awake()
    {
        if (calculateInAwake)
            CalculateBezierPoints();
    }

    public void CalculateBezierPoints() => bezierCurvePoints = GetBezierPoints(Points);

    public void DeletePoints()
    {
        distance = 0;
        bezierCurvePoints = null;
    }

    private Vector3 BezierPoint(float t, Vector3[] points)
    {
        //t = Mathf.Clamp01(t);
        float b = 1 - t;

        // func of bezier
        return points[0] * b * b * b + points[1] * 3 * t * b * b + points[2] * 3 * t * t * b + points[3] * t * t * t;
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (drawGizmos)
        {
            Vector3[] _points = Points;

            Gizmos.DrawLine(_points[0], _points[1]);
            Gizmos.DrawLine(_points[3], _points[2]);
        }
    }
#endif

    private Vector3[] GetBezierPoints(Vector3[] points)
    {
        Vector3[] bezierPoints = new Vector3[smoothness];

        for (int i = 0; i < smoothness; i++)
            bezierPoints[i] = BezierPoint((float)i / (smoothness - 1), points);

        if (calculateDistance)
        {
            distance = 0;

            for (int i = 1; i < smoothness; i++)
                distance += Vector3.Distance(bezierPoints[i], bezierPoints[i - 1]);
        }

        return bezierPoints;
    }

    public void DrawAndRemoveLineInWorld(bool draw)
    {
        LineRenderer lr;

        if(draw)
        {
            if(!TryGetComponent(out lr))
            {
                lr = gameObject.AddComponent<LineRenderer>();
            }

            Vector3[] bezierPoints = GetBezierPoints(Points);

            lr.positionCount = bezierPoints.Length;
            lr.SetPositions(bezierPoints);
        }
        else
        {
            if(TryGetComponent(out lr))
            {
                lr.positionCount = 0;
            }
        }
    }
}