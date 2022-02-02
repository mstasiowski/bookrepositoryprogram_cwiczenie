using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bookrepositoryprogram.Models
{
    public class book
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Musisz podać tytuł książki!")]
        [MinLength(3,ErrorMessage ="Tytuł nie może być krótszy niż 3 znaki")]
        [Display(Name = "Tytuł książki")]
        [MaxLength(50, ErrorMessage = "Tytuł nie może być dłuższa niż 50 znaków")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Musisz podać autora!")]
        public string Author { get; set; }

        
        [Range(minimum: 1800, maximum: 2022, ErrorMessage = "Rok wydania musi być między 1800 a 2022!")]
        public int PublishingYear { get; set; }

        [Required(ErrorMessage = "Musisz podać cene książki!")]
        [Range(minimum: 0, maximum: 9999, ErrorMessage = "Cena nie może być ujemna ani większa niż 9999!")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
    }
}
