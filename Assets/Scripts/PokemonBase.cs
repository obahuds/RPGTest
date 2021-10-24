using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new pokemon")]
public class PokemonBase : ScriptableObject
{
    [SerializeField] string displayName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite, backSprite;

    [SerializeField] PokemonType type1, type2;

    [SerializeField] int maxHp, attack, defense, spAttack, spDefence, speed;

    [SerializeField] List<LearnableMove> learnableMoves;

    public string DisplayName { get => displayName; }
    public string Description { get => description; }
    public Sprite FrontSprite { get => frontSprite; }
    public Sprite BackSprite { get => backSprite; }
    public PokemonType Type1 { get => type1; }
    public PokemonType Type2 { get => type2; }
    public int MaxHp { get => maxHp; }
    public int Attack { get => attack; }
    public int Defense { get => defense; }
    public int SpAttack { get => spAttack; }
    public int SpDefence { get => spDefence; }
    public int Speed { get => speed; }

    public List<LearnableMove> LearnableMoves { get => learnableMoves; }
}

public enum PokemonType
{
    NONE,
    NORMAL,
    FIRE,
    WATER,
    ELECTRIC,
    GRASS,
    ICE,
    FIGHTING,
    POISON,
    GROUND,
    PSYCHIC,
    BUG,
    ROCK,
    GHOST,
    DRAGON
}

[System.Serializable]
public class LearnableMove {
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase MoveBase { get => moveBase; }

    public int Level { get => level; }
}
