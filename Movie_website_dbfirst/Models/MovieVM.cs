using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_website_dbfirst.Data;
using System.ComponentModel.DataAnnotations;

namespace Movie_website_dbfirst.Models
{
    public class MovieVM
    {

        public int Id { get; set; }
        [Display(Name="Tên phim")]
        public string? NameMovie { get; set; }

        [Display(Name = "Ngày phát hành")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Tiêu đề")]
        public string? Title { get; set; }

        [Display(Name = "Điểm trung bình")]
        public double? AvgRating { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? ImgPath { get; set; }

        [Display(Name = "Phim")]
        public string? MoviePath { get; set; }

        public List<Actor> Actors { get; set; }
        public List<Producer> Producers { get; set; }
        public List<Director> Directors { get; set; }
        public List<Genre> Genres { get; set; }
        public Episode Episodes { get; set; }
        public List<Movie>? Movies { get; set; }

    }

    public class MovieCVM
    {
        public int Id { get; set; }
        [Display(Name = "Tên phim")]
        public string? NameMovie { get; set; }

        [Display(Name = "Ngày phát hành")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Tiêu đề")]
        public string? Title { get; set; }

        [Display(Name = "Điểm trung bình")]
        public double? AvgRating { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? ImgPath { get; set; }

        [Display(Name = "Phim")]
        public string? MoviePath { get; set; }

        public int IdActor  { get; set; }
        public int IdDirect { get; set; }
        public int MyProperty { get; set; }
    }
}
