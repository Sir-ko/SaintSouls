using System.Collections;
using UnityEngine;

public class FlickLight : MonoBehaviour
{
    Vector3 _startPosLight;
    [Tooltip("The light attached to this script")]
    public Light lig;
    [Tooltip("The light color")]
    public Color colorLight = Color.white;
    [Space]
    [Tooltip("The minimun Intensity Light")]
    public float min = 0.0f;
    [Tooltip("The maximun Intensity Light")]
    public float max = 2.0f;
    [Space(20)]
    private float _flickIntensity;
    [Tooltip("The timing of the _nowSpeed for flick Intensity of the light")]
    public float timer = 1.0f;
    [Tooltip("The waiting time for the light to flicker")]
    public float smooth = 0.1f;
    [Space(10)]
    [Header("Set a false movement of the shadow")]
    [Space(10)]
    public bool moveShadow = false;
    [Tooltip("The _nowSpeed of the movement of light")]
    public float _nowSpeedMoveShadow = 1f;
    [Tooltip("The _nowSpeed smooth of the movement of light")]
    public float _nowSpeedSmoothShadow = 50f;

    // Start is called before the first frame update
    void Start()
    {
        if (lig == null)
        {
            lig = GetComponent<Light>();
            _startPosLight = lig.transform.position;
        }

        StartCoroutine(SmoothFLick());
    }

    // Update is called once per frame
    void Update()
    {
        if (lig == null)
            return;

        StartCoroutine(SmoothFLick());
        MoveShadowLight();
    }

    private IEnumerator SmoothFLick()
    {
        _flickIntensity = Mathf.Lerp (_flickIntensity, (Random.Range(min, max)), timer * Time.smoothDeltaTime);
        lig.intensity = _flickIntensity;
        lig.color = colorLight;
        yield return new WaitForSeconds(smooth);
    }

    void MoveShadowLight()
    {
        if (moveShadow)
        {
            lig.transform.position = _startPosLight + (Random.insideUnitSphere * _nowSpeedMoveShadow / _nowSpeedSmoothShadow);
        }
        else
        {
            moveShadow = false;
            lig.transform.position = _startPosLight;
        }
    }
}
