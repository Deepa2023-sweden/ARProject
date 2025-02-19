using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CategoryData", menuName = "ScriptableObjects/CategoryData")]
public class NewScriptableObjectScript : ScriptableObject
{
    public List<string> categories = new List<string>(); // Stores category names

    [System.Serializable]
    public class CategoryColorPair
    {
        public string categoryName;  // e.g., "Sofa", "Bed"
        public List<string> colors = new List<string>(); // e.g., ["Red", "Blue"]
    }

    public List<CategoryColorPair> categoryColorPairs = new List<CategoryColorPair>(); // Replaces Dictionary
}
