using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "Mission", menuName = "Agency/Mission", order = 51)]
public class Mission : ScriptableObject
{
    [SerializeField]
    private LocalizedString _name = default;

    public LocalizedString Name => _name;
}
