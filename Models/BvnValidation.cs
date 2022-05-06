using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BvnValidationAPInew.Models
{
    public class BvnValidation
    {

    }

    public class verifySingleBVN
    {
        public string RequestId { get; set; }
        public string BVN { get; set; }
    }

    public class verifyMultipleBVN
    {
        public string RequestId { get; set; }
        public string BVNS { get; set; }
    }


    public class GetSingleBVN
    {
        public string RequestId { get; set; }
        public string BVN { get; set; }
    }

    public class GetMultipleBVN
    {
        public string RequestId { get; set; }
        public string BVNS { get; set; }
    }


    public class IsBVNWatchlisted
    {
        public string RequestId { get; set; }
        public string BVN { get; set; }
    }

}
