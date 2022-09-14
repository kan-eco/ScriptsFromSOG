using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trup : MonoBehaviour
{
    MeshRenderer[] oldColors;
    Color oldColor;
    public float colorChangeSpeed = 15;
    float speed;
    public int metka;

    void Start()
    {
        oldColors = GetComponentsInChildren<MeshRenderer>();
        

        foreach (MeshRenderer mesh in oldColors)
        {
            mesh.material.color = GetComponentInChildren<MeshRenderer>().material.color;
            oldColor = mesh.material.color;
        }

        //тут начинается история про отслеживание где какой труп.
        // это означает, что при замене на нормальные модельки надо это не забыть прочекать
        if (oldColor == Color.green)
        {
            metka = 0;
        }

        if (oldColor == Color.red)
        {
            metka = 1;
        }

    }

    void FixedUpdate()
    {

        if (speed <= 70)
        {

            speed += (Time.deltaTime * colorChangeSpeed);
        
            foreach (MeshRenderer mesh in oldColors)
            {
                mesh.material.color = Color.Lerp(oldColor, Color.white, speed * Time.fixedDeltaTime);
            }

            GetComponentInChildren<MeshRenderer>().material.color = Color.white;

        }
    }

}
