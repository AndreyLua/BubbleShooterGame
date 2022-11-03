using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BubbleRepositoryUpdater : CycleInitializerBase
{
    [SerializeField] private BubbleRepositoryInserter _bubbleRepositoryInserter;
    [Inject]
    private BubblesRepository _bubblesRepository;

    public override void OnInit()
    {
        _bubbleRepositoryInserter.NewBubbleInRepository += BubbleRepositoryUpdate;
    }

    private void BubbleRepositoryUpdate(BubbleBase newBubble)
    {
        HashSet<BubbleBase> bubblesNeighborsOneType = new HashSet<BubbleBase>();
        SetBubblesNeighborsOneType(newBubble, bubblesNeighborsOneType);

        if (bubblesNeighborsOneType.Count>=3)
        {
            foreach (BubbleMove bubble in bubblesNeighborsOneType)
                Destroy(bubble.gameObject);
        }
        else
        {
            _bubblesRepository.AddBubble<CommonBubble>(newBubble.Type, newBubble.SkinID, _bubblesRepository.GetRepositioryCoordinate(newBubble.transform.position));
            Destroy(newBubble.gameObject);
        }
    }

    private void SetBubblesNeighborsOneType(BubbleBase bubble, HashSet<BubbleBase> bubblesNeighborsOneType)
    {
        Vector2Int bubbleRepositioryCoordinate = _bubblesRepository.GetRepositioryCoordinate(bubble.transform.position);
   
        if (bubblesNeighborsOneType.Contains(bubble))
            return;
    
        bubblesNeighborsOneType.Add(bubble);

        BubbleBase bubbleNeighbor = GetBubbleNeighbor(1, -1, bubbleRepositioryCoordinate);
        if (BubbleTypesIsIdentical(bubbleNeighbor, bubble))
            SetBubblesNeighborsOneType(bubbleNeighbor, bubblesNeighborsOneType);

        bubbleNeighbor = GetBubbleNeighbor(1, 1, bubbleRepositioryCoordinate);
        if (BubbleTypesIsIdentical(bubbleNeighbor, bubble))
            SetBubblesNeighborsOneType(bubbleNeighbor, bubblesNeighborsOneType);

        bubbleNeighbor = GetBubbleNeighbor(1, 0, bubbleRepositioryCoordinate);
        if (BubbleTypesIsIdentical(bubbleNeighbor, bubble))
            SetBubblesNeighborsOneType(bubbleNeighbor, bubblesNeighborsOneType);

        bubbleNeighbor = GetBubbleNeighbor(1, -1, bubbleRepositioryCoordinate);
        if (BubbleTypesIsIdentical(bubbleNeighbor, bubble))
            SetBubblesNeighborsOneType(bubbleNeighbor, bubblesNeighborsOneType);

        bubbleNeighbor = GetBubbleNeighbor(-1, -1, bubbleRepositioryCoordinate);
        if (BubbleTypesIsIdentical(bubbleNeighbor, bubble))
            SetBubblesNeighborsOneType(bubbleNeighbor, bubblesNeighborsOneType);

        bubbleNeighbor = GetBubbleNeighbor(-1, 0, bubbleRepositioryCoordinate);
        if (BubbleTypesIsIdentical(bubbleNeighbor, bubble))
            SetBubblesNeighborsOneType(bubbleNeighbor, bubblesNeighborsOneType);
        
           
        bubbleNeighbor = GetBubbleNeighbor(-1, 1, bubbleRepositioryCoordinate);
        if (BubbleTypesIsIdentical(bubbleNeighbor, bubble))
            SetBubblesNeighborsOneType(bubbleNeighbor, bubblesNeighborsOneType);

        return;
    }

    private bool BubbleTypesIsIdentical(BubbleBase firstBubble, BubbleBase secondBubble)
    {
        if (firstBubble == null || secondBubble == null)
            return false;
        return firstBubble.SkinID == secondBubble.SkinID;
    }

    private BubbleBase GetBubbleNeighbor(int x, int y, Vector2Int bubbleRepositoryCoordinate)
    {
        Vector2Int neighborRepositoryCoordinate;

        if (y == 0)
        {
            neighborRepositoryCoordinate = new Vector2Int(bubbleRepositoryCoordinate.x + x, bubbleRepositoryCoordinate.y);
        }
        else
        {
            if (bubbleRepositoryCoordinate.y % 2 == 0)
                if (x > 0)
                    neighborRepositoryCoordinate = new Vector2Int(bubbleRepositoryCoordinate.x, bubbleRepositoryCoordinate.y + y);
                else
                    neighborRepositoryCoordinate = new Vector2Int(bubbleRepositoryCoordinate.x + x, bubbleRepositoryCoordinate.y + y);
            else
                if (x > 0)
                neighborRepositoryCoordinate = new Vector2Int(bubbleRepositoryCoordinate.x + x, bubbleRepositoryCoordinate.y + y);
            else
                neighborRepositoryCoordinate = new Vector2Int(bubbleRepositoryCoordinate.x, bubbleRepositoryCoordinate.y + y);
        }

        try
        {
            _bubblesRepository.CheckArrayBounds(neighborRepositoryCoordinate.x,neighborRepositoryCoordinate.y);
        }
        catch
        {
            return null;
        }
        return _bubblesRepository.Repository[neighborRepositoryCoordinate.x][neighborRepositoryCoordinate.y];
    }
}
