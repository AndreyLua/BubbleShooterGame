using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Bounds
{
    private GameObject _boundGameObject;
    private float _thickness;
    private List<GameObject> _bounds;

    public Bounds(GameObject boundGameObject, float thickness)
    {
        _boundGameObject = boundGameObject;
        _thickness = thickness;
    }

    public void OnInit()
    {
        Camera camera = Camera.main;
        _bounds = new List<GameObject>();
        Vector3 boundPosition = GetWorldCoordinate(Camera.main, camera.pixelWidth / 2, 0);
        GameObject bound = GameObject.Instantiate(_boundGameObject, boundPosition + new Vector3(0, -_thickness / 2, 0), Quaternion.identity);
        bound.transform.localScale = new Vector2(GetCameraZoneSize().x + _thickness * 2, _thickness);
        _bounds.Add(bound);

        Vector2 sizeSideBorders = new Vector2(_thickness, GetCameraZoneSize().y);
        boundPosition = GetWorldCoordinate(Camera.main, 0, camera.pixelHeight / 2);
        bound = GameObject.Instantiate(_boundGameObject, boundPosition - new Vector3(_thickness / 2, 0), Quaternion.identity);
        bound.transform.localScale = sizeSideBorders;
        _bounds.Add(bound);

        boundPosition = GetWorldCoordinate(Camera.main, camera.pixelWidth, camera.pixelHeight / 2);
        bound = GameObject.Instantiate(_boundGameObject, boundPosition + new Vector3(_thickness / 2, 0), Quaternion.identity);
        bound.transform.localScale = sizeSideBorders;
        _bounds.Add(bound);

        boundPosition = GetWorldCoordinate(Camera.main,camera.pixelWidth/2 ,camera.pixelHeight);
        bound = GameObject.Instantiate(_boundGameObject, boundPosition + new Vector3(0,_thickness / 2), Quaternion.identity);
        bound.AddComponent<UpperBound>();
        bound.transform.localScale = new Vector2(GetCameraZoneSize().x + _thickness * 2, _thickness);
        _bounds.Add(bound);
    }

    private Vector2 GetCameraZoneSize()
    {
        return new Vector2(Camera.main.orthographicSize * 2 * Camera.main.aspect, Camera.main.orthographicSize * 2);
    }

    private Vector2 GetWorldCoordinate(Camera camera, float x, float y)
    {
        return camera.ScreenToWorldPoint(new Vector2(x, y));
    }

}
