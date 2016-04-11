using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScaler : MonoBehaviour
{
    #region Variables
    private BootlegTween.MotionCurve selectedCurve;
    private RectTransform scale;
    private Vector3 startValue;
    private Vector3 endValue;
    private float curLerpTime;
    private float timeOfAnim;
    private float t = 0;
    #endregion

    #region Initialisers
    void Awake()
    {
        //Get the RectTransform component so it's easier to access
        scale = this.gameObject.GetComponent<RectTransform>();
        //Set the start value to the currect transform of this object
        startValue = scale.localScale;
    }

    /// <summary>
    /// Practically this is a constructor for the animation.
    /// </summary>
    /// <param name="endValue">The final Vector for the animation to play</param>
    /// <param name="timeOfAnim">The amount of time in seconds to play this animation for</param>
    /// <param name="curve">The motion curve to follow</param>
    public void SetAnimation(Vector3 endValue, float timeOfAnim, BootlegTween.MotionCurve curve)
    {
        this.endValue = endValue;
        this.timeOfAnim = timeOfAnim;
        this.selectedCurve = curve;
    }
    #endregion

    #region Update Methods
    void Update()
    {

        //While the animation is not yet finished.
        if (scale.localScale != endValue)
        {
            //Increment the current lerp time by deltatime
            curLerpTime += Time.deltaTime;

            if (curLerpTime > timeOfAnim)
            {
                curLerpTime = timeOfAnim;
            }
            //Do ease out elastic if selected
            if (selectedCurve == BootlegTween.MotionCurve.EaseOutElastic)
            {
                scale.localScale = ReturnTween(curLerpTime, startValue, (endValue - startValue), timeOfAnim);
            }
            else
            {
                //Call the time curve method to return the time percentage
                t = timeCurve(t);
                //Set the scale of the object to the Lerp
                scale.localScale = Vector3.Lerp(startValue, endValue, t);
            }
        }
        else //If the animation is finished
        {
            //Destroy this component
            Destroy(this);
        }

    }
    #endregion

    #region Utility Methods
    /// <summary>
    /// Method which determines the curve
    /// </summary>
    /// <param name="time">The current time of the anim</param>
    /// <returns></returns>
    float timeCurve(float time)
    {
        //Math stuff
        time = curLerpTime / timeOfAnim;
        //Depending on the curve type
        switch (selectedCurve)
        {
            case BootlegTween.MotionCurve.Linear:
                return time;
            case BootlegTween.MotionCurve.EaseIn:
                return 1f - Mathf.Cos(time * Mathf.PI * 0.5f);
            case BootlegTween.MotionCurve.EaseOut:
                return Mathf.Sin(time * Mathf.PI * 0.5f);
            case BootlegTween.MotionCurve.SmoothStep:
                return time * time * (3f - 2f * time);
            case BootlegTween.MotionCurve.SmootherStep:
                return time * time * time * (time * (6f * time - 15f) + 10f);
            default:
                return time += Time.deltaTime / timeOfAnim;
        }
    }

    public static float EaseOutElastic(float t, float b, float c, float d)
    {
        if (t == 0) return b;
        if ((t /= d) == 1) return b + c;
        float p = d * .3f;
        float s = 0;
        float a = 0;
        if (a == 0f || a < Mathf.Abs(c))
        {
            a = c;
            s = p / 4;
        }
        else {
            s = p / (2 * Mathf.PI) * Mathf.Asin(c / a);
        }
        return (a * Mathf.Pow(2, -10 * t) * Mathf.Sin((t * d - s) * (2 * Mathf.PI) / p) + c + b);
    }

    Vector3 ReturnTween(float _curLerpTime, Vector3 _startValue, Vector3 _endValue, float _timeOfAnim)
    {
        float x = EaseOutElastic(_curLerpTime, _startValue.x, _endValue.x, _timeOfAnim);
        float y = EaseOutElastic(_curLerpTime, _startValue.y, _endValue.y, _timeOfAnim);
        float z = EaseOutElastic(_curLerpTime, _startValue.z, _endValue.z, _timeOfAnim);
        return new Vector3(x, y, z);
    }

    #endregion

}