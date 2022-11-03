using System;
using UnityEngine;

public class BubblesRepository
{
    private BubbleBase[][] _repository;
    private BubblesRepositoryConfig _repositoryConfig;
    private BubbleFactory _bubblesFactory;
    private float _sizeBubble;
    private Vector2Int _size;
    private Vector3 _bubblesRepositoryStartCoordinate;

    public BubbleBase[][] Repository => _repository;
    public Vector2Int Size => _size;
    public BubblesRepositoryConfig RepositoryConfig => _repositoryConfig;

    public BubblesRepository(BubblesRepositoryConfig bubblesRepositoryConfig, BubbleFactory bubblesFactory, BubblesSizeConfig bubblesSizeConfig)
    {
        _repositoryConfig = bubblesRepositoryConfig;
        _bubblesFactory = bubblesFactory;
        _sizeBubble = bubblesSizeConfig.Size;
        _size = _repositoryConfig.Size;

        _bubblesRepositoryStartCoordinate = Camera.main.ScreenToWorldPoint(new Vector2(0, Camera.main.pixelHeight));

        _repository = new BubbleBase[_size.x][];
      
        for (int i = 0; i < _size.x; i++)
        {
            _repository[i] = new BubbleBase[_size.y];
        }
    }

    public Vector2 GetWorldCoordinate(Vector2Int position)
    {
        CheckArrayBounds(position.x, position.y);
        int i = position.x;
        int j = position.y;
        
        Vector2 bubbleStartCoordinate = (Vector2)_bubblesRepositoryStartCoordinate;

        if (j%2==0)
            return bubbleStartCoordinate + new Vector2(i * _sizeBubble, -j * _sizeBubble)+ new Vector2(_sizeBubble/2,-_sizeBubble/2);
        else
            return bubbleStartCoordinate + new Vector2(i * _sizeBubble, -j * _sizeBubble) + new Vector2(_sizeBubble, -_sizeBubble / 2);   
    }

    public Vector2Int GetRepositioryCoordinate(Vector3 position)
    {
        Vector2 MaxCordinate = new Vector2(MathF.Max(_bubblesRepositoryStartCoordinate.x, position.x), MathF.Max(_bubblesRepositoryStartCoordinate.y, position.y));
        Vector2 MinCordinate = new Vector2(MathF.Min(_bubblesRepositoryStartCoordinate.x, position.x), MathF.Min(_bubblesRepositoryStartCoordinate.y, position.y));

        Vector2 distance = MaxCordinate - MinCordinate;

        int j = Mathf.RoundToInt((distance.y + _sizeBubble / 2)/_sizeBubble)-1;
        int i = 0;
        if (j % 2 == 0)
            i = Mathf.RoundToInt((distance.x - _sizeBubble / 2) / _sizeBubble);
        else
            i = Mathf.RoundToInt((distance.x - _sizeBubble) / _sizeBubble);

        return new Vector2Int(i,j);
    }
   
    public void AddBubble<TBubble>(BubbleType bubbleType, BubbleSkinID bubbleSkin, Vector2Int position) where TBubble:BubbleBase
    {
        CheckArrayBounds(position.x, position.y);
        int i = position.x;
        int j = position.y;
     
        if (_repository[i][j] == null)
            _repository[i][j] = _bubblesFactory.Create<TBubble>(bubbleType,bubbleSkin,GetWorldCoordinate(position));
    }

    public void CheckArrayBounds(int i, int j)
    {   
        if ((i < 0 || j < 0) || ((j % 2 == 0) && (i >= _size.x || j >= _size.y)) || ((j % 2 != 0) && (i >= (_size.x) || j >= _size.y)))
            throw new Exception("Array index out of bounds");
    }
}
