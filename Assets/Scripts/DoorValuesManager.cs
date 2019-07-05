using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorValuesManager : MonoBehaviour
{
    public List<DoorValues> doors;

    private void Start() {
        GameManager.AddDoorsValues(doors.ToArray());
    }
}
