using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{
    public Camera _camera;
    public Texture cross;

    public GameObject playerBall;
    private GameObject _ball;

    
    public int reloadTime = 2;
    int _reloadTime;
    

    void Start()
    {
        int _reloadTime = reloadTime;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void FixedUpdate() //просто в апдейте херня получается
    {
        _reloadTime = (int)(_reloadTime - Time.deltaTime);
     
        if (Input.GetMouseButton(0) && _reloadTime <= 0)
        {
            _ball = Instantiate(playerBall, transform.position, transform.rotation) as GameObject;
            _reloadTime = reloadTime;

        }

    }
    
    private void OnGUI()
    {
        int size = 40;
        float posX = _camera.pixelWidth / 2 - 18;
        float posY = _camera.pixelHeight / 2 - 4;
        GUI.Label(new Rect(posX, posY, size, size), cross);
    }

}
