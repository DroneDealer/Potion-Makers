using UnityEngine;
using System;
public class Debugging : MonoBehaviour
{
    void OnDisable()
    {
        Debug.LogError($"[Debugging] {gameObject.name} was DISABLED!");
        Debug.LogError(Environment.StackTrace); // This shows what exactly disabled the panel
    }
    void OnEnable()
    {
        Debug.Log($"[Debugging] {gameObject.name} was ENABLED!");
    }
}