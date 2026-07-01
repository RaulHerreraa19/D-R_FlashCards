using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DR_FlashCards.Models
{
    public class DeckModel
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("id_exam")]
        public int IdExam { get; set; } // Foreign key to ExamModel
        [Column("id_user")]
        public int IdUser { get; set; } // Foreign key to UsersModel

        public IEnumerable<FlashCardModel> FlashCards { get; set; } = Enumerable.Empty<FlashCardModel>();
    }
}
