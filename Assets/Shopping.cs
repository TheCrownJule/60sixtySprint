using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopping : MonoBehaviour
{
    public string pickupTag = "Pickup";

    private void Start()
    {
        gameObject.tag = pickupTag;
    }
}
