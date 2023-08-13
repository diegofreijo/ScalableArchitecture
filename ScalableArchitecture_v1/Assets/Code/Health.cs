using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int max;
    [SerializeField] private int current;

    public float CurrentRatio => (float)current / (float)max;

    public void Damage(int amount) => current -= amount;
}
