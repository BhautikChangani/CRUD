using System;
using System.Collections.Generic;
using System.Text;

namespace Kendo.Mvc.Examples.Models.GridLayout
{
    public class GridLayoutData
    {
        public DateTime SelectedDate { get; set; }
        public List<GridLayoutArticle> Articles { get; set; }
        public List<GridLayoutArticle> RecommendedArticles { get; set; }
        public List<string> Tags { get; set; }
        public string RenderRecomendedArticles()
        {
            var sb = new StringBuilder();

            foreach (var item in RecommendedArticles)
            {
                sb.Append(RecommendedCard(item));
            }
            var content = sb.ToString();
            return content;
        }
        private string RecommendedCard(GridLayoutArticle article)
        {
            var template = $@"<div class='card-article k-d-flex'>
                <div class='card-article-description k-d-flex-col'>
                    <div class='author k-text-inverse'>{article.Author}</div>
                    <div class='title k-text-inverse'>{article.Title}</div>
                    <div class='subtitle k-text-inverse'>{article.SubTitle}</div>
                    <div class='date-container k-d-flex'>
                        <div class='date k-text-inverse'>{article.FormattedDate}</div>
                        <div class='separator'>|</div>
                        <div class='length k-text-inverse'>{article.MinsLength} min read</div>
                    </div>
                </div>
                <div>
                    <img class='card-article-image' src='{article.ImageUrl}' alt='{article.Title}' />
                    <div class='photo-text'>{article.ImageRight}</div>
                </div>
            </div>";
            return template;
        }
    }
}