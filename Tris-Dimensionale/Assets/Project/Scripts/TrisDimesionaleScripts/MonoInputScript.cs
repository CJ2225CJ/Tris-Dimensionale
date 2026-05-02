using UnityEngine;

public class MonoInputSctipt : MonoBehaviour
{
    private bool monoTrigget = false;
    [SerializeField] private TrisPositioningAndLogic TPaL;
    [SerializeField] private Slot3D []slot3D;
    [SerializeField] private UITD UITD;
    void Update()
    {
        MonoInput();        
    }
    public void MonoInput() // remember to chaing TPaL 
    {
        UITD.OnFloreChainge(slot3D);
        if (Input.anyKeyDown)
        {
            monoTrigget = false;
            TPaL.Positioning(slot3D);
            UITD.OnFloreChainge(slot3D);
            UITD.KeyBindFlorUpDown();
        }

        if (!Input.anyKey)
        {
            monoTrigget = true;
        }
    }
}
