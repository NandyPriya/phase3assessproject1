using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EMSWEBAPI.Models
{
    public class EMSProperty
    {
        public int DeptCode { get; set; }
        
        [Required()]
        public int EmpCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }

    }
}