using UnityEngine;
using System.Collections.Generic;

public class SpellUIManager : MonoBehaviour
{
    [SerializeField] private List<SpellSlot> slots = new List<SpellSlot>();


    public void ShowSpells(List<SpellSO> spells)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < spells.Count)
            {
                slots[i].SetSpell(spells[i]);
            }
            else
            {
                slots[i].SetSpell(null);
            }
        }
    }

    public void HighlightSpell(SpellSO avtiveSpell)
    {
        foreach (SpellSlot slot in slots)
        {
            slot.SetHighlight(slot.AssignedSpell == avtiveSpell);
        }
    }
}
