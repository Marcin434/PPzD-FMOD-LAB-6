using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using Debug = UnityEngine.Debug;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class MapAudioController : MonoBehaviour
{
    [SerializeField, EventRef] private string ambienceEvent;
    [SerializeField, EventRef] private string mainSnapshot;
    [SerializeField, EventRef] private string insideSnapshot;
    [Space]
    [SerializeField, EventRef] private string generatorsEvent;
    [SerializeField] private Transform generatorsPosition;
    [SerializeField, EventRef] private string computersEvent;
    [SerializeField] private Transform computersPosition;
    [Space]
    [SerializeField, EventRef] private string doorsEvent;
    [SerializeField] private Transform doors;

    private EventInstance _ambienceEventInstance;
    
    private EventInstance _generatorsEventInstance;
    private EventInstance _computersEventInstance;
    
    private EventInstance _mainSnapshotInstance;
    private EventInstance _insideSnapshotInstance;

    private void Start()
    {
        _ambienceEventInstance = RuntimeManager.CreateInstance(ambienceEvent);

        _generatorsEventInstance = RuntimeManager.CreateInstance(generatorsEvent);
        _generatorsEventInstance.set3DAttributes(generatorsPosition.position.To3DAttributes());
        
        _computersEventInstance = RuntimeManager.CreateInstance(computersEvent);
        _computersEventInstance.set3DAttributes(computersPosition.position.To3DAttributes());
        
        _mainSnapshotInstance = RuntimeManager.CreateInstance(mainSnapshot);
        _insideSnapshotInstance = RuntimeManager.CreateInstance(insideSnapshot);

        _mainSnapshotInstance.start();
        _ambienceEventInstance.start();

    }

    public void PlayDoorsSound()
    {
        RuntimeManager.PlayOneShot(doorsEvent, doors.position);
    }

    public void PlayInsideSnapshot()
    {
        _insideSnapshotInstance.start();
    }
    
    public void StopInsideSnapshot()
    {
        _insideSnapshotInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }

    public void PlaygeneratorsEvent()
    {
        _generatorsEventInstance.start();
    }

    public void StopgeneratorsEvent()
    {
        _generatorsEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }
    
    public void PlaycomputersEvent()
    {
        _computersEventInstance.start();
    }

    public void StopcomputersEvent()
    {

        _computersEventInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
