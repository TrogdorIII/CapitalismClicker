using UnityEngine;
using System.Collections;

public class BootlegTween
{

    public enum MotionCurve { Linear, EaseIn, EaseOut, SmoothStep, SmootherStep }
    public enum AnimType { Scale }


    public static void ScaleUI(GameObject tweenObject, Vector3 endValue, float animationTime, MotionCurve curve)
    {
        GameObject.Destroy(tweenObject.GetComponent<UIScaler>());
        tweenObject.AddComponent<UIScaler>().SetAnimation(endValue, animationTime, curve);
    }
}
