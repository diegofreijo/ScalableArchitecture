using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(playerTransform.position);
    }
}
