using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using OnlineDiary.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineDiary.Models
{
    public class MyDiary
    {
        [Key]
        public int MyDiaryId { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        [Required(ErrorMessage = "Write a title..")]
        public string Title { get; set; }

        [DisplayName("Date")]
        [Required(ErrorMessage = "Choose a date..")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayName("Content")]
        [Column(TypeName = "nvarchar(max)")]
        [Required(ErrorMessage = "Write something..")]
        public string Entry { get; set; }

        public virtual OnlineDiaryUser? User { get; set; }

    }
}
