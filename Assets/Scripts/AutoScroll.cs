using UnityEngine;
using TMPro;
using System.Collections;

public class AutoScroll : MonoBehaviour
{
    float speed = 100.0f;
    float textPosBegin = -596.0f;
    public float boundaryTextPosEnd = 2636.0f;
    RectTransform myGameObjectTransform;
    [SerializeField] TextMeshProUGUI mainText;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myGameObjectTransform = gameObject.GetComponent<RectTransform>();
        StartCoroutine(AutoScrollText());
    }

    IEnumerator AutoScrollText()
    {
        while (myGameObjectTransform.localPosition.y < boundaryTextPosEnd)
        {
            myGameObjectTransform.Translate(Vector3.up * speed * Time.deltaTime);
            yield return null;
        }
    }
}
