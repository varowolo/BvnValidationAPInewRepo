using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BvnValidationAPInew.LogService;
using Microsoft.AspNetCore.Authorization;
using BvnValidationAPInew.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BvnValidationAPInew.Controllers
{
    
    [ApiController]
    public class BvnValidationApiController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        private readonly ILogWriter _logger;
        private readonly RepositoryContext _db;

        public BvnValidationApiController(IHttpClientFactory clientFactory, IConfiguration config, ILogWriter logger, RepositoryContext db)
        {
            _clientFactory = clientFactory;
            _config = config;
            _logger = logger;
            _db = db;
        }

        //[Authorize]
        [HttpPost]
        [Route("api/BvnValidationApi/VerifySingleBVN")]
        public async Task<object> VerifySingleBVN(verifySingleBVN vsb)
        {
            var baseurl = _config.GetSection("BaseAddress").Value.ToString();
            var addLook = _config.GetSection("VerifySingleBVNUrl").Value.ToString();
            verifySingleBVN innt = vsb;
            object VerifySingleInfo = new object();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                //addlook.DefaultRequestHeaders.Add("Authorization", "Bearer " + Auth);
                client.Timeout = new System.TimeSpan(0, 0, 1, 0);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var stringContent = new StringContent(JsonConvert.SerializeObject(vsb), Encoding.UTF8, "application/json");
                var resp = await client.PostAsync(addLook, stringContent);
                var VerifySingleBVNResp = await resp.Content.ReadAsStringAsync();

                try
                {
                    DateTime requestTime;
                    DateTime responseTime;
                    tblRequestAndResponseLog requestForDb = new tblRequestAndResponseLog();
                    if (resp.IsSuccessStatusCode)
                    {
                        requestTime = DateTime.Now;
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { RequestType = "VerifySingleBVN", RequestPayload = JsonConvert.SerializeObject(vsb), Response = JsonConvert.SerializeObject(VerifySingleBVNResp), RequestId = vsb.RequestId, RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestBaseUrl = baseurl, RequestEndpoint = addLook };
                        _db.tblRequestAndResponse.Add(requestForDb);
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                           "REQUEST URL ENDPOINT :" + (addLook) + Environment.NewLine +
                           "REQUEST :" + ("Method Call: api/BvnValidationApi/VerifySingleBVN") + Environment.NewLine +
                             client.Timeout + DateTime.Now, "Request");

                        _logger.LogWrite(baseurl + Environment.NewLine +
                            "REQUEST URL ENDPOINT :" + (addLook) + Environment.NewLine +
                              "REQUEST :" + ("Method Call: api/BvnValidationApi/VerifySingleBVN") + Environment.NewLine +
                              "RESPONSE :" + VerifySingleBVNResp + Environment.NewLine + client.Timeout + DateTime.Now, "Response");
                    }
                    else
                    {
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { Response = JsonConvert.SerializeObject(VerifySingleBVNResp), RequestId = vsb.RequestId, RequestTimestamp = responseTime };
                        await _db.SaveChangesAsync();


                        _logger.LogWrite(baseurl + Environment.NewLine +
                           "REQUEST URL ENDPOINT :" + (addLook) + Environment.NewLine +
                             "REQUEST :" + ("Method Call: api/BvnValidationApi/VerifySingleBVN") + Environment.NewLine +
                             "RESPONSE :" + VerifySingleBVNResp + Environment.NewLine + client.Timeout + DateTime.Now, "Error");
                        return VerifySingleBVNResp;
                    }
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {

                        HttpWebResponse response = (System.Net.HttpWebResponse)e.Response;
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            return null;
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                            return null;

                        if (response.StatusCode == HttpStatusCode.Forbidden)
                            return null;

                        if (response.StatusCode == HttpStatusCode.BadRequest)
                            return null;
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                return VerifySingleBVNResp;
            }

        }


       // [Authorize]
        [HttpPost]
        [Route("api/BvnValidationApi/VerifyMultipleBVN")]
        public async Task<object> VerifyMultipleBVN(verifyMultipleBVN vmb)
        {
            var baseurl = _config.GetSection("BaseAddress").Value.ToString();
            var VmbLook = _config.GetSection("VerifyMultipleBVNUrl").Value.ToString();

            verifyMultipleBVN innt = vmb;
            object VerifyMultipleInfo = new object();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                //addlook.DefaultRequestHeaders.Add("Authorization", "Bearer " + Auth);
                client.Timeout = new System.TimeSpan(0, 0, 1, 0);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var stringContent = new StringContent(JsonConvert.SerializeObject(vmb), Encoding.UTF8, "application/json");
                var resp = await client.PostAsync(VmbLook, stringContent);
                var VerifyMultipleBVNResp = await resp.Content.ReadAsStringAsync();

                try
                {
                    DateTime requestTime;
                    DateTime responseTime;
                    tblRequestAndResponseLog requestForDb = new tblRequestAndResponseLog();
                    if (resp.IsSuccessStatusCode)
                    {
                        requestTime = DateTime.Now;
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { RequestType = "VerifyMultipleBVN", RequestPayload = JsonConvert.SerializeObject(vmb), Response = JsonConvert.SerializeObject(VerifyMultipleBVNResp), RequestId = vmb.RequestId, RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestBaseUrl = baseurl, RequestEndpoint = VmbLook };
                        _db.tblRequestAndResponse.Add(requestForDb);
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                           "REQUEST URL ENDPOINT :" + (VmbLook) + Environment.NewLine +
                           "REQUEST :" + ("Method Call: api/BvnValidationApi/VerifyMultipleBVN") + Environment.NewLine +
                             client.Timeout + DateTime.Now, "Request");

                        _logger.LogWrite(baseurl + Environment.NewLine +
                            "REQUEST URL ENDPOINT :" + (VmbLook) + Environment.NewLine +
                              "REQUEST :" + ("Method Call: api/BvnValidationApi/VerifyMultipleBVN") + Environment.NewLine +
                              "RESPONSE :" + VerifyMultipleBVNResp + Environment.NewLine + client.Timeout + DateTime.Now, "Response");
                    }
                    else
                    {
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { Response = JsonConvert.SerializeObject(VerifyMultipleBVNResp), RequestId = vmb.RequestId, RequestTimestamp = responseTime };
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                           "REQUEST URL ENDPOINT :" + (VmbLook) + Environment.NewLine +
                             "REQUEST :" + ("Method Call: api/BvnValidationApi/VerifyMultipleBVN") + Environment.NewLine +
                             "RESPONSE :" + VerifyMultipleBVNResp + Environment.NewLine + client.Timeout + DateTime.Now, "Error");
                        return VerifyMultipleBVNResp;
                    }
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {

                        HttpWebResponse response = (System.Net.HttpWebResponse)e.Response;
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            return null;
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                            return null;

                        if (response.StatusCode == HttpStatusCode.Forbidden)
                            return null;

                        if (response.StatusCode == HttpStatusCode.BadRequest)
                            return null;
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                return VerifyMultipleBVNResp;

            }

        }


        //[Authorize]
        [HttpPost]
        [Route("api/BvnValidationApi/GetSingleBVN")]
        public async Task<object> GetSingleBVN(GetSingleBVN gsb)
        {
            var baseurl = _config.GetSection("BaseAddress").Value.ToString();
            var gsbLook = _config.GetSection("GetSingleBVNUrl").Value.ToString();

            GetSingleBVN innt = gsb;
            object VerifyMultipleInfo = new object();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                //addlook.DefaultRequestHeaders.Add("Authorization", "Bearer " + Auth);
                client.Timeout = new System.TimeSpan(0, 0, 1, 0);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var stringContent = new StringContent(JsonConvert.SerializeObject(gsb), Encoding.UTF8, "application/json");
                var resp = await client.PostAsync(gsbLook, stringContent);
                var GetSingleBVNResp = await resp.Content.ReadAsStringAsync();

                try
                {
                    DateTime requestTime;
                    DateTime responseTime;
                    tblRequestAndResponseLog requestForDb = new tblRequestAndResponseLog();
                    if (resp.IsSuccessStatusCode)
                    {
                        requestTime = DateTime.Now;
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { RequestType = "GetSingleBVN", RequestPayload = JsonConvert.SerializeObject(gsb), Response = JsonConvert.SerializeObject(GetSingleBVNResp), RequestId = gsb.RequestId, RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestBaseUrl = baseurl, RequestEndpoint = gsbLook };
                        _db.tblRequestAndResponse.Add(requestForDb);
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                           "REQUEST URL ENDPOINT :" + (gsbLook) + Environment.NewLine +
                           "REQUEST :" + ("Method Call: api/BvnValidationApi/GetSingleBVN") + Environment.NewLine +
                             client.Timeout + DateTime.Now, "Request");

                        _logger.LogWrite(baseurl + Environment.NewLine +
                            "REQUEST URL ENDPOINT :" + (gsbLook) + Environment.NewLine +
                              "REQUEST :" + ("Method Call: api/BvnValidationApi/GetSingleBVN") + Environment.NewLine +
                              "RESPONSE :" + GetSingleBVNResp + Environment.NewLine + client.Timeout + DateTime.Now, "Response");
                    }
                    else
                    {
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { Response = JsonConvert.SerializeObject(GetSingleBVNResp), RequestId = gsb.RequestId, RequestTimestamp = responseTime };
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                           "REQUEST URL ENDPOINT :" + (gsbLook) + Environment.NewLine +
                             "REQUEST :" + ("Method Call: api/BvnValidationApi/GetSingleBVN") + Environment.NewLine +
                             "RESPONSE :" + GetSingleBVNResp + Environment.NewLine + client.Timeout + DateTime.Now, "Error");
                        return GetSingleBVNResp;
                    }
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {

                        HttpWebResponse response = (System.Net.HttpWebResponse)e.Response;
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            return null;
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                            return null;

                        if (response.StatusCode == HttpStatusCode.Forbidden)
                            return null;

                        if (response.StatusCode == HttpStatusCode.BadRequest)
                            return null;
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                return GetSingleBVNResp;


            }
        }


       // [Authorize]
        [HttpPost]
        [Route("api/BvnValidationApi/GetMultipleBVN")]
        public async Task<object> GetMultipleBVN(GetMultipleBVN gmb)
        {
            var baseurl = _config.GetSection("BaseAddress").Value.ToString();
            var gmbLook = _config.GetSection("GetMultipleBVNUrl").Value.ToString();

            GetMultipleBVN innt = gmb;
            object GetMultipleInfo = new object();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                //addlook.DefaultRequestHeaders.Add("Authorization", "Bearer " + Auth);
                client.Timeout = new System.TimeSpan(0, 0, 1, 0);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var stringContent = new StringContent(JsonConvert.SerializeObject(gmb), Encoding.UTF8, "application/json");
                var resp = await client.PostAsync(gmbLook, stringContent);
                var GetMultipleBVNResp = await resp.Content.ReadAsStringAsync();

                try
                {
                    DateTime requestTime;
                    DateTime responseTime;
                    tblRequestAndResponseLog requestForDb = new tblRequestAndResponseLog();
                    if (resp.IsSuccessStatusCode)
                    {
                        requestTime = DateTime.Now;
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { RequestType = "GetMultipleBVN", RequestPayload = JsonConvert.SerializeObject(gmb), Response = JsonConvert.SerializeObject(GetMultipleBVNResp), RequestId = gmb.RequestId, RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestBaseUrl = baseurl, RequestEndpoint = gmbLook };
                        _db.tblRequestAndResponse.Add(requestForDb);
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                           "REQUEST URL ENDPOINT :" + (gmbLook) + Environment.NewLine +
                           "REQUEST :" + ("Method Call: api/BvnValidationApi/GetMultipleBVN") + Environment.NewLine +
                             client.Timeout + DateTime.Now, "Request");

                        _logger.LogWrite(baseurl + Environment.NewLine +
                            "REQUEST URL ENDPOINT :" + (gmbLook) + Environment.NewLine +
                              "REQUEST :" + ("Method Call: api/BvnValidationApi/GetMultipleBVN") + Environment.NewLine +
                              "RESPONSE :" + GetMultipleBVNResp + Environment.NewLine + client.Timeout + DateTime.Now, "Response");
                    }
                    else
                    {
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { Response = JsonConvert.SerializeObject(GetMultipleBVNResp), RequestId = gmb.RequestId, RequestTimestamp = responseTime };
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                           "REQUEST URL ENDPOINT :" + (gmbLook) + Environment.NewLine +
                             "REQUEST :" + ("Method Call: api/BvnValidationApi/GetMultipleBVN" +
                             "") + Environment.NewLine +
                             "RESPONSE :" + GetMultipleBVNResp + Environment.NewLine + client.Timeout + DateTime.Now, "Error");
                        return GetMultipleBVNResp;
                    }
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {

                        HttpWebResponse response = (System.Net.HttpWebResponse)e.Response;
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            return null;
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                            return null;

                        if (response.StatusCode == HttpStatusCode.Forbidden)
                            return null;

                        if (response.StatusCode == HttpStatusCode.BadRequest)
                            return null;
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                return GetMultipleBVNResp;


            }
        }


        //[Authorize]
        [HttpPost]
        [Route("api/BvnValidationApi/IsBVNWatchlisted")]
        public async Task<object> IsBVNWatchlisted(IsBVNWatchlisted ibw)
        {
            var baseurl = _config.GetSection("BaseAddress").Value.ToString();
            var ibwLook = _config.GetSection("IsBVNWatchlistedUrl").Value.ToString();

            IsBVNWatchlisted innt = ibw;
            object GetMultipleInfo = new object();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                //addlook.DefaultRequestHeaders.Add("Authorization", "Bearer " + Auth);
                client.Timeout = new System.TimeSpan(0, 0, 1, 0);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var stringContent = new StringContent(JsonConvert.SerializeObject(ibw), Encoding.UTF8, "application/json");
                var resp = await client.PostAsync(ibwLook, stringContent);
                var IsBVNWatchlistedResp = await resp.Content.ReadAsStringAsync();

                try
                {
                    DateTime requestTime;
                    DateTime responseTime;
                    tblRequestAndResponseLog requestForDb = new tblRequestAndResponseLog();
                    if (resp.IsSuccessStatusCode)
                    {
                        requestTime = DateTime.Now;
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { RequestType = "IsBVNWatchlisted", RequestPayload = JsonConvert.SerializeObject(ibw), Response = JsonConvert.SerializeObject(IsBVNWatchlistedResp), RequestId = ibw.RequestId, RequestTimestamp = DateTime.Now, ResponseTimestamp = DateTime.Now, RequestBaseUrl = baseurl, RequestEndpoint = ibwLook };
                        _db.tblRequestAndResponse.Add(requestForDb);
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                           "REQUEST URL ENDPOINT :" + (ibwLook) + Environment.NewLine +
                           "REQUEST :" + ("Method Call: api/BvnValidationApi/GetMultipleBVN") + Environment.NewLine +
                             client.Timeout + DateTime.Now, "Request");

                        _logger.LogWrite(baseurl + Environment.NewLine +
                            "REQUEST URL ENDPOINT :" + (ibwLook) + Environment.NewLine +
                              "REQUEST :" + ("Method Call: api/BvnValidationApi/GetMultipleBVN") + Environment.NewLine +
                              "RESPONSE :" + IsBVNWatchlistedResp + Environment.NewLine + client.Timeout + DateTime.Now, "Response");
                    }
                    else
                    {
                        responseTime = DateTime.Now;
                        requestForDb = new tblRequestAndResponseLog() { Response = JsonConvert.SerializeObject(IsBVNWatchlistedResp), RequestId = ibw.RequestId, RequestTimestamp = responseTime };
                        await _db.SaveChangesAsync();

                        _logger.LogWrite(baseurl + Environment.NewLine +
                           "REQUEST URL ENDPOINT :" + (ibwLook) + Environment.NewLine +
                             "REQUEST :" + ("Method Call: api/BvnValidationApi/GetMultipleBVN" +
                             "") + Environment.NewLine +
                             "RESPONSE :" + IsBVNWatchlistedResp + Environment.NewLine + client.Timeout + DateTime.Now, "Error");
                        return IsBVNWatchlistedResp;
                    }
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {

                        HttpWebResponse response = (System.Net.HttpWebResponse)e.Response;
                        if (response.StatusCode == HttpStatusCode.NotFound)
                            return null;
                        if (response.StatusCode == HttpStatusCode.Unauthorized)
                            return null;

                        if (response.StatusCode == HttpStatusCode.Forbidden)
                            return null;

                        if (response.StatusCode == HttpStatusCode.BadRequest)
                            return null;
                        else
                            return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                return IsBVNWatchlistedResp;


            }
        }

    }
}
