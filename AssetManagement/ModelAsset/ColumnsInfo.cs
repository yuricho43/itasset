using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.ModelAsset
{
    public class ColumnsInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ColumnName { get; set; }  // 부서, 장비유형, (제조사), 운영체제, 설치장소
        public string Selector { get; set; }    // 기준정보
        public bool bUsed { get; set; }         // 사용여부
        public DateTime DateCreate { get; set; }
    }
}
