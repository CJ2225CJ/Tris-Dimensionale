using UnityEngine;

public class Slot3D : MonoBehaviour
{
    public Symbol curentSymbol;
    public void InstantiateSymbol(Symbol preFab)
    {
        curentSymbol = Instantiate(preFab, transform);
    }
    
    public Symbol.Type GetSymbolType()
    {
        if ( curentSymbol == null)
        {
            return Symbol.Type.empty;
        }
        return curentSymbol.type;
    }
}
