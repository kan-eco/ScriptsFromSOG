using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour
{


    public float distToLook = 40;
    public float sphereRadius = 5;


    Quaternion[] rP;
    Quaternion rotation1;
    Quaternion rotation2;
    Quaternion rotation3;
    Quaternion rotation4;
    Quaternion rotation5;
    Quaternion rotation6;
    Quaternion rotation7;

    Ray[] rayPool;
    Ray ray1;
    Ray ray2;
    Ray ray3;
    Ray ray4;
    Ray ray5;
    Ray ray6;
    Ray ray7;

    int me;


    private void Start()
    {
        int j;

        rayPool = new Ray[7];
        rayPool[0] = ray1;
        rayPool[1] = ray2;
        rayPool[2] = ray3;
        rayPool[3] = ray4;
        rayPool[4] = ray5;
        rayPool[5] = ray6;
        rayPool[6] = ray7;

        rP = new Quaternion[7];
        rP[0] = rotation1;
        rP[1] = rotation2;
        rP[2] = rotation3;
        rP[3] = rotation4;
        rP[4] = rotation5;
        rP[5] = rotation6;
        rP[6] = rotation7;

        for (int i = 0; i < rP.Length; i++)
        {
            j = -60 + i*20 ;
            rP[i] = Quaternion.AngleAxis(j, gameObject.transform.up);
            
        }

        Huya();

    }
    
    private void FixedUpdate()
    {
        for (int i = 0; i < rayPool.Length; i++)
        {
            rayPool[i] = new Ray(gameObject.transform.position, rP[i] * gameObject.transform.forward * distToLook);
            Debug.DrawRay(gameObject.transform.position, rP[i] * gameObject.transform.forward * distToLook, Color.green);
        }

        for (int i = 0; i < 7; i++)
        {

            if (Physics.SphereCast(rayPool[i], 0.75f, out RaycastHit hit, distToLook))
            {
                GameObject hitObject = hit.transform.gameObject;
                
                if (hitObject.CompareTag("Enemy") && me == 0)
                {
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, (hit.transform.position - transform.position), 1, 0f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }

                if (hitObject.CompareTag("Ally") && me == 1)
                {
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, (hit.transform.position - transform.position), 1, 0f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }
                
                if (hitObject.CompareTag("PlGreen") && me == 1)
                {
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, (hit.transform.position - transform.position), 1, 0f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }

                if (hitObject.CompareTag("PlRed") && me == 0)
                {
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, (hit.transform.position - transform.position), 1, 0f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }

                if (hitObject.CompareTag("Player") && me == 1)
                {
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, (hit.transform.position - transform.position), 1, 0f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }
            }
        }

        transform.rotation = Quaternion.LookRotation(transform.forward);
    }


    public void Huya()
    {
        if (this.gameObject.CompareTag("Enemy")) me = 1;
        if (this.gameObject.CompareTag("Ally")) me = 0;
    }
}


