﻿using Newtonsoft.Json;
using SKTRFIDLIBRARY.Interface;
using SKTRFIDLIBRARY.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SKTRFIDLIBRARY.Service
{
    public class APIService : IAPI
    {
        public async Task<RFIDModel> CallAPI(DataModel data)
        {
            RFIDModel rfid = new RFIDModel();
            try
            {
                HttpClient client = new HttpClient();
                string url = $"http://10.43.6.33/jsonforandroidskt/getRfidDump?areaid={data.area_id}&cropyear={data.crop_year}&card={data.rfid}";
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    rfid = JsonConvert.DeserializeObject<RFIDModel>(responseBody);
                }
                return rfid;
            }
            catch
            {
                return null;
            }
        }

        public async Task<DataUpdateModel> InsertDataAPI(int areaid, string cropyear, string barcode, int phase, int dump, string type)
        {
            DataUpdateModel data = new DataUpdateModel();
            try
            {
                HttpClient client = new HttpClient();
                string url = $"http://10.43.6.33/jsonforandroidskt/insertDump?areaid={areaid}&cropyear={cropyear}&barcode={barcode}&phase={phase}&dump={dump}&type={type}";
                HttpResponseMessage response = await client.PostAsync(url, null);
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    data = JsonConvert.DeserializeObject<DataUpdateModel>(responseBody);
                }
                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}
