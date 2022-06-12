using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BonusGenerator : MonoBehaviour
{
    [SerializeField] private GameState _gameState;
    private readonly List<BonusAttach> _levelBonuses = new List<BonusAttach>();
    private readonly LevelIndex _levelIndex = new LevelIndex();

    public void Generate()
    {
        _levelBonuses.Clear();
        GameLevel gameLevel = Resources.Load<GameLevel>($"Levels/Level{_levelIndex.GetIndex() + 1}");
        if (gameLevel != null)
        {
            foreach (var item in gameLevel.Bonuses)
            {
                BonusAttach bonusAttach = Instantiate(item, transform);
                bonusAttach.transform.position = transform.position;
                _levelBonuses.Add(bonusAttach);
            }
        }
    }

    private void CheckBonus(Vector2 position)
    {
        if (_gameState.State == State.Gameplay)
        {
            if (_levelBonuses.Count > 0)
            {
                var randomInt = Random.Range(0, 101);
                foreach (var bonus in _levelBonuses.OrderBy(x => Random.Range(0, _levelBonuses.Count)))
                {
                    int bonusChance = bonus.GetComponent<Bonus>().Chance;
                    if (randomInt <= bonusChance)
                    {
                        bonus.transform.SetParent(null);
                        bonus.transform.position = position;
                        bonus.SetEnableMoveAndVisual(true);
                        _levelBonuses.Remove(bonus);
                        break;
                    }
                }
            }
        }
    }

    private void OnEnable()
    {
        Block.OnDestroyedPosition += CheckBonus;
    }

    private void OnDisable()
    {
        Block.OnDestroyedPosition -= CheckBonus;
    }
}
