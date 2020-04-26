using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    private Transform player;
    private Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        cameraTransform.position = new Vector3(player.position.x, player.position.y, cameraTransform.position.z);
    }
}
