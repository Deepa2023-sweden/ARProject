using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public GameObject furniture; // Selected furniture object
    [SerializeField] private ButtonManager buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<Item> items = new List<Item>(); // Initialize the list

    private int current_id = 0;

    private static DataHandler instance;
    public static DataHandler Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DataHandler>();
            }
            return instance;
        }
    }

    void Start()
    {
        LoadItems();
        CreateButtons();
    }

    void LoadItems()
    {
        // Correctly load items from resources and cast them to the Item type
        Object[] items_obj = Resources.LoadAll("Items", typeof(Item));
        foreach (var obj in items_obj)
        {
            items.Add((Item)obj); // Cast and add to the list
        }
    }

    void CreateButtons()
    {
        foreach (Item item in items)
        {
            ButtonManager button = Instantiate(buttonPrefab, buttonContainer.transform);
            button.Itemid = current_id;
            button.ButtonTexture = item.itemImage;
            current_id++;
        }
    }

    public void SetFurniture(int id)
    {
        if (id >= 0 && id < items.Count) // Validate id
        {
            furniture = items[id].itemPrefab;
        }
        else
        {
            Debug.LogWarning("Invalid item ID.");
        }
    }

    public GameObject GetFurniture()
    {
        return furniture;
    }
}
