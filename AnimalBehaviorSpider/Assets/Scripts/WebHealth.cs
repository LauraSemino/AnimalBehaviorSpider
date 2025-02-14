using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebHealth : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;
    public float weakSpeed;
    public bool webWeaken;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (webWeaken == true)
        {
            curHealth -= weakSpeed * Time.deltaTime;
        }
        
    }
}
