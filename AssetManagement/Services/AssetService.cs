using AssetManagement.ModelAsset;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Telerik.Documents.Primitives;

namespace AssetManagement.Services
{
    public class AssetService
    {
        private readonly AssetDbContext _dbContextAsset;
        private static int isNumAdded = 0;
        private static int isNumUpdated = 0;
        private static int isNumDeleted = 0;
        public AssetService(AssetDbContext dbContextAsset) 
        {
            _dbContextAsset = dbContextAsset;
        }

        //--- Insert int AssetMain
        public async Task<int> InsertIntoAssetTable(string[] values, string usernm)
        {
            int iRet = 2;   // 1:Added, 2:Updated

            
            // 1. 기존 Db에 동일한 Uuid가 있는지 체크한다.      
            List<ITAssetMain> lstAsset = _dbContextAsset.iTAssetMains.Where(x => x.Uuid == values[1]).ToList();

            // 1.1 없으면 단순하게 추가
            if (lstAsset == null || lstAsset.Count == 0)
            {
                ITAssetMain iAsset = new ITAssetMain();
                SetAssetValueWithArray(ref iAsset, values, usernm);
                iAsset.Version = 1;

                _dbContextAsset.iTAssetMains.Add(iAsset);
                int iSaved = await _dbContextAsset.SaveChangesAsync();
                iRet = 1;
                return iRet;
            }


            // 2. 있으면 각 column 내용들을 비교하여 다른컬럼이 있는지 체크한다.
            //    체크할 column : 사용자, 부서, RAM, 저장장치, VA, 운영체제, 설치장소, IP주소, MAC주소, 비고
            // 2.1 다른게 없으면 무시
            //     * 기존것 Update
            // 2.2 다른게 있으면
            //      - 기존것은 HistoryTable에 추가
            //      - Version을 증가 시켜서 기존 것을 대체한다.
            // iRet = 2;

            return iRet;
        }

        public List<ITAssetMain> GetAssetAll()
        {
            List<ITAssetMain> lstAsset = _dbContextAsset.iTAssetMains.ToList();
            return lstAsset;
        }

        public ITAssetMain GetLastAsset()
        {
            //--- AsNoTracking : 항상 새로 가져온다.
            ITAssetMain aAsset = _dbContextAsset.iTAssetMains.AsNoTracking().OrderBy(t=> t.Uuid).LastOrDefault();
            return aAsset;
        }

        private void SetAssetValueWithArray(ref ITAssetMain iAsset, string[] values, string usernm)
        {
            iAsset.Uuid = values[1];
            iAsset.AssetNo = values[2];
            iAsset.User = values[3];
            iAsset.MonitorNo = values[4];
            iAsset.MonitorInch = values[5];
            int.TryParse(values[6], out int iTemp);
            iAsset.MonitorNum = iTemp;
            iAsset.Department = values[7];
            iAsset.DeviceType = values[8];
            iAsset.DeviceMaker = values[9];
            iAsset.DeviceModel = values[10];
            iAsset.CpuType = values[11];
            iAsset.RamType = values[12];
            iAsset.StorageType = values[13];
            iAsset.VgaType = values[14];
            iAsset.WMacAddr = values[15];
            iAsset.DeviceSerial = values[16];
            iAsset.OsType = values[17];
            iAsset.DatePurchase = values[18];
            iAsset.InstallPlace = values[19];
            iAsset.IpAddr = values[20];
            iAsset.MacAddr = values[21];
            iAsset.Etc = values[22];

            iAsset.CurrentStatus = "사용중";
            iAsset.Creator = usernm;
            iAsset.Updator = "";
            iAsset.DateCreate = DateTime.Now;
        }

    }
}
