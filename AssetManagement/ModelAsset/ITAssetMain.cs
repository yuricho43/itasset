using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AssetManagement.ModelAsset
{
    public class ITAssetMain
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //--- Excel Columns
        public string Uuid { get; set; }        // 고유식별번호: 자동 채번 (FST-0001 ~ ZZZZ)
        public string AssetNo { get; set; }
        public string? User { get; set; }
        public string? MonitorNo { get; set; }
        public string? MonitorInch { get; set; }
        public int? MonitorNum { get; set; }
        public string? Department { get; set; }
        public string DeviceType { get; set; }
        public string? DeviceMaker { get; set; }
        public string? DeviceModel { get; set; }
        public string? CpuType { get; set; }
        public string? RamType { get; set; }
        public string? StorageType { get; set; }
        public string? VgaType { get; set; }
        public string? WMacAddr { get; set; }
        public string? DeviceSerial { get; set; }
        public string? OsType { get; set; }
        public string? DatePurchase { get; set; }
        public string? InstallPlace { get; set; }
        public string? IpAddr { get; set; }
        public string? MacAddr { get; set; }
        public string? Etc { get; set; }

        //--- Custom
        public string CurrentStatus { get; set; }
        public string Creator { get; set; }
        public string Updator { get; set; }

        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }

    }


}
