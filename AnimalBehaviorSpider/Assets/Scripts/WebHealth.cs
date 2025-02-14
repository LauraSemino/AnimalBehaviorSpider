using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebHealth : MonoBehaviour
{
    public float curHealth;
    public float maxHealth;
    public float weakSpeed;
    public bool webWeaken;

    public float webBreak;
    public float webTime;
    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        webTime = 1;
        webBreak = 100;
    }

    // Update is called once per frame
    void Update()
    {
        webTime -= Time.deltaTime;
        if (webTime <= 0)
        {
            webBreak = Random.Range(1, 100);
            webTime = 1;
        }
        
        if (webBreak <= 5)
        {
            webWeaken = true;
        }
        if (webWeaken == true)
        {
            curHealth -= weakSpeed * Time.deltaTime;
        }
        
    }
}
