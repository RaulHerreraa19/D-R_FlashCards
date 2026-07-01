using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DR_FlashCards.Models
{
    public class ExamModel
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Column("subject")]
        public string Subject { get; set; } = string.Empty;
        [Column("exam_date")]
        public DateTime ExamDate { get; set; } = DateTime.Now;
        [Column("user_id")]
        public int UserId { get; set; }

        //Enumerable relationship with DeckModel
        public IEnumerable<DeckModel> Decks { get; set; } = Enumerable.Empty<DeckModel>();

    }
}
