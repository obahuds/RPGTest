using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    PokemonBase baseDetails;
    int level;

    public Pokemon(PokemonBase baseDetails, int level) {
        this.baseDetails = baseDetails;
        this.level = level;
        Hp = baseDetails.MaxHp;

        Moves = new List<Move>();
        foreach (LearnableMove move in baseDetails.LearnableMoves) {
            if (move.Level <= level) {
                Moves.Add(new Move(move.MoveBase));
            }
        }
    }

    public int Attach {
        get { return Mathf.FloorToInt((baseDetails.Attack * level) / 100f) + 5; }
    }

    public int Defense {
        get { return Mathf.FloorToInt((baseDetails.Defense * level) / 100f) + 5; }
    }

    public int SpAttack {
        get { return Mathf.FloorToInt((baseDetails.SpAttack * level) / 100f) + 5; }
    }

    public int SpDefense {
        get { return Mathf.FloorToInt((baseDetails.SpDefence * level) / 100f) + 5; }
    }

    public int Speed {
        get { return Mathf.FloorToInt((baseDetails.Speed * level) / 100f) +5; }
    }

    public int MaxHp {
        get { return Mathf.FloorToInt((baseDetails.MaxHp * level) / 100f) + 10; }
    }

    public int Hp {get; set; }

    public List<Move> Moves { get; }
}
