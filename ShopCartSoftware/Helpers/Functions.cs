using Microsoft.AspNetCore.Mvc.Rendering;
using ShopCartSoftware.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopCartSoftware.Helpers
{
    public static class Functions
    {
        public static SelectList GetCategorys()
        {
            var dbContext = new ApplicationDbContext();
            var lstCategory = dbContext.Category.ToList();
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
