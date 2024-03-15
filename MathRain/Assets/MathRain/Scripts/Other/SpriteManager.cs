using System.Collections.Generic;
using UnityEngine;

public class SpriteManager
{
    public List<Sprite> StandardCell { get; private set; } = new List<Sprite>();
    public List<Sprite> SovedCell { get; private set; } = new List<Sprite>();

    public List<Sprite> SpiderCell { get; private set; } = new List<Sprite>();
    public List<Sprite> SolvedSpiderCell { get; private set; } = new List<Sprite>();

    public SpriteManager(string basePath, int count)
    {
        LoadSprites(basePath, count);
    }

    private void LoadSprites(string basePath, int count)
    {
        for (int i = 0; i < count; i++)
        {
            StandardCell.Add(Resources.Load<Sprite>($"{basePath}/StandartCell/{i}"));
            SovedCell.Add(Resources.Load<Sprite>($"{basePath}/GreenCell/{i}"));

            SpiderCell.Add(Resources.Load<Sprite>($"{basePath}/SpiderStandartCell/{i}Ï"));
            SolvedSpiderCell.Add(Resources.Load<Sprite>($"{basePath}/SpiderCell/{i}Ï"));
        }
    }
}