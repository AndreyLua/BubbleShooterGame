using UnityEngine;

public class UIScreen : MonoBehaviour
{
    [SerializeField] private CycleState _state;

    [SerializeField] private LevelButton[] _levelButtons;
    [SerializeField] private SwitchStateButton[] _switchStateButtons;
    [SerializeField] private RestartLvlButton _restartLvlButton;
    [SerializeField] private ResumeButton _resumeButton;

    public CycleState State => _state;
    public LevelButton[] LevelButtons =>_levelButtons;
    public SwitchStateButton[] SwitchStateButtons => _switchStateButtons;
    public RestartLvlButton RestartLvlButton =>_restartLvlButton;
    public ResumeButton ResumeButton => _resumeButton;
}
