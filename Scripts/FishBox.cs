using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishBox : MonoBehaviour
{

    [SerializeField] private Text fishCountText;
    private void Update()
    {
        fishCountText.text = PlayerStats.Fishes.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerStats.Fishes--;
        }
    }
}
