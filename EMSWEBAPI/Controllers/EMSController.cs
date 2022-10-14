using EMP_BAL;
using EMP_DAL;
using EMSWEBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Web.Http;

namespace EMSWEBAPI.Controllers
{
    public class EMSController : ApiController
    {
        BAL be = null;
        public EMSController()
        {
            be = new BAL();
        }
        // GET api/<controller>
        [Route("Getallemps")]
        public List<EMSProperty> Get()
        {
            List<EMSProperty> profiles = new List<EMSProperty>();
            List<EmpProfile> empbal = new List<EmpProfile>();
            empbal = be.ShowEmployeeList();
            foreach (var item in empbal)
            {
                //Employees emp = new Employees();
                profiles.Add(new EMSProperty { EmpCode = item.EmpCode, EmpName = item.EmpName, Email = item.Email, DateOfBirth = item.DateOfBirth, DeptCode = item.DeptCode });
            }
            
            return profiles;
        }
        [Route("GetEmpbyid/{id}")]
            // GET api/<controller>/5
            public EMSProperty Get(int id)
        {
            EmpProfile p = be.SearchEmployee(id);
            EMSProperty k = new EMSProperty();
            k.EmpCode = p.EmpCode;
            k.EmpName = p.EmpName;
            k.DateOfBirth = p.DateOfBirth;
            k.Email=p.Email;
            k.DeptCode = p.DeptCode;
            return k;
        }
        [Route("AddEmps")]
        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] EMSProperty p1)
        {
            EmpProfile hy = new EmpProfile();
            hy.EmpCode = p1.EmpCode;
            hy.DateOfBirth= Convert.ToDateTime(p1.DateOfBirth);
            hy.Email = p1.Email;
            hy.EmpName = p1.EmpName;
            hy.DeptCode = p1.DeptCode;
            bool ans = be.addemployee(hy);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
        [Route("UpdateEmps/{id}")]
        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, [FromBody] EMSProperty p1)
        {
            EmpProfile hy1 = new EmpProfile();

            hy1.EmpCode = p1.EmpCode;
            hy1.DateOfBirth = Convert.ToDateTime(p1.DateOfBirth);
            hy1.Email = p1.Email;
            hy1.EmpName = p1.EmpName;
            hy1.DeptCode = p1.DeptCode;
            bool ans = be.editemployee(id,hy1);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
        [Route("DeleteEmps/{id}")]
        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            bool ans = be.RemoveEmployee(id);
            if (ans)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }
    }
}