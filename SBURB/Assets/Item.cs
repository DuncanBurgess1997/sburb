public class Item
{
    public string itemName;
    public int attack, itemType; // Types: 1-3: Tier weapons
    public int[] attBonuses = new int[6];
    public int numberOfGrists;
    public int[] gristCost = new int[5];
    public Grist[] grist = new Grist[5];
    public StrifeKind strifeKind;
    public Trait trait1, trait2, trait3;
    public string component1Name, component2Name;
    public bool andOperator;

    public Item(string name, StrifeKind kind, int atk, Trait newTrait1, Trait newTrait2, Trait newTrait3, int[] bonusAtts)
    {
        itemName = name;
        strifeKind = kind;
        attack = atk;
        trait1 = newTrait1;
        trait2 = newTrait2;
        trait3 = newTrait3;

        for (int i = 0; i < 6; i++)
        {
            attBonuses[i] = bonusAtts[i];
        }
    }
}