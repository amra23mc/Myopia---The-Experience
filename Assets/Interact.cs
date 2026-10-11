using UnityEngine;

public class Interact : MonoBehaviour
{
    public Camera fpsCam;
    public float range = 100f;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     Raycast();
        // }
    }

    void Raycast()
    {
        Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward * range, Color.red);
        RaycastHit raycast;
        bool hit = Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out raycast, range); //This basically returns true if it hits something, and false if it doesn't

        if (hit)
        {
            Debug.Log(raycast.transform.name);
            // Change animation state of the element       
        }
    }
    
    
}
