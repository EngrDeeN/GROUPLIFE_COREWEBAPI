using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCoreApi.Models;

namespace WebCoreApi.DAORespositories
{
    public interface ICustomerFileUploadingRepository
    {
        public object PostUploadCustomerFile(CustomerFileUploading CustomerFileUploading);
    }
}