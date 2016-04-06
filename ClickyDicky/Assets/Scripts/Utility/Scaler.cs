using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scaler : MonoBehaviour
{

    private float timeOfAnim;
    private Vector3 endValue;
    private RectTransform scale;

    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    void Start()
    {
        scale = this.gameObject.GetComponent<RectTransform>();
        startTime = Time.time;
        journeyLength = Vector3.Distance(scale.localScale, endValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (scale.localScale.x != endValue.x)
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            Vector3.Lerp(scale.localScale, endValue, fracJourney);
        }
        else
        {
            Destroy(this);
        }
    }

    public void SetAnimation(Vector3 endValue, float timeOfAnim)
    {
        this.endValue = endValue;
        this.timeOfAnim = timeOfAnim;
    }
}
