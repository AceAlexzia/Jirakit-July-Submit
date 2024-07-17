using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class CardLayout : LayoutGroup
{
    [SerializeField]
    private int row;
    [SerializeField]
    private int col;
    [SerializeField]
    private Vector2 cardSize;
    [SerializeField]
    private Vector2 spacing;
    [SerializeField]
    private int topPaddingOffset;

    public override void CalculateLayoutInputVertical() 
    {
        if (row == 0 || col == 0)
        {
            row = 2;
            col = 2;
        }

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cardHeight = (parentHeight - 2 * topPaddingOffset - spacing.y * (row - 1))/ row;
        float cardWidth = cardHeight;

        if (cardWidth * col + spacing.x * (col - 1) > parentWidth)
        {
            cardWidth = (parentWidth - 2 * topPaddingOffset - (col - 1) * spacing.x) / col;
            cardHeight = cardWidth;
        }

        cardSize = new Vector2(cardWidth, cardHeight);

        padding.left = Mathf.FloorToInt((parentWidth - col * cardWidth - spacing.x * (col - 1)) / 2) + 50;
        padding.top = Mathf.FloorToInt((parentHeight - row * cardHeight - spacing.y * (row -1)) / 2);
        padding.bottom = padding.top;

        for (int i = 0; i < rectChildren.Count; i++)
        {
            int rowCount = i / col;
            int colCount = i % col;

            var item = rectChildren[i];

            var xPos = padding.left + cardSize.x * colCount + spacing.x *(colCount - 1);
            var yPos = padding.top + cardSize.y * rowCount + spacing.y * rowCount;

            SetChildAlongAxis(item, 0, xPos, cardSize.x);
            SetChildAlongAxis(item, 1, yPos, cardSize.y);


        }
    }
    public override void SetLayoutHorizontal()
    {
        return;
    }
    public override void SetLayoutVertical()
    {
        return;
    }
}
