using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_website_dbfirst.Data;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Web;


namespace Movie_website_dbfirst.Models
{
    public class MovieVM
    {

        public Guid Id { get; set; }

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

        public IFormFile image { get; set; }

        public IFormFile vidoe { get; set; }

        public List<Guid> Actors { get; set; }
        public List<Guid> Producers { get; set; }
        public List<Guid> Directors { get; set; }
        public List<Guid> Genres { get; set; }
        public Guid Episodes { get; set; }
        //public List<Movie>? Movies { get; set; }

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
