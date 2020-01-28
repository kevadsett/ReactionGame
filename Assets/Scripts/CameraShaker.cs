using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public AnimationCurve IntensityOverTime;

    private float ShakeTime;

    private bool ShouldShake;
    
    void Update()
    {
        if (ShouldShake == false)
        {
            return;
        }
        ShakeTime += Time.deltaTime;
        float ShakeAmount = IntensityOverTime.Evaluate(ShakeTime);
        transform.position = new Vector3((Random.value * 2 - 1) * ShakeAmount, (Random.value * 2 - 1) * ShakeAmount, 0);
    }

    public void Shake()
    {
        ShakeTime = 0;
        ShouldShake = true;
    }
}
