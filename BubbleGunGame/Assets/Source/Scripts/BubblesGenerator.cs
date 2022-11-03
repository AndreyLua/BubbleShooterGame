using UnityEngine;
using Zenject;

public class BubblesGenerator : CycleInitializerBase
{
    [Inject]
    private BubblesRepository _bubblesRepository;
    [Inject]
    private BubblesRepositoryConfig _bubblesRepositoryConfig;

    public override void OnInit()
    {
        ReloadLvl();
    }

    public void ReloadLvl()
    {
        for (int i = 0; i < _bubblesRepositoryConfig.Size.x; i++)
        {
            for (int j = 0; j < _bubblesRepositoryConfig.Size.y; j++)
            {
                _bubblesRepository.CheckArrayBounds(i, j);
                if (_bubblesRepository.Repository[i][j] != null)
                {
                    Destroy(_bubblesRepository.Repository[i][j].gameObject);
                    _bubblesRepository.Repository[i][j] = null;
                }
            }
        }

        for (int j = 0; j < 5; j++)
        {
            int lengthLine = _bubblesRepository.RepositoryConfig.Size.x;
            if (j % 2 == 1)
                lengthLine = lengthLine - 1;
            for (int i = 0; i < lengthLine; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        _bubblesRepository.AddBubble<CommonBubble>(BubbleType.Common, BubbleSkinID.GreenCommon, new Vector2Int(i, j));
                        break;
                    case 1:
                        _bubblesRepository.AddBubble<CommonBubble>(BubbleType.Common, BubbleSkinID.RedCommon, new Vector2Int(i, j));
                        break;
                    case 2:
                        _bubblesRepository.AddBubble<CommonBubble>(BubbleType.Common, BubbleSkinID.BlueCommon, new Vector2Int(i, j));
                        break;
                    case 3:
                        _bubblesRepository.AddBubble<CommonBubble>(BubbleType.Common, BubbleSkinID.YellowCommon, new Vector2Int(i, j));
                        break;

                }
            }
        }
    }
       
}
