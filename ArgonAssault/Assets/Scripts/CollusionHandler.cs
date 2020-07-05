using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollusionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        deathFX.SetActive(true);
        Instantiate(deathFX, transform.position, Quaternion.identity);
        print("Player dead");
        SendMessage("OnPlayerDeath");
    }
}
