using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.ModelAsset
{
    public class ChangeHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string AssetId { get; set; }
        public string ChangeReason { get; set; }
        public string ChangeColumns { get; set; }
        public string ChangeDescripton { get; set; }
        public DateTime DateChange { get; set; }
        public string Changer {  get; set; }
    }
}
