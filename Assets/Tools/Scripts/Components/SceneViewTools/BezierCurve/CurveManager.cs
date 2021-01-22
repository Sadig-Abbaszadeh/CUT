using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveManager : MonoBehaviour
{
    [SerializeField]
    protected BezierCurve[] curves;

    protected int curveIndex, pointIndex;

    protected Vector3[] points = new Vector3[0];

    protected virtual void Start()
    {
        ResetPath();
    }

    public Vector3 GetPoint()
    {
        pointIndex++;

        // get new curve
        if(pointIndex >= points.Length)
        {
            pointIndex = 0;
            curveIndex++;

            if (curveIndex >= curves.Length)
                return NullPointAction();

            points = curves[curveIndex].BezierCurvePoints;
        }

        return points[pointIndex];
    }

    public void ResetPath()
    {
        points = curves[0].BezierCurvePoints;
        curveIndex = 0;
        pointIndex = -1;
    }

    public List<Vector3> GetAllPoints()
    {
        List<Vector3> allPoints = new List<Vector3>();

        foreach (BezierCurve curve in curves)
            allPoints.AddRange(curve.BezierCurvePoints);

        return allPoints;
    }

    protected virtual Vector3 NullPointAction() => (points[points.Length - 1] - points[points.Length - 2]) * 99999;
}
