using CDEUnileverAPI.Models;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.DTO
{
    public class ArticleDTO
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Thumbnail { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(25)]
        public string Title { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Hypertext { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(150)]
        public string ShortDescription { get; set; }
        //public int CreatedById { get; set; }
    }

    public class ShowArticleListDTO
    {
        public int Id { get; set; }
        public string CreatedByName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Title { get; set;}
        public string Status { get; set;}
    }

    public class UpdateArticleDTO
    {
        [System.ComponentModel.DataAnnotations.Required]
        public string Thumbnail { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(25)]
        public string Title { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Hypertext { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(150)]
        public string ShortDescription { get; set; }
        //public int CreatedById { get; set; }
    }

    public class ArticleDetailDTO
    {
        public string Thumbnail { get; set; }
        public string Title { get; set; }
        public string Hypertext { get; set; }
        public string ShortDescription { get; set; }
        public string Status { get; set; }
        public string CreatedByName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
