using Microsoft.AspNetCore.Mvc.Rendering;
using ShopCartSoftware.Data;
using ShopCartSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopCartSoftware.Helpers
{
    public static class Functions
    {
        public static SelectList GetCategorys(bool IncluyeTodas=false)
        {
            var dbContext = new ApplicationDbContext();
            var lstCategory = dbContext.Category.ToList();
            if( IncluyeTodas)
            {
                var categoryAll = new Category();
                categoryAll.Id = 0;
                categoryAll.Description = "Todas";
                lstCategory.Insert(0,categoryAll);
            }
            var SelectList = new SelectList(lstCategory, "Id", "Description");
            return SelectList;
        }



       
            public static string getUserId(this ClaimsPrincipal user)
            {
                if (!user.Identity.IsAuthenticated)
                    return null;

                ClaimsPrincipal currentUser = user;
                return currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            }

       



    }
}
