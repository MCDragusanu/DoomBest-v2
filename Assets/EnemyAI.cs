using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public int hpAmount;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hpAmount< 0)
        {
            Debug.Log("This SHould Be death");
            this.enabled = false;
            this.gameObject.SetActive(false);
            this.transform.Translate(new Vector3(696969 , 696969 , 696969));
        }
    }

   public void TakeDamage(int amount)
    {
        
            hpAmount -= amount;
        
       
            Debug.Log("Dead :(.");
            
        
    }
}
