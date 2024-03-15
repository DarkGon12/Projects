using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleRow : MonoBehaviour
{
    public EquationBuilder EquationBuild { get; private set; }
    public bool IsSolved;   

    [Header("Стрелки")]
    [SerializeField] private List<Sprite> _standardArrowSprites;
    [SerializeField] private List<Sprite> _greenArrowSprites;
    
    private List<SpriteRenderer> _spriteRenderers;

    private SpriteRenderer _arrowSpriteRenderer;
    private GroupPuzzle _puzzleGroup;
    private TextMeshProUGUI _rowNumberText;
    private NextLevel _nextLevel;

    private ResultCalculator _resultCalculator;
    private SpriteManager _spriteManager;

    private int _answer;

    private void Start()
    {
        HasSprites();
        InitializeSpriteList();
        Initialize();
    }

    private void HasSprites()
    {
        _spriteRenderers = new List<SpriteRenderer>();

        foreach (Transform child in transform)
        {
            var renderer = child.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                _spriteRenderers.Add(renderer);
            }
        }
    }

    private void InitializeSpriteList() =>
        _spriteManager = new SpriteManager("Sprites/PuzzleRow", 10);
    
    public void Initialize()
    {
        EquationBuild = new EquationBuilder(transform);
        _resultCalculator = new ResultCalculator();

        _puzzleGroup = transform.GetComponentInParent<GroupPuzzle>();
        _rowNumberText = GetComponentInChildren<TextMeshProUGUI>();
        _answer = int.Parse(_rowNumberText.text);
        _nextLevel = transform.parent.GetComponent<NextLevel>();

        _arrowSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        EquationBuild.BuildEquation();
    }

    public void CalculateResult()
    {
        if (_resultCalculator.CalculateResult(EquationBuild.Equation, _answer))
        {
            IsSolved = true;

            if (transform.parent.GetComponent<GroupPuzzle>())
            {
                for (int d = 0; d < _puzzleGroup.IsSolvedPuzzle.Count; d++)
                {
                    if (!_puzzleGroup.IsSolvedPuzzle[d])
                    {
                        _puzzleGroup.IsSolvedPuzzle[d] = true;

                        if (d == _puzzleGroup.IsSolvedPuzzle.Count - 1)
                            _nextLevel.Next();
                        else
                            break;
                    }
                }
            }
            else
            {
                _nextLevel.Next();
            }

            ChangeColorToSolved();
        }
    }

    private void ChangeArrowSprite()
    {
        for (int s = 0; s < _greenArrowSprites.Count; s++)
        {
            if (_arrowSpriteRenderer.transform.name == _greenArrowSprites[s].name)
                _arrowSpriteRenderer.sprite = _standardArrowSprites[s];
        }
    }

    private void ChangeSprite(SpriteRenderer renderer, List<Sprite> primarySprites, List<Sprite> secondarySprites)
    {
        Sprite currentSprite = renderer.sprite;
        Sprite newSprite = primarySprites.Find(s => s.name == currentSprite.name) ?? secondarySprites.Find(s => s.name == currentSprite.name);

        if (newSprite != null && newSprite != currentSprite)
        {
            renderer.sprite = newSprite;
        }
    }

    private void ChangeColorToSolved()
    {
        ChangeArrowSprite();

        foreach (var spriteRenderer in _spriteRenderers)
        {
            ChangeSprite(spriteRenderer, _spriteManager.SovedCell, _spriteManager.SolvedSpiderCell);
        }
    }

    private void ChangeColorToStandard()
    {
        ChangeArrowSprite();

        foreach (var spriteRenderer in _spriteRenderers)
        {
            ChangeSprite(spriteRenderer, _spriteManager.StandardCell, _spriteManager.SpiderCell);
        }
    }

    public void Restart()
    {
        if (IsSolved == true)
        {
            ChangeColorToStandard();
            IsSolved = false;
        }
    }
}