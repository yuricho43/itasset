using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.ModelAsset
{
    public class ColumnsInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ColumnName { get; set; }  
        public string Selector { get; set; }    // 기준정보
        public DateTime DateCreate { get; set; }
    }
}
