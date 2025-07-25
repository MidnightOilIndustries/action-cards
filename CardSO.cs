using UnityEngine;

[CreateAssetMenu(menuName = "Spire Assets/Card SOs")]
public class CardSO : ScriptableObject
{
    public string abilityName;
    public string description;
    public Sprite image;
    //public int manaCost;
    public int animationIndex;
    public int power;
    public int block;
    public int energy;
    public int drawAmount;
    //public int alternateAnimation
}
