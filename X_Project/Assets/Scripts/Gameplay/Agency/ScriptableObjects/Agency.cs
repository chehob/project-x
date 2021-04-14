using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Agency", menuName = "Agency/Agency", order = 51)]
public class Agency : ScriptableObject
{
    [SerializeField]
    private List<Case> _cases = default;

    public List<Case> Cases => _cases;
}
