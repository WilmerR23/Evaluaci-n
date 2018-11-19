using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GH.Extensions
{
    public static class UnitOfWorkApiExtensions
    {
        public async static Task<IActionResult> InApiRequestTransactionAsync(this IUnitOfWork unitOfWork,
            Func<IActionResult> action)
        {
            return await unitOfWork.InTransactionAsync(action);
        }

        public static IActionResult InApiRequestTransaction(this IUnitOfWork unitOfWork,
            Func<IActionResult> action)
        {
            return unitOfWork.InTransaction(action);
        }
    }
}