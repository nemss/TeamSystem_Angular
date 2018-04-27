namespace TeamSystem.Service.News.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class NewsModel
    {
        public int Id { get; set; }

        [MinLength(ArticleTitleMinLenght)]
        [MaxLength(ArticleTitleMaxLenght)]
        public string Title { get; set; }

        [MinLength(ArticleContentMinLenght)]
        public string Content { get; set; }

        [MaxLength(ThumbnailMaxLenght)]
        public string ThumbnailUrl { get; set; }

        public DateTime PublishDate { get; set; }
    }
}
