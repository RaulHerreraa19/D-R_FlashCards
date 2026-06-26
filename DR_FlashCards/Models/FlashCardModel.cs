using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DR_FlashCards.Models
{
    public class FlashCardModel
    {
        [Required]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("question")]
        public string Question { get; set; }
        [Required]
        [Column("answer")]
        public string Answer { get; set; }
        [Required]
        [Column("mazo_id")]
        public int MazoId { get; set; }
    }

}
