using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : CycleInitializerBase
{
    [SerializeField] private GameObject _boundGameObject;
    [SerializeField] private float _boundsThickness;
    private Bounds _bounds;
    public Bounds Bounds => _bounds;

    public override void OnInit()
    {
        _bounds = new Bounds(_boundGameObject,_boundsThickness);
        _bounds.OnInit();
    }
}
