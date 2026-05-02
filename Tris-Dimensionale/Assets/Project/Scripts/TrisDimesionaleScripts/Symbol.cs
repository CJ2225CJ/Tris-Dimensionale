using UnityEngine;

public class Symbol : MonoBehaviour
{
    public enum Type {O, X, empty}
    [SerializeField] private Type _type;
    public Type type => _type;
}
