using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarMaskScript : MonoBehaviour
{
    public void MoveHealthMask(int currentValue, int maxValue)
    {
        float percentToMove = 2*((float)currentValue / (float)maxValue);
        transform.localPosition = new Vector3(percentToMove - 2, 0, 0);
    }
}
