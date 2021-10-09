using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
    public GameObject dotPrefab;
    public int dotAmount;


    [Space]
    [Header("Line Variables")]

    public AnimationCurve followCurve;
    public float followSpeed;

    [Space]
    [Header("Pulse Variables")]

    public AnimationCurve expandCurve;
    public float expandAmount;
    public float expandSpeed;

    Vector3 startSize;
    Vector3 targetSize;

    float scrollAmount;

    GameObject[] dotArray;

    float dotGap;
    // Start is called before the first frame update
    void Start()
    {
        dotGap = 1f / dotAmount;
        InitPulseEffectVariables();
        SpawnDots();

    }

    void InitPulseEffectVariables()
    {
        startSize = transform.localScale;
        targetSize = startSize * expandAmount;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    void SpawnDots()
    {
        dotArray = new GameObject[dotAmount];
        for (int i = 0; i < dotAmount; i++)
        {
            GameObject _dot = Instantiate(dotPrefab);
            _dot.SetActive(false);
            dotArray[i] = _dot;
        }
    }

    public void SetDotPos(Vector3 startPos, Vector3 endPos)
    {
        for (int i = 0; i < dotAmount; i++)
        {
            Vector3 _dotPos = dotArray[i].transform.position;
            Vector3 _tagetPos = Vector2.Lerp(startPos, endPos, i * dotGap);

            float _smoothSpeed = (1f - followCurve.Evaluate(i * dotGap)) * followSpeed;

            //dotArray[i].transform.position = _tagetPos;

            dotArray[i].transform.position = Vector2.Lerp(_dotPos, _tagetPos, _smoothSpeed * Time.deltaTime);
        }
    }

    public void ChangeDotActiveState(bool state)
    {
        for (int i = 0; i < dotAmount; i++)
        {
            dotArray[i].SetActive(state);
        }
    }

    public void MakeUFOPulse()
    {
        scrollAmount += Time.deltaTime * expandSpeed;
        float _percent = expandCurve.Evaluate(scrollAmount);
        transform.localScale = Vector2.Lerp(startSize, targetSize, _percent);
    }

    public void ResetUFOSize()
    {
        transform.localScale = startSize;
        scrollAmount = 0f;
    }
}
