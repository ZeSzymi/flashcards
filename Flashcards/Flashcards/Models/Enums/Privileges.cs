using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcards.Models.Enums
{
    public static class Privileges
    {
        public const string get_cards = "get_cards";
        public const string add_cards = "add_cards";
        public const string delete_cards = "delete_cards";
        public const string admin = "admin";
    }
}
