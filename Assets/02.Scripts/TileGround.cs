using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGround : MonoBehaviour
{
    private bool isBuildedPlace = false;
    public bool IsBuildedPlace { get { return isBuildedPlace; } set { isBuildedPlace = value; } }

    public void DetectTower()
    {
        isBuildedPlace = true;
    }
}

