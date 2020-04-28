using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;

    public Tilemap theMap;
    public Vector3 bottomLeftCoords;
    public Vector3 topRightCoords;

    private Transform player;
    private Transform cameraTransform;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        player = FindObjectOfType<PlayerController>().transform;
        cameraTransform = Camera.main.transform;

        SetMapBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        // Camera to follow player.
        cameraTransform.position = new Vector3(player.position.x, player.position.y, cameraTransform.position.z);
        
        // Keep camera inside the bounds of the map.
        float maxX = Mathf.Clamp(cameraTransform.position.x, bottomLeftLimit.x, topRightLimit.x);
        float maxY = Mathf.Clamp(cameraTransform.position.y, bottomLeftLimit.y, topRightLimit.y);
        float maxZ = cameraTransform.position.z;
        cameraTransform.position = new Vector3(maxX, maxY, maxZ);
    }

    private void SetMapBoundaries() {
        bottomLeftCoords = theMap.localBounds.min;
        topRightCoords = theMap.localBounds.max;

        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;
        bottomLeftLimit = bottomLeftCoords + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = topRightCoords + new Vector3(-halfWidth, -halfHeight, 0f);

        Debug.Log(bottomLeftCoords);
        Debug.Log(bottomLeftLimit);
    }
}
