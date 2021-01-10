using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Extensions
{
    public static class HttpContextExtension
    {
        public static Guid GetUserId(this HttpContext context)
        {
            var user = context.User;
            var guid = user.Claims.SingleOrDefault(claim => claim.Type == "id").Value;
            return Guid.Parse(guid);
        }
    }
}
