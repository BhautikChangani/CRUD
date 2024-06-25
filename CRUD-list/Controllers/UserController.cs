using CRUD_list.DBModels;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Http;
using Telerik.SvgIcons;
using System.Text;
using System.Web.Http.Results;

namespace CRUD_list.Controllers
{
    public class UserController : Controller
    {
        private readonly bhautikchangani_dbEntities _context;
        private readonly HttpClient _httpClient;

        public UserController()
        {
            _context = new bhautikchangani_dbEntities();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7037/");
        }
        public UserController(bhautikchangani_dbEntities context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var listofData = _context.employee1.ToList();
            return View("List");
        }
        public async Task<JsonResult> GetUsersData([DataSourceRequest] DataSourceRequest request)
        {
            var response = await _httpClient.GetAsync("User/GetUsers");

            if (response.IsSuccessStatusCode)
            {

                string responseBody = await response.Content.ReadAsStringAsync();

                List<Users> user = JsonConvert.DeserializeObject<List<Users>>(responseBody);
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error retrieving users data.");
                return Json(new List<Users>());
            }
        }
        public async Task UpdateUsersData([DataSourceRequest] DataSourceRequest request, Users user)
        {
            if(user.EmpId == null)
            {
                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("User/CreateUser", content);

            } else
            {
                string json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("User/UpdateUsersData", content);
            }

        }
        public async Task DeleteUsersData([DataSourceRequest] DataSourceRequest request, Users user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("User/DeleteUser", content);
        }
        public async Task<JsonResult> GetDepartment()
        {
            var response = await _httpClient.GetAsync("User/GetDepartmentList");

            if (response.IsSuccessStatusCode)
            {

                string responseBody = await response.Content.ReadAsStringAsync();

                List<DepartmentVM> departments = JsonConvert.DeserializeObject<List<DepartmentVM>>(responseBody);
                return Json(departments, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error retrieving users data.");
                return Json(new List<DepartmentVM>());
            }
        }

        public async Task<JsonResult> GetManagerList()
        {
            var response = await _httpClient.GetAsync("User/GetManagerList");

            if (response.IsSuccessStatusCode)
            {

                string responseBody = await response.Content.ReadAsStringAsync();

                List<ManagerVM> managerList = JsonConvert.DeserializeObject<List<ManagerVM>>(responseBody);
                return Json(managerList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error retrieving users data.");
                return Json(new List<DepartmentVM>());
            }
        }

        public async Task DeleteAll([FromBody]List<Users> selectedItems)
        {
            if(selectedItems != null)
            {
            var json = JsonConvert.SerializeObject(selectedItems);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("User/DeleteSelectedUsers", content);
            }
        }
        public async Task<JsonResult> GetColumnNames(int id)
        {
            string requestUrl = $"User/GetColumnList?id={id}";
            var response = await _httpClient.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {

                string responseBody = await response.Content.ReadAsStringAsync();

                List<ColumnVM> columnList = JsonConvert.DeserializeObject<List<ColumnVM>>(responseBody);
                List<string> data = new List<string>();
                foreach (var item in columnList)
                {
                    data.Add(item.ColumnName);
                }
                return Json(columnList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Error retrieving users data.");
                return Json(new List<ColumnVM>());
            }
        }


    }
}