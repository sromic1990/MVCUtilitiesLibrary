using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilitiesLibrary.Components
{
    public class DestroyAfterSomeTime : MonoBehaviour
    {
        [SerializeField] private float secondsToDestroy;
        
        private void Start()
        {
            Destroy(gameObject, secondsToDestroy);
        }
    }
}
